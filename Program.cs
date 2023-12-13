using BakerHouseApp.Entities;
using BakerHouseApp.Repositories;
using BakerHouseApp.Data;


var wheadBreadRepository = new SqlRepository<WheatBread>(new BakerHouseAppDbContext());
AddWheadBreads(wheadBreadRepository);
AddRyeBreads(wheadBreadRepository);
WriteAllToConsole(wheadBreadRepository);

static void AddWheadBreads(IRepository<WheatBread> wheadBreadRepository)
{
    wheadBreadRepository.Add(new WheatBread { NameBread = "Chleb Pszenny",  QuantityBread = "50", WeightBread = "300" });
    wheadBreadRepository.Add(new WheatBread { NameBread = "Chleb Firmowy", QuantityBread = "10", WeightBread = "500" });
    wheadBreadRepository.Add(new WheatBread { NameBread = "Chleb Codzienny", QuantityBread = "150", WeightBread = "250" });
    wheadBreadRepository.Save();
}

static void AddRyeBreads(IWriteRepository<RyeBread> ryeBreadRepository)
{
    ryeBreadRepository.Add(new RyeBread { NameBread = "Chleb Żytni", QuantityBread = "30", WeightBread = "500" });
    ryeBreadRepository.Add(new RyeBread { NameBread = "Chleb Farmerski", QuantityBread = "40", WeightBread = "750" });
    ryeBreadRepository.Add(new RyeBread { NameBread = "Chleb z Foremki", QuantityBread = "80", WeightBread = "450" });
    ryeBreadRepository.Save();

}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}