namespace BakerHouseApp.Services;

public abstract class DataGenerator : IDataGenerator
{
    public abstract void ViewDataSourceInfo();
    public abstract void AddWheatBread();
    public abstract void AddRyeBread();

    protected IEnumerable<WheatBread> GetWheatBread()
    {
        var wheatBread = new List<WheatBread>()
        {
                new WheatBread()
                {
                        Id = 1,
                        Name = "Baltonowski",
                        Quantity = 5,
                        Weight = 500,
                        Date = new DateTime(2025, 06, 30),
                        ExpirationDate = new DateTime(2024, 02, 10),
                        DateOfProduction = new DateTime(2024, 02, 05),
                        Calories = 1500,
                        StandardCost = 5.50M,
                        Price = 8.00M,
                        Color = "Gold",
                },
                new WheatBread()
                {
                        Id = 2,
                        Name = "Na maslance",
                        Quantity = 3,
                        Weight = 450,
                        Date = new DateTime(2024, 02, 01),
                        ExpirationDate = new DateTime(2024, 02, 5),
                        DateOfProduction = new DateTime(2024, 02, 10),
                        Calories = 1300,
                        StandardCost = 6.50M,
                        Price = 8.50M,
                        Color = "Brown",
                },
                new WheatBread()
                {
                        Id = 3,
                        Name = "Dwarski",
                        Quantity = 10,
                        Weight = 440,
                        Date = new DateTime(2024, 02, 02),
                        ExpirationDate = new DateTime(2024, 02, 6),
                        DateOfProduction = new DateTime(2024, 02, 11),
                        Calories = 1200,
                        StandardCost = 9.50M,
                        Price = 10.50M,
                        Color = "Light gold",
                },
                new WheatBread()
                {
                        Id = 4,
                        Name = "Rustykalny",
                        Quantity = 8,
                        Weight = 550,
                        Date = new DateTime(2024, 02, 03),
                        ExpirationDate = new DateTime(2024, 02, 7),
                        DateOfProduction = new DateTime(2024, 02, 15),
                        Calories = 1600,
                        StandardCost = 9.50M,
                        Price = 11.50M,
                        Color = "Gold",
                },
                new WheatBread()
                {
                        Id = 5,
                        Name = "Wieloziarnisty",
                        Quantity = 7,
                        Weight = 350,
                        Date = new DateTime(2024, 02, 04),
                        ExpirationDate = new DateTime(2024, 02, 7),
                        DateOfProduction = new DateTime(2024, 02, 12),
                        Calories = 980,
                        StandardCost = 4.50M,
                        Price = 6.50M,
                        Color = "Brown",
                }

        };
                 return wheatBread;
    }
    protected IEnumerable<RyeBread> GetRyeBread()
    {
        var ryeBread = new List<RyeBread>()
        {
                new RyeBread()
                {
                        Id = 1,
                        Name = "Firmowy",
                        Quantity = 5,
                        Weight = 500,
                        Date = new DateTime(2025, 06, 30),
                        ExpirationDate = new DateTime(2024, 02, 10),
                        DateOfProduction = new DateTime(2024, 02, 05),
                        Calories = 1500,
                        StandardCost = 5.50M,
                        Price = 8.00M,
                        Color = "Gold",
                },
                new RyeBread()
                {
                        Id = 2,
                        Name = "Słonecznikowy",
                        Quantity = 3,
                        Weight = 450,
                        Date = new DateTime(2024, 02, 01),
                        ExpirationDate = new DateTime(2024, 02, 5),
                        DateOfProduction = new DateTime(2024, 02, 10),
                        Calories = 1300,
                        StandardCost = 6.50M,
                        Price = 8.50M,
                        Color = "Brown",
                },
                new RyeBread()
                {
                        Id = 3,
                        Name = "Pasterski",
                        Quantity = 10,
                        Weight = 440,
                        Date = new DateTime(2024, 02, 02),
                        ExpirationDate = new DateTime(2024, 02, 6),
                        DateOfProduction = new DateTime(2024, 02, 11),
                        Calories = 1200,
                        StandardCost = 9.50M,
                        Price = 10.50M,
                        Color = "Light gold",
                },
                new RyeBread()
                {
                        Id = 4,
                        Name = "Śniadaniowy",
                        Quantity = 8,
                        Weight = 550,
                        Date = new DateTime(2024, 02, 03),
                        ExpirationDate = new DateTime(2024, 02, 7),
                        DateOfProduction = new DateTime(2024, 02, 15),
                        Calories = 1600,
                        StandardCost = 9.50M,
                        Price = 11.50M,
                        Color = "Gold",
                },
                new RyeBread()
                {
                        Id = 5,
                        Name = "Nadworny",
                        Quantity = 7,
                        Weight = 350,
                        Date = new DateTime(2024, 02, 04),
                        ExpirationDate = new DateTime(2024, 02, 7),
                        DateOfProduction = new DateTime(2024, 02, 12),
                        Calories = 980,
                        StandardCost = 4.50M,
                        Price = 6.50M,
                        Color = "Brown",
                }

        };
        return ryeBread;
    }
}