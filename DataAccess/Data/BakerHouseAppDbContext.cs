namespace BakerHouseApp.DataAccess.Data;

public class BakerHouseAppDbContext : DbContext
{
    public BakerHouseAppDbContext(DbContextOptions<BakerHouseAppDbContext> options)
    : base(options)
    {
    }

    public DbSet<Bread> Breads => Set<Bread>();
    public DbSet<Customer> Customers => Set<Customer>();
}



