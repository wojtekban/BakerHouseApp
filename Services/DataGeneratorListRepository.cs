namespace BakerHouseApp.Services;

public class DataGeneratorListRepository : DataGenerator
{
    private readonly IRepository<Bread> _breadRepository;
    private readonly IRepository<CustBread> _custBreadRepository;
    public DataGeneratorListRepository(IRepository<Bread> breadRepository, IRepository<CustBread> custBreadRepository)
    {
        _breadRepository = breadRepository;
        _custBreadRepository = custBreadRepository;
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

    public override void AddCustBread()
    {
        _custBreadRepository.Read(); // reading from json file

        if (_custBreadRepository.GetListCount() == 0)
        {
            var custBread = GetCustBread();

            _custBreadRepository.AddBatch(custBread);
        }
    }
}