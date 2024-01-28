namespace BakerHouseApp.Data;

public class BakerHouseAppDbContext : DbContext
{
    public DbSet<RyeBread> RyeBreads => Set<RyeBread>();

    public DbSet<WheatBread> WheatBreads => Set<WheatBread>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseInMemoryDatabase("BakerHouseAppDb");
    }
}    
