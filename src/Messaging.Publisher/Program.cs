using Messaging.Publisher.DAL;
using Messaging.Shared.Contexts;
using Messaging.Shared.Dispatchers;
using Messaging.Shared.Messaging;
using Messaging.Shared.Transactions;
using Messaging.Shared.Transactions.Inbox;
using Messaging.Shared.Transactions.Outbox;
using Messaginh.Shared.Postgres;
using Messaginh.Shared.RabbitMQ;
using Messaginh.Shared.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
 

builder.Services
    .AddSerializer()
    .AddHandlers("Messaging.Publisher")
    .AddDispatchers()
    .AddContexts()
    .AddMessaging(builder.Configuration)
    .AddPostgres<CustomersDbContext>(builder.Configuration)
    .AddInbox<CustomersDbContext>(builder.Configuration)
    .AddOutbox<CustomersDbContext>(builder.Configuration)
    .AddRabbitMQ(builder.Configuration)
    .AddTransactionalDecorators()
    .AddOutboxInstantSenderDecorators()
    .AddMessagingErrorHandlingDecorators();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();