

using Microsoft.EntityFrameworkCore;

namespace Cards.Infrastructure
{
    public class CardsDbContext : DbContext
    {
        public CardsDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Domain.Entities.Card> Cards { get; set; }


    }
}