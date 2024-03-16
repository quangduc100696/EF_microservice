using DataModel.Model;
using Infrastructure.Core.Event;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DataModel
{
    public class DbContextData : DbContext
    {
        private readonly IEventBus _eventBus;
        public DbSet<Food> Foods { get; set; }

        public DbContextData(DbContextOptions<DbContextData> contextOption, IEventBus eventBus) : base(contextOption) { 
            _eventBus = eventBus;
        }

        public async Task SaveChangesAndCommit(IEvent @event)
        {
            using (var transaction = Database.BeginTransaction())
            {
                await SaveChangesAsync();

                await _eventBus.Commit(@event);

                await transaction.CommitAsync();
            }
        }
    }
}
