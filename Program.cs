using BakerHouseApp;
using BakerHouseApp.Entities;
using BakerHouseApp.Repositores;
using BakerHouseApp.Data;
using BakerHouseApp.Repositores.Extensions;
using System.ComponentModel.Design;


var typeWheatBread = new SqlRepository<WheatBread>(new BakerHouseAppDbContext());
var typeRyeBread = new SqlRepository<RyeBread>(new BakerHouseAppDbContext());
var typeToFileWheatBread = new RepositoryToFileJson<WheatBread>();
var typeToFileRyeBread = new RepositoryToFileJson<RyeBread>();


while (true)
{
    Console.WriteLine("Hello User.");
    Console.WriteLine("Choose option");
    Console.WriteLine("Press 1 to Add Wheat Bread product");
    Console.WriteLine("Press 2 to Add Rye Bread product");
    Console.WriteLine("Press 3 to show all Breads in memory");
    Console.WriteLine("Press 4 to show all Breads from in file");
    Console.WriteLine("Press 5 to delete Rye Breads from file");
    Console.WriteLine("To exit insert 'x' ");
    Console.WriteLine("Choose option again.");
    var userInPut = Console.ReadLine();
    try
    {
        switch (userInPut)
        {
            case "1":
                Console.WriteLine("Press information to Add Wheat Breads");
                Console.WriteLine("*************************************");

                Console.WriteLine("Insert name");
                var nameWheatBread = Console.ReadLine();

                Console.WriteLine("Insert Quantity");
                var quantityWheatBread = Console.ReadLine();
                int quantityWheatBreadInt = AddInt(quantityWheatBread);

                Console.WriteLine("Insert Weight");
                var weightWheatBread = Console.ReadLine();
                double weightWheatBreadInt = AddInt(weightWheatBread);

                typeWheatBread.Add(new WheatBread { Data = DateTime.Now, Name = nameWheatBread, Quantity = quantityWheatBreadInt, Weight = weightWheatBreadInt });
                typeToFileWheatBread.Add(new WheatBread { Data = DateTime.Now, Name = nameWheatBread, Quantity = quantityWheatBreadInt, Weight = weightWheatBreadInt });
                typeWheatBread.Save();
                Console.WriteLine("Success");
                Console.WriteLine("Do you want save insert Whead Breads ?");
                Console.WriteLine("Insert Y - Yes, N - No.");

                var userChosse = Console.ReadLine();
                if (userChosse == "Y" || userChosse == "y")
                {
                    typeToFileWheatBread.SaveWheatBread();
                }
                else if (userChosse == "N" || userChosse == "n")
                {
                    Console.WriteLine("Okey, program doesn't save Breads ?");
                }
                else
                {
                    throw new Exception("Incorrect chose");
                }

                break;

            case "2":
                Console.WriteLine("Press information to add Rye Breads");
                Console.WriteLine("*************************************");

                Console.WriteLine("Insert name");
                var nameRyeBread = Console.ReadLine();

                Console.WriteLine("Insert Quantity");
                var quantityRyeBread = Console.ReadLine();
                int quantityRyeBreadInt = AddInt(quantityRyeBread);

                Console.WriteLine("Insert Weight");
                var weightRyeBread = Console.ReadLine();
                double weightRyeBreadInt = AddInt(weightRyeBread);

                typeRyeBread.Add(new RyeBread { Data = DateTime.Now, Name = nameRyeBread, Quantity = quantityRyeBreadInt, Weight = weightRyeBreadInt });
                typeToFileRyeBread.Add(new RyeBread { Data = DateTime.Now,Name = nameRyeBread, Quantity = quantityRyeBreadInt, Weight = weightRyeBreadInt });
                typeRyeBread.Save();
                Console.WriteLine("Success");
                Console.WriteLine("Do you want save insert rye Breads ?");
                Console.WriteLine("Insert Y - Yes, N - No.");

                var userChosse1 = Console.ReadLine();
                if (userChosse1 == "Y" || userChosse1 == "y")
                {

                    typeToFileRyeBread.SaveRyeBread();
                }
                else if (userChosse1 == "N" || userChosse1 == "n")
                {
                    Console.WriteLine("Okey, program doesn't save Rye Breads ?");
                }
                else
                {
                    throw new Exception("Incorrect chose ");
                }

                break;
            case "3":
                typeWheatBread.WriteAllToConsole(typeWheatBread);
                typeRyeBread.WriteAllToConsole(typeRyeBread);

                break;
            case "4":
                typeToFileWheatBread.WriteAllConsoleFromFileWheatBread(typeToFileWheatBread);
                typeToFileRyeBread.WriteAllConsoleFromFileRyeBread(typeToFileRyeBread);

                break;
            case "5":
                Console.WriteLine("Which name Bread you want delete ?");
                Console.WriteLine("Enter the Id of user you want to delete");
                try
                {
                  //
                }
                catch
                {
                    Console.WriteLine("wrong option");
                }
                break;
            case "x":
            case "X":
                return;
            default:
                Console.WriteLine("Invalid operation");
                break;
        }
    }
    catch (Exception e)
    {
        Console.WriteLine($"Exception caught: {e.Message}");
    }

    static int AddInt(string value)
    {
        if (int.TryParse(value, out int number))
        {
            Console.WriteLine("The conversion success.");
        }
        else
        {
            Console.WriteLine("The conversion wasn't successful.");
        }
        return number;
    }

}