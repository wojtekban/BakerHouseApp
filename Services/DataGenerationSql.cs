namespace BakerHouseApp.Services;

public class DataGenerationSql : DataGeneration
{
    private readonly BakerHouseAppDbContext _dbContext;
 
    public DataGenerationSql(BakerHouseAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public override void ViewDataSourceInfo()
    {
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("Data provider: SQL Database.\n");
        Console.ResetColor();
    }

    public override void AddBread()
    {
        if (_dbContext.Database.CanConnect() && !_dbContext.Breads.Any())
        {
            var breads = GetBread();
            _dbContext.Breads.AddRange(breads);
            _dbContext.SaveChanges();
        }
    }

    public override void AddCustomer()
    {
        if (_dbContext.Database.CanConnect() && !_dbContext.Customers.Any())
        {
            var customers = GetCustomer();
            _dbContext.Customers.AddRange(customers);
            _dbContext.SaveChanges();
        }
    }
}