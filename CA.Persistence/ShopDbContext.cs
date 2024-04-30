using CA.Application.Interfaces;
using CA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CA.Persistence
{
    public class ShopDbContext : DbContext, IDbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }


        public ShopDbContext()
        : base()
        {
        }
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
        : base(options)
        {
            Database.Migrate();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().
                HasData(new Product()
                {
                    Id = Guid.Parse("2a510554-0de4-43cc-a4aa-1b0c7aecde92"),
                    Name = "PlayStation 5",
                    Summary = "The next generation console with powerful graphics and immersive gaming experience.",
                    Price = 499.00M,
                    Category = "Gaming Console"
                },
            new Product()
            {
                Id = Guid.Parse("8c2a2a4f-0ec7-4497-96fb-364871bb5e2e"),
                Name = "Xbox Series X",
                Summary = "Experience incredible speed and power with the fastest, most powerful Xbox ever made.",
                Price = 499.00M,
                Category = "Gaming Console"
            },
            new Product()
            {
                Id = Guid.Parse("8b0fef59-c999-4e4f-85e4-27bffc0feb5d"),
                Name = "NVIDIA RTX 3080",
                Summary = "Take your graphics to the next level with this high-performance graphics card.",
                Price = 699.00M,
                Category = "Graphics Card"
            },
            new Product()
            {
                Id = Guid.Parse("58448317-cb14-417b-af1a-3c2b3b4bacb7"),
                Name = "Razer BlackWidow Keyboard",
                Summary = "A mechanical keyboard with customizable Chroma RGB lighting for enhanced gaming performance.",
                Price = 149.00M,
                Category = "Gaming Peripherals"
            },
            new Product()
            {
                Id = Guid.Parse("0d451300-edbb-4ccf-86bd-b6efc5b06098"),
                Name = "Logitech G502 Gaming Mouse",
                Summary = "A high-performance wired mouse with customizable buttons and RGB lighting for ultimate control.",
                Price = 59.00M,
                Category = "Gaming Peripherals"
            },
            new Product()
            {
                Id = Guid.Parse("0cfa8b6b-111e-48f5-9444-fb9db49b7483"),
                Name = "Samsung Odyssey G9 Gaming Monitor",
                Summary = "Immerse yourself in the game with this curved monitor featuring a high refresh rate and stunning visuals.",
                Price = 1299.00M,
                Category = "Gaming Monitors"
            });

            modelBuilder.Entity<Order>().HasData(GetRandomOrders(6));

        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        private static List<Order> GetRandomOrders(int orderCount)
        {
            var orders = new List<Order>();

            Random random = new Random();

            for (int i = 1; i <= orderCount; i++)
            {
                Order order = new Order
                {
                    Id = GetId(i - 1),
                    UserName = $"User{i}",
                    TotalAmount = random.Next(100, 1000),
                    OrderNumber = $"ORD-{i}",
                    Comment = $"comment for order {i}",
                    FirstName = GetRandomFirstName(),
                    LastName = GetRandomLastName(),
                    EmailAddress = $"user{i}@example.com"
                };

                orders.Add(order);
            }

            return orders;
        }
        private static Guid GetId(int i)
        {
            Guid[] guids =
            {
            Guid.Parse("2a510554-0de4-43cc-a4aa-1b0c7aecde92"),
            Guid.Parse("8c2a2a4f-0ec7-4497-96fb-364871bb5e2e"),
            Guid.Parse("8b0fef59-c999-4e4f-85e4-27bffc0feb5d"),
            Guid.Parse("58448317-cb14-417b-af1a-3c2b3b4bacb7"),
            Guid.Parse("0d451300-edbb-4ccf-86bd-b6efc5b06098"),
            Guid.Parse("0cfa8b6b-111e-48f5-9444-fb9db49b7483")
        };
            return guids[i];
        }
        private static string GetRandomFirstName()
        {
            string[] firstNames = { "John", "Emma", "Michael", "Sophia", "William", "Olivia", "James", "Amelia", "Alexander", "Charlotte" };
            Random random = new Random();
            return firstNames[random.Next(firstNames.Length)];
        }

        private static string GetRandomLastName()
        {
            string[] lastNames = { "Smith", "Johnson", "Brown", "Taylor", "Anderson", "Wilson", "Miller", "Davis", "Garcia", "Martinez" };
            Random random = new Random();
            return lastNames[random.Next(lastNames.Length)];
        }
    }
}
