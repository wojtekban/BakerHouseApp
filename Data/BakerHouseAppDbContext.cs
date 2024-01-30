namespace BakerHouseApp.Data;

using BakerHouseApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
public class BakerHouseAppDbContext : DbContext
{
    public DbSet<Bread> Breads => Set<Bread>();
    public DbSet<CustBread> CustBreads => Set<CustBread>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
        IConfiguration configuration = configurationBuilder.Build();
      
        // optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        
       // base.OnConfiguring(optionsBuilder);
       // optionsBuilder.UseInMemoryDatabase("BakerHouseAppDb");
    }
}    
