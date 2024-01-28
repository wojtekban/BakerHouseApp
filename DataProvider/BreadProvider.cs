using System.Numerics;

namespace BakerHouseApp.DataProvider;

internal class BreadProvider : IBreadProvider
{
    private readonly IRepository<WheatBread> _wheatBreadRepository;
        public BreadProvider(IRepository<WheatBread> wheatBreadRepository)
    {
        _wheatBreadRepository = wheatBreadRepository;
    }

    // SELECT
    public decimal GetMaximumPriceOfAllBread()
    {
        var wheatBreads = _wheatBreadRepository.GetAll();
        return wheatBreads.Select(x => x.Price).Max();
    }
    public decimal GetMinimumPriceOfAllBread()
    {
        var wheatBreads = _wheatBreadRepository.GetAll();
        return wheatBreads.Select(x => x.Price).Min();
    }
    public List<WheatBread> GetSpecificColumns()
    {
        var wheatBreads = _wheatBreadRepository.GetAll();
        var list = wheatBreads.Select(x => new WheatBread
        {
            Id = x.Id,
            Name = x.Name,
            Color = x.Color,
            StandardCost = x.StandardCost,
            Price = x.Price
        }).ToList();

        return list;
    }
    public List<string> GetUniqueBreadColors()
    {
        var wheatBreads = _wheatBreadRepository.GetAll();
        return wheatBreads.Select(x => x.Color).Distinct().ToList()!;
    }
    public string AnonymousClass()
    {
        var wheatBreads = _wheatBreadRepository.GetAll();
        var list = wheatBreads.Select(x => new
        {
            Name = x.Name,
            Weight = x.Weight,
            Price = x.Price
        }).ToList();

        StringBuilder sb = new StringBuilder();
        foreach (var wheatBread in list)
        {
            sb.AppendLine($"{wheatBread.Name}");
            sb.AppendLine($"{wheatBread.Weight}");
            sb.AppendLine($"{wheatBread.Price}");
            sb.AppendLine();
        }
        return sb.ToString();
    }

    // ORDER BY
    public List<WheatBread> OrderByNameAndCalories()
    {
        var wheatBreads = _wheatBreadRepository.GetAll();
        return wheatBreads.OrderBy(x => x.Name)
            .ThenBy(x => x.Calories).ToList();
    }
    public List<WheatBread> OrderByColorAndName()
    {
        var wheatBreads = _wheatBreadRepository.GetAll();
        return wheatBreads.OrderBy(x => x.Color)
            .ThenBy(x => x.Name).ToList();
    }
    public List<WheatBread> OrderByColorAndNameDesc()
    {
        var wheatBreads = _wheatBreadRepository.GetAll();
        return wheatBreads.OrderByDescending(x => x.Color)
            .ThenBy(x => x.Name).ToList();
    }
    public List<WheatBread> OrderByName()
    {
        var wheatBreads = _wheatBreadRepository.GetAll();
        return wheatBreads.OrderBy(x => x.Name).ToList();
    }
    public List<WheatBread> OrderByNameDescending()
    {
        var wheatBreads = _wheatBreadRepository.GetAll();
        return wheatBreads.OrderByDescending(x => x.Name).ToList();
    }

    // WHERE
    public List<WheatBread> WhereStartsWith(string prefix)
    {
        var wheatBreads = _wheatBreadRepository.GetAll();
        return wheatBreads.Where(x => x.Name!.StartsWith(prefix)).ToList();
    }
    public List<WheatBread> WhereStartsWithAndPriceIsGreaterThan(string prefix, decimal cost)
    {
        var wheatBreads = _wheatBreadRepository.GetAll();
        return wheatBreads.Where(x => x.Name!.StartsWith(prefix) && x.Price > cost).ToList();
    }
    public List<WheatBread> WhereColorIs(string color)
    {
        var wheatBreads = _wheatBreadRepository.GetAll();
        return wheatBreads.Where(x => x.Color == "Gold").ToList();
    }
    public List<WheatBread> WhereStartsWithAndCostIsGreaterThan(string prefix, decimal cost)
    {
        var wheatBreads = _wheatBreadRepository.GetAll();
        return wheatBreads.Where(x => x.Name!.StartsWith(prefix) && x.StandardCost > cost).ToList();
    }

    // FIRST, LAST, SINGLE
    public WheatBread SingleById(int id)
    {
        var wheatBreads = _wheatBreadRepository.GetAll();
        return wheatBreads.Single(x => x.Id == id);
    }

