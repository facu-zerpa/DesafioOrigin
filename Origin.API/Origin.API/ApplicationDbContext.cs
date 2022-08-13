using Microsoft.EntityFrameworkCore;
using Origin.API.Entities;
using Origin.API.Utils;

namespace Origin.API
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public ApplicationDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            Crypto crypto = new Crypto(configuration["crypto:key"]);

            var balance = new TypeOperation() { Id = 1, Name = "Balance" };
            var withdraw = new TypeOperation() { Id = 2, Name = "Retiro" };

            modelBuilder.Entity<TypeOperation>()
                .HasData(new List<TypeOperation>
                {
                    balance, withdraw
                });

            var cardOne = new Card()
            {
                Id = 1,
                Number = crypto.Encript("1111111111111111"),
                Pin = crypto.Encript("1234"),
                DueDate = new DateTime(2023, 06, 10),
                Balance = 30000.00
            };

            modelBuilder.Entity<Card>()
                .HasData(cardOne);
        }

        public DbSet<TypeOperation> TypesOperations { get; set; }
        public DbSet<Card> Cards { get; set; }

        public DbSet<Operation> Operations { get; set; }
    }
}
