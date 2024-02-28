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
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bread>()
            .Property(p => p.Name)
        .IsRequired()
            .HasMaxLength(250);

        modelBuilder.Entity<Bread>()
            .Property(p => p.Type)
        .IsRequired()
            .HasMaxLength(15);

        modelBuilder.Entity<Customer>()
            .Property(p => p.AddressZipCode)
            .HasColumnType("decimal(5,0)");

        modelBuilder.Entity<Customer>()
            .Property(p => p.NipNum)
            .HasColumnType("decimal(9,0)");

        modelBuilder.Entity<Customer>()
            .Property(p => p.CustName)
            .IsRequired()
            .HasMaxLength(250);

        modelBuilder.Entity<Customer>()
            .Property(p => p.AddressCityName)
            .IsRequired()
            .HasMaxLength(250);

        modelBuilder.Entity<Customer>()
            .Property(p => p.AddressStreet)
            .IsRequired()
            .HasMaxLength(250);
    }
}



