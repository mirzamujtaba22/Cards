

using Cards.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cards.Infrastructure
{
    public class CardsDbContext : DbContext
    {
       
        public CardsDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Domain.Entities.Card> Cards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>().ToTable("Cards");
        }
            //public DbSet<Domain.Entities.IEntity> entities { get; set; }



        }
}