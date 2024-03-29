﻿using Humanizer;
using Messaging.Shared.Contexts;
using Messaging.Shared.Handlers;
using Messaging.Shared.Messaging.Brokers;
using Messaging.Subscriber.DAL;
using Messaging.Subscriber.Entities;
using Messaginh.Shared.Serialization;

namespace Messaging.Subscriber.Events.External.Handlers;

internal sealed class CustomerCreatedHandler : IEventHandler<CustomerCreated>
{
    private readonly OrdersDbContext _dbContext;
    private readonly IContextProvider _contextProvider;
    private readonly IJsonSerializer _jsonSerializer;
    private readonly IMessageBroker _messageBroker;
    private readonly ILogger<CustomerCreatedHandler> _logger;

    public CustomerCreatedHandler(OrdersDbContext dbContext, IContextProvider contextProvider,
        IJsonSerializer jsonSerializer, IMessageBroker messageBroker, ILogger<CustomerCreatedHandler> logger)
    {
        _dbContext = dbContext;
        _contextProvider = contextProvider;
        _jsonSerializer = jsonSerializer;
        _messageBroker = messageBroker;
        _logger = logger;
    }
    
    public async Task HandleAsync(CustomerCreated @event, CancellationToken cancellationToken = default)
    {
        var context = _contextProvider.Current();
        var messagePayload = _jsonSerializer.Serialize(@event);
        var contextPayload = _jsonSerializer.Serialize(context);
        await _dbContext.Customers.AddAsync(new Customer {Id = @event.Id, Name = @event.Name}, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        _logger.LogInformation($"Received '{nameof(CustomerCreated).Underscore()}'{Environment.NewLine}{messagePayload}{Environment.NewLine}{contextPayload}");
        await _messageBroker.SendAsync(new CustomerForOrderCreated(@event.Id, @event.Name), cancellationToken);
    }
}