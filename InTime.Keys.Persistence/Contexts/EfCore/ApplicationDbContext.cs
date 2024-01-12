using InTime.Keys.Domain.Common;
using InTime.Keys.Domain.Common.Interfaces;
using InTime.Keys.Domain.Enities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace InTime.Keys.Persistence.Contexts.EfCore;

public class ApplicationDbContext : DbContext
{
    private readonly IDomainEventDispatcher _dispatcher;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDomainEventDispatcher domainEventDispatcher)
        : base(options)
    {
        _dispatcher = domainEventDispatcher;
    }

    public DbSet<Key> Keys => Set<Key>();
    public DbSet<TimeSlot> TimeSlot => Set<TimeSlot>();
    public DbSet<Bid> Bids => Set<Bid>();
    public DbSet<KeyTransfer> KeyTransfers => Set<KeyTransfer>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        if (_dispatcher == null) return result;

        var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .ToArray();

        await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

        return result;
    }

    public override int SaveChanges()
    {
        return SaveChangesAsync().GetAwaiter().GetResult();
    }
}
