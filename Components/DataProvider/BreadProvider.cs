using System.Numerics;

namespace BakerHouseApp.Components.DataProvider;

public class BreadProvider : IBreadProvider
{
    private readonly IRepository<Bread> _breadRepository;
    private readonly IRepository<Customer> _customerRepository;

    public BreadProvider(IRepository<Bread> breadRepository, IRepository<Customer> customerRepository)
    {
        _breadRepository = breadRepository;
        _customerRepository = customerRepository;
    }

    // SELECT
    public decimal GetMaximumPriceOfAllBread()
    {
        var breads = _breadRepository.GetAll();
        return breads.Select(x => x.Price).Max();
    }
    public decimal GetMinimumPriceOfAllBread()
    {
        var breads = _breadRepository.GetAll();
        return breads.Select(x => x.Price).Min();
    }
    public List<Bread> GetSpecificColumns()
    {
        var breads = _breadRepository.GetAll();
        var list = breads.Select(x => new Bread
        {
            Id = x.Id,
            Name = x.Name,
            Type = x.Type,
            StandardCost = x.StandardCost,
            Price = x.Price
        }).ToList();

        return list;
    }
    public List<Customer> GetSpecificCustomerColumns()
    {
        var custBreads = _customerRepository.GetAll();
        var list = custBreads.Select(x => new Customer
        {
            Id = x.Id,
            CustName = x.CustName,
            AddressStreet = x.AddressStreet,
            AddressCityName = x.AddressCityName,
            AddressZipCode = x.AddressZipCode,
            NipNum = x.NipNum
        }).ToList();

        return list;
    }
    public List<string> GetUniqueBreadType()
    {
        var breads = _breadRepository.GetAll();
        return breads.Select(x => x.Type).Distinct().ToList()!;
    }
    public string AnonymousClass()
    {
        var breads = _breadRepository.GetAll();
        var list = breads.Select(x => new
        {
            x.Name,
            x.Weight,
            x.Price
        }).ToList();

        StringBuilder sb = new StringBuilder();
        foreach (var Bread in list)
        {
            sb.AppendLine($"{Bread.Name}");
            sb.AppendLine($"{Bread.Weight}");
            sb.AppendLine($"{Bread.Price}");
            sb.AppendLine();
        }
        return sb.ToString();
    }

    // ORDER BY
    public List<Bread> OrderByNameAndCalories()
    {
        var breads = _breadRepository.GetAll();
        return breads.OrderBy(x => x.Name)
            .ThenBy(x => x.Calories).ToList();
    }
    public List<Bread> OrderByTypeAndName()
    {
        var breads = _breadRepository.GetAll();
        return breads.OrderBy(x => x.Type)
            .ThenBy(x => x.Name).ToList();
    }
    public List<Bread> OrderByTypeAndNameDesc()
    {
        var breads = _breadRepository.GetAll();
        return breads.OrderByDescending(x => x.Type)
            .ThenBy(x => x.Name).ToList();
    }
    public List<Bread> OrderByName()
    {
        var breads = _breadRepository.GetAll();
        return breads.OrderBy(x => x.Name).ToList();
    }
    public List<Customer> OrderByCustomerName()
    {
        var custBreads = _customerRepository.GetAll();
        return custBreads.OrderBy(x => x.CustName).ToList();
    }
    public List<Bread> OrderByNameDescending()
    {
        var breads = _breadRepository.GetAll();
        return breads.OrderByDescending(x => x.Name).ToList();
    }

    // WHERE
    public List<Bread> WhereStartsWith(string prefix)
    {
        var breads = _breadRepository.GetAll();
        return breads.Where(x => x.Name!.StartsWith(prefix)).ToList();
    }
    public List<Bread> WhereStartsWithAndPriceIsGreaterThan(string prefix, decimal cost)
    {
        var breads = _breadRepository.GetAll();
        return breads.Where(x => x.Name!.StartsWith(prefix) && x.Price > cost).ToList();
    }
    public List<Bread> WhereTypeIs(string type)
    {
        var breads = _breadRepository.GetAll();
        return breads.Where(x => x.Type == "Gold").ToList();
    }
    public List<Bread> WhereStartsWithAndCostIsGreaterThan(string prefix, decimal cost)
    {
        var breads = _breadRepository.GetAll();
        return breads.Where(x => x.Name!.StartsWith(prefix) && x.StandardCost > cost).ToList();
    }