    public WheatBread SingleOrDefaultById(int id)
    {
        var wheatBreads = _wheatBreadRepository.GetAll();
        var wheatBread = wheatBreads.SingleOrDefault(x => x.Id == id);
        if (wheatBread is null)
        {
            Console.WriteLine($"Bread with id {id} NOT FOUND");
        }
        return wheatBread!;
    }
    public WheatBread FirstByColor(string color)
    {
        var wheatBreads = _wheatBreadRepository.GetAll();
        return wheatBreads.First(x => x.Color == color);
    }
    public WheatBread? FirstOrDefaultByColor(string color)
    {
        var wheatBreads = _wheatBreadRepository.GetAll();
        var player = wheatBreads.FirstOrDefault(x => x.Color == color);
        if (player is null)
        {
            Console.WriteLine($"There's no Bread with ncolor {color}.");
        }

        return player!;
    }
    public WheatBread FirstOrDefaultByColorWithDefault(string color)
    {
        var wheatBreads = _wheatBreadRepository.GetAll();
        return wheatBreads
               .FirstOrDefault(
               x => x.Color == color,
               new WheatBread { Id = -1, Name = "NOT FOUND" });
    }
    public WheatBread LastByColor(string color)
    {
        var wheatBreads = _wheatBreadRepository.GetAll();
        return wheatBreads.Last(x => x.Color == color);
    }

    // TAKE
    public List<WheatBread> TakeWheatBread(int howMany)
    {
        var wheatBreads = _wheatBreadRepository.GetAll();
                return wheatBreads
                .OrderByDescending(x => x.DateOfProduction)
                .Take(howMany)
                .ToList();
    }
    public List<WheatBread> TakeWheatBread(Range range)
    {
        var wheatBreads = _wheatBreadRepository.GetAll();
                 return wheatBreads
                 .OrderBy(x => x.Name)
                 .ThenBy(x => x.Color)
                 .Take(range)
                 .ToList();
    }
    public List<WheatBread> TakeWheatBreadWhileExpirationDate(DateTime date)
    {
        var wheatBreads = _wheatBreadRepository.GetAll();
                 return wheatBreads
                 .OrderByDescending(x => x.ExpirationDate)
                 .TakeWhile(x => x.ExpirationDate >= date)
                 .ToList();
    }
    public List<WheatBread> TakeWheatBreadWhileNameStartsWith(string prefix)
    {
        var wheatBreads = _wheatBreadRepository.GetAll();
              return wheatBreads
             .OrderBy(x => x.Name)
             .TakeWhile(x => x.Name!.StartsWith(prefix))
             .ToList();
    }

    // SKIP
    public List<WheatBread> SkipWheatBread(int howMany)
    {
        var wheatBreads = _wheatBreadRepository.GetAll();
              return wheatBreads
             .Skip(howMany)
             .ToList();
    }
    public List<WheatBread> SkipPlayersWhileExpirationDate(DateTime date)
    {
        var wheatBreads = _wheatBreadRepository.GetAll();
                 return wheatBreads.OrderByDescending(x => x.ExpirationDate)
                .SkipWhile(x => x.ExpirationDate >= date)
                .ToList();
    }
    public List<WheatBread> SkipWheatBreadWhileNameStartsWith(string prefix)
    {
        var wheatBreads = _wheatBreadRepository.GetAll();
        var wheatBread = _wheatBreadRepository.GetAll();
        return wheatBreads
            .OrderBy(x => x.Name)
            .SkipWhile(x => x.Name!.StartsWith(prefix))
            .ToList();
    }
   
    // DISTINCT
    public List<string> DistinctAllColors()
    {
        var wheatBreads = _wheatBreadRepository.GetAll();
              return wheatBreads
             .Select(x => x.Color!)
             .Distinct()
             .OrderBy(x => x)
             .ToList();
    }
    public List<WheatBread> DistinctByColors()
    {
        var wheatBreads = _wheatBreadRepository.GetAll();
                  return wheatBreads
                 .DistinctBy(x => x.Color)
                 .OrderBy(x => x.Color)
                 .ToList();
    }
    public List<double> DistinctAllCalories()
    {
        var wheatBreads = _wheatBreadRepository.GetAll();
        return wheatBreads
                .Select(x => x.Calories!)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
    }
    public List<WheatBread> DistinctByCalories()
    {
        var wheatBreads = _wheatBreadRepository.GetAll();
        return wheatBreads
                .DistinctBy(x => x.Calories)
                .OrderBy(x => x.Calories)
                .ToList();
    }

    // CHUNK
    public List<WheatBread[]> ChunkPlayers(int size)
    {
        var wheatBreads = _wheatBreadRepository.GetAll();
        return wheatBreads.Chunk(size).ToList();
    }
  
}
