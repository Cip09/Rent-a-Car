
using DB.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
namespace DatabaseClass
{
    public class DatabaseContext : IdentityDbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
      
        public DbSet<User> User { get; set; }

        public DbSet<SmartDevice> SmartDevices { get; set; }

        public DbSet<SmartSenzor> SmartSenzors { get; set; }

        public DbSet<SmartSenzorValue> SmartSenzorValues { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<RentSchedulingCar> RentSchedulingCars { get; set; }

        public DbSet<Request> Requests { get; set; }
        public DbSet<CategoryCar> CategoryCars { get; set; }

        public DbSet<UserHistory> UserHistory { get; set; }

        public DbSet<Notification> Notifications { get; set; }
    

        public static DatabaseContext getDbInstance()
        {
            IConfiguration config = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", true, true)
           .Build();

            var connectionString = config["ConnectionStrings:DbConnection"];


            var builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(connectionString)
                   .UseLazyLoadingProxies(true);

            return new DatabaseContext(builder.Options);
        }
    }
    
}


