using System.ComponentModel;
using System.Numerics;

namespace BakerHouseApp.DataAccess.Data;

public class BakerHouseAppDbContext : DbContext
{
    public DbSet<Bread> Breads => Set<Bread>();
    public DbSet<Customer> Customers => Set<Customer>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configurationBuilder = new ConfigurationBuilder().AddJsonFile(@"appsettings.json");
        IConfiguration configuration = configurationBuilder.Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    }

}