    // FIRST, LAST, SINGLE
    public Bread SingleById(int id)
    {
        var breads = _breadRepository.GetAll();
        return breads.Single(x => x.Id == id);
    }

    public Bread SingleOrDefaultById(int id)
    {
        var breads = _breadRepository.GetAll();
        var Bread = breads.SingleOrDefault(x => x.Id == id);
        if (Bread is null)
        {
            Console.WriteLine($"Bread with id {id} NOT FOUND");
        }
        return Bread!;
    }
    public Bread FirstByType(string type)
    {
        var breads = _breadRepository.GetAll();
        return breads.First(x => x.Type == type);
    }
    public Bread? FirstOrDefaultByType(string type)
    {
        var breads = _breadRepository.GetAll();
        var Bread = breads.FirstOrDefault(x => x.Type == type);
        if (Bread is null)
        {
            Console.WriteLine($"There's no Bread with ncolor {type}.");
        }

        return Bread!;
    }
    public Bread FirstOrDefaultByTypeWithDefault(string type)
    {
        var breads = _breadRepository.GetAll();
        return breads
               .FirstOrDefault(
               x => x.Type == type,
               new Bread { Id = -1, Name = "NOT FOUND" });
    }
    public Bread LastByType(string type)
    {
        var breads = _breadRepository.GetAll();
        return breads.Last(x => x.Type == type);
    }

    // TAKE
    public List<Bread> TakeBread(int howMany)
    {
        var breads = _breadRepository.GetAll();
        return breads
        .OrderByDescending(x => x.DateOfProduction)
        .Take(howMany)
        .ToList();
    }
    public List<Bread> TakeBread(Range range)
    {
        var breads = _breadRepository.GetAll();
        return breads
        .OrderBy(x => x.Name)
        .ThenBy(x => x.Type)
        .Take(range)
        .ToList();
    }
    public List<Bread> TakeBreadWhileExpirationDate(DateTime date)
    {
        var breads = _breadRepository.GetAll();
        return breads
        .OrderByDescending(x => x.ExpirationDate)
        .TakeWhile(x => x.ExpirationDate >= date)
        .ToList();
    }
    public List<Bread> TakeBreadWhileNameStartsWith(string prefix)
    {
        var breads = _breadRepository.GetAll();
        return breads
       .OrderBy(x => x.Name)
       .TakeWhile(x => x.Name!.StartsWith(prefix))
       .ToList();
    }

    // SKIP
    public List<Bread> SkipBread(int howMany)
    {
        var breads = _breadRepository.GetAll();
        return breads
       .Skip(howMany)
       .ToList();
    }
    public List<Bread> SkipPlayersWhileExpirationDate(DateTime date)
    {
        var breads = _breadRepository.GetAll();
        return breads.OrderByDescending(x => x.ExpirationDate)
       .SkipWhile(x => x.ExpirationDate >= date)
       .ToList();
    }
    public List<Bread> SkipBreadWhileNameStartsWith(string prefix)
    {
        var breads = _breadRepository.GetAll();
        var Bread = _breadRepository.GetAll();
        return breads
            .OrderBy(x => x.Name)
            .SkipWhile(x => x.Name!.StartsWith(prefix))
            .ToList();
    }

    // DISTINCT
    public List<string> DistinctAllType()
    {
        var breads = _breadRepository.GetAll();
        return breads
       .Select(x => x.Type!)
       .Distinct()
       .OrderBy(x => x)
       .ToList();
    }
    public List<Bread> DistinctByType()
    {
        var breads = _breadRepository.GetAll();
        return breads
       .DistinctBy(x => x.Type)
       .OrderBy(x => x.Type)
       .ToList();
    }
    public List<double> DistinctAllCalories()
    {
        var breads = _breadRepository.GetAll();
        return breads
                .Select(x => x.Calories!)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
    }
    public List<Bread> DistinctByCalories()
    {
        var breads = _breadRepository.GetAll();
        return breads
                .DistinctBy(x => x.Calories)
                .OrderBy(x => x.Calories)
                .ToList();
    }

    // CHUNK
    public List<Bread[]> ChunkPlayers(int size)
    {
        var breads = _breadRepository.GetAll();
        return breads.Chunk(size).ToList();
    }

}
