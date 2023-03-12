using Messaging.Shared.Transactions.Inbox;
using Messaging.Shared.Transactions.Outbox;
using Messaging.Subscriber.Entities;
using Microsoft.EntityFrameworkCore;

namespace Messaging.Subscriber.DAL;

public class OrdersDbContext : DbContext
{
    public DbSet<InboxMessage> Inbox { get; set; } = null!;
    public DbSet<OutboxMessage> Outbox { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;

    public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}