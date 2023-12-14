using BakerHouseApp.Entities;
using BakerHouseApp.Repositories;
using BakerHouseApp.Data;


var wheatBreadRepository = new SqlRepository<WheatBread>(new BakerHouseAppDbContext());
var ryeBreadRepository = new SqlRepository<RyeBread>(new BakerHouseAppDbContext());
AddWheatBreads(wheatBreadRepository);
AddRyeBreads(ryeBreadRepository);
WriteAllToConsole(wheatBreadRepository);
WriteAllToConsole(ryeBreadRepository);

static void AddWheatBreads(IRepository<WheatBread> wheatBreadRepository)
{
    wheatBreadRepository.Add(new WheatBread { Name = "Chleb Pszenny",  Quantity = 50, Weight = 300 });
    wheatBreadRepository.Add(new WheatBread { Name = "Chleb Firmowy", Quantity = 10, Weight = 500 });
    wheatBreadRepository.Add(new WheatBread { Name = "Chleb Codzienny", Quantity= 150, Weight = 250 });
    wheatBreadRepository.Save();
}

static void AddRyeBreads(IWriteRepository<RyeBread> ryeBreadRepository)
{
    ryeBreadRepository.Add(new RyeBread { Name = "Chleb Żytni", Quantity = 30, Weight = 500 });
    ryeBreadRepository.Add(new RyeBread { Name = "Chleb Farmerski", Quantity = 40, Weight = 750 });
    ryeBreadRepository.Add(new RyeBread { Name = "Chleb z Foremki", Quantity = 80, Weight = 450 });
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