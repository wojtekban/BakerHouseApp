namespace BakerHouseApp.ApplicationServices.Services;

public abstract class DataGeneration : IDataGeneration
{
    public abstract void ViewDataSourceInfo();
    public abstract void AddBread();
    public abstract void AddCustomer();

    protected IEnumerable<Bread> GetBread()
    {
        var Bread = new List<Bread>()
        {
                new Bread()
                {
                        Name = "Baltonowski",
                        Quantity = 5,
                        Weight = 500,
                        Date = new DateTime(2025, 06, 30),
                        ExpirationDate = new DateTime(2024, 02, 10),
                        DateOfProduction = new DateTime(2024, 02, 05),
                        Calories = 1500,
                        StandardCost = 5.50M,
                        Price = 8.00M,
                        Type = "Wheat",
                },
                new Bread()
                {
                        Name = "Na maslance",
                        Quantity = 3,
                        Weight = 450,
                        Date = new DateTime(2024, 02, 01),
                        ExpirationDate = new DateTime(2024, 02, 5),
                        DateOfProduction = new DateTime(2024, 02, 10),
                        Calories = 1300,
                        StandardCost = 6.50M,
                        Price = 8.50M,
                        Type = "Wheat",
                },
                new Bread()
                {
                        Name = "Dwarski",
                        Quantity = 10,
                        Weight = 440,
                        Date = new DateTime(2024, 02, 02),
                        ExpirationDate = new DateTime(2024, 02, 6),
                        DateOfProduction = new DateTime(2024, 02, 11),
                        Calories = 1200,
                        StandardCost = 9.50M,
                        Price = 10.50M,
                        Type = "Wheat",
                },
                new Bread()
                {
                        Name = "Rustykalny",
                        Quantity = 8,
                        Weight = 550,
                        Date = new DateTime(2024, 02, 03),
                        ExpirationDate = new DateTime(2024, 02, 7),
                        DateOfProduction = new DateTime(2024, 02, 15),
                        Calories = 1600,
                        StandardCost = 9.50M,
                        Price = 11.50M,
                        Type = "Wheat",
                },
                new Bread()
                {
                        Name = "Wieloziarnisty",
                        Quantity = 7,
                        Weight = 350,
                        Date = new DateTime(2024, 02, 04),
                        ExpirationDate = new DateTime(2024, 02, 7),
                        DateOfProduction = new DateTime(2024, 02, 12),
                        Calories = 980,
                        StandardCost = 4.50M,
                        Price = 6.50M,
                        Type = "Wheat",
                },
                new Bread()
                {
                        Name = "Firmowy",
                        Quantity = 5,
                        Weight = 500,
                        Date = new DateTime(2025, 06, 30),
                        ExpirationDate = new DateTime(2024, 02, 10),
                        DateOfProduction = new DateTime(2024, 02, 05),
                        Calories = 1500,
                        StandardCost = 5.50M,
                        Price = 8.00M,
                        Type = "Rye",
                },
                new Bread()
                {
                        Name = "Słonecznikowy",
                        Quantity = 3,
                        Weight = 450,
                        Date = new DateTime(2024, 02, 01),
                        ExpirationDate = new DateTime(2024, 02, 5),
                        DateOfProduction = new DateTime(2024, 02, 10),
                        Calories = 1300,
                        StandardCost = 6.50M,
                        Price = 8.50M,
                        Type = "Rye",
                },
                new Bread()
                {
                        Name = "Pasterski",
                        Quantity = 10,
                        Weight = 440,
                        Date = new DateTime(2024, 02, 02),
                        ExpirationDate = new DateTime(2024, 02, 6),
                        DateOfProduction = new DateTime(2024, 02, 11),
                        Calories = 1200,
                        StandardCost = 9.50M,
                        Price = 10.50M,
                        Type = "Rye",
                },
                new Bread()
                {
                        Name = "Śniadaniowy",
                        Quantity = 8,
                        Weight = 550,
                        Date = new DateTime(2024, 02, 03),
                        ExpirationDate = new DateTime(2024, 02, 7),
                        DateOfProduction = new DateTime(2024, 02, 15),
                        Calories = 1600,
                        StandardCost = 9.50M,
                        Price = 11.50M,
                        Type = "Rye",
                },
                new Bread()
                {
                        Name = "Nadworny",
                        Quantity = 7,
                        Weight = 350,
                        Date = new DateTime(2024, 02, 04),
                        ExpirationDate = new DateTime(2024, 02, 7),
                        DateOfProduction = new DateTime(2024, 02, 12),
                        Calories = 980,
                        StandardCost = 4.50M,
                        Price = 6.50M,
                        Type = "Rye",
                }

        };
        return Bread;
    }
    protected IEnumerable<Customer> GetCustomer()
    {
        var Customer = new List<Customer>()
        {
                new Customer()
                {
                        CustName = "SPP Toruńska",
                        AddressStreet = "torunska",
                        AddressCityName = "Grudziądz",
                        AddressZipCode = 86300M,
                        NipNum = 8791592124M,
                }


        };
        return Customer;
    }
}