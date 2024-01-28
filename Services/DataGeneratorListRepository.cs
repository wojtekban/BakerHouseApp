namespace BakerHouseApp.Services;

public class DataGeneratorListRepository : DataGenerator, IDataGenerator
{
    private readonly IRepository<WheatBread> _wheatBreadRepository;
    private readonly IRepository<RyeBread> _ryeBreadRepository;
    public DataGeneratorListRepository(IRepository<WheatBread> wheatBreadRepository, IRepository<RyeBread> ryeBreadRepository)
    {
        _wheatBreadRepository = wheatBreadRepository;
        _ryeBreadRepository = ryeBreadRepository;
    }

    public override void ViewDataSourceInfo()
    {
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("Data provider: JSON files.\n");
        Console.ResetColor();
    }

    public override void AddWheatBread()
    {
        _wheatBreadRepository.Read(); // reading from json file

        if (_wheatBreadRepository.GetListCount() == 0)
        {
            var wheatBread = GetWheatBread();

            _wheatBreadRepository.AddBatch(wheatBread);
        }
    }

    public override void AddRyeBread()
    {
        _ryeBreadRepository.Read(); // reading from json file

        if (_ryeBreadRepository.GetListCount() == 0)
        {
            var ryeBread = GetRyeBread();

            _ryeBreadRepository.AddBatch(ryeBread);
        }
    }
}