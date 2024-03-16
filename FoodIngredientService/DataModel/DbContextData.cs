using DataModel.Model;
using Microsoft.EntityFrameworkCore;

namespace DataModel
{
    public class DbContextData : DbContext
    {
       public DbSet<FoodIngredient> foodIngredients { get; set; }

        public DbContextData(DbContextOptions<DbContextData> contextOption) : base(contextOption) { }

        public async Task SaveChangesAndCommit(object @event)
        {
            throw new NotImplementedException();
        }
    }
}
