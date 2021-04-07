using HBCase.Entity;
using Microsoft.EntityFrameworkCore;

namespace HBCase.Data.EntityFramework
{
    public class HBCaseDbContext : DbContext
    {
        //public HBCaseDbContext(DbContextOptions<HBCaseDbContext> options) : base(options)
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=TCNEXBIMCONS01;Database=HBCase;Trusted_Connection=True;");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
