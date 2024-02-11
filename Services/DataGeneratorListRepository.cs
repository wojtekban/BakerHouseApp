namespace BakerHouseApp.Services;

public class DataGeneratorListRepository : DataGeneration
{
    private readonly IRepository<Bread> _breadRepository;
    private readonly IRepository<Customer> _customerRepository;
    public DataGeneratorListRepository(IRepository<Bread> breadRepository, IRepository<Customer> customerRepository)
    {
        _breadRepository = breadRepository;
        _customerRepository = customerRepository;
    }

    public override void ViewDataSourceInfo()
    {
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("Data provider: JSON files.\n");
        Console.ResetColor();
    }

    public override void AddBread()
    {
        _breadRepository.Read(); // reading from json file

        if (_breadRepository.GetListCount() == 0)
        {
            var bread = GetBread();

            _breadRepository.AddBatch(bread);
        }
    }

    public override void AddCustomer()
    {
        _customerRepository.Read(); // reading from json file

        if (_customerRepository.GetListCount() == 0)
        {
            var customer = GetCustomer();

            _customerRepository.AddBatch(customer);
        }
    }
}