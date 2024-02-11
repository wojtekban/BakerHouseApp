namespace BakerHouseApp.Data;

using BakerHouseApp.Data.Entities;
using Microsoft.EntityFrameworkCore;


public class BakerHouseAppDbContext : DbContext
{
    public BakerHouseAppDbContext(DbContextOptions<BakerHouseAppDbContext> options)
    : base(options)
    {
    }

    public DbSet<Bread> Breads => Set<Bread>();
    public DbSet<Customer> Customers => Set<Customer>();
}



