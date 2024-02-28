namespace BakerHouseApp.ApplicationServices.Services;

public class DataGenerationSql : DataGeneration
{
    private readonly IRepository<Bread> _breadRepository;
    private readonly IRepository<Customer> _customerRepository;
    public DataGenerationSql(IRepository<Bread> breadRepository, IRepository<Customer> customerRepository)
    {
        _breadRepository = breadRepository;
        _customerRepository = customerRepository;
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
        if (_breadRepository == null)
        {
            var breads = GetBread();
            _breadRepository.AddBatch(breads);
            _breadRepository.Save();
        }
    }

    public override void AddCustomer()
    {      
        if (_customerRepository == null)
        {
        var customers = GetCustomer();
        _customerRepository.AddBatch(customers);
        _customerRepository.Save();
        }
    }
}