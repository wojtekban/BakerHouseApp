
using System.Xml.Linq;

namespace BakerHouseApp.Services;

public class QueryInfoProvider : UserCommunicationBase, IQueryInfoProvider
{
    private readonly IBreadProvider _breadProvider;

    public QueryInfoProvider(IBreadProvider breadProvider)
    {
        _breadProvider = breadProvider;
    }

    public void GetQueryInfo()
    {
        bool closeLoop = false;

        while (!closeLoop)
        {
            Console.WriteLine();
            WritelineColor(
                "--- WHAT KIND OF INFORMATION YOU WANT TO VIEW ---\n" +
                "1 - Get unique <Bread Type>\n" +
                "2 - Get max <Price Bread>\n" +
                "3 - Get min <Price Bread>\n" +
                "4 - Order By <Name Calories>\n" +
                "5 - Order By <Type Name>\n" +
                "6 - Order By Cust <Name>\n" +
                "X - Back to MAIN MENU\n", ConsoleColor.DarkCyan);
            
            var userInput = GetInputFromUser("What you want to do? \nPress key 1, 2, 3, 4, 5, 6, 7, 8, 9 or X: ").ToUpper();

            switch (userInput)
            {
                case "1": // Get unique <Nationalities>
                    GetUniqueBreadType();
                    break;

                case "2": // Get max <Price Bread>
                    GetMaximumPriceOfAllBread();
                    break;

                case "3": // Get min <Price Bread>
                    GetMinimumPriceOfAllBread();
                    break;

                case "4": // Order By <Name Calories>
                    OrderByNameAndCalories();
                    break;

                case "5": // Order By <Type Name>
                    OrderByTypeAndName();
                    break;

                case "6": // Order By Cust <Name>
                    OrderByCustName();
                    break;

                case "X":
                   closeLoop = true;
                    break;

                default:
                    WritelineColor("Invalid operation.\n", ConsoleColor.Red);
                    continue;
            }
        }
    }

    private void OrderByCustName()
    {
        WritelineColor("Order Cust by <Name>", ConsoleColor.DarkCyan);
        var orderByCustName = _breadProvider.OrderByCustName();
        foreach (var custBreads in orderByCustName)
        {
            Console.WriteLine(custBreads);
        }
    }
    private void OrderByTypeAndName()
    {
        WritelineColor("Order Bread by <Type and Name>", ConsoleColor.DarkCyan);
        var orderByTypeAndName = _breadProvider.OrderByTypeAndName();
        foreach (var breads in orderByTypeAndName)
        {
            Console.WriteLine(breads);
        }
    }

    private void OrderByNameAndCalories()
    {
        WritelineColor("Order Bread by <Name Calories>", ConsoleColor.DarkCyan);
        var orderByNameAndCalories = _breadProvider.OrderByNameAndCalories();
        foreach (var breads in orderByNameAndCalories)
        {
            Console.WriteLine(breads);
        }
    }

    private void GetMinimumPriceOfAllBread()
    {
        WritelineColor("Min <Price Bread>:", ConsoleColor.DarkCyan);
        Console.WriteLine($"\nMinimum Price Bread: {_breadProvider.GetMinimumPriceOfAllBread().ToString("##,##", new NumberFormatInfo() { NumberGroupSeparator = " " })} $");
    }

    private void GetMaximumPriceOfAllBread()
    {
        WritelineColor("Max <Price Bread>:", ConsoleColor.DarkCyan);
        Console.WriteLine($"\nMaximum Price Bread: {_breadProvider.GetMaximumPriceOfAllBread().ToString("##,##", new NumberFormatInfo() { NumberGroupSeparator = " " })} $");
    }

    private void GetUniqueBreadType()
    {
        WritelineColor("Unique <Bread Type>:", ConsoleColor.DarkCyan);
        Console.ResetColor();
        var types = _breadProvider.GetUniqueBreadType();
        foreach (var type in types)
        {
            Console.WriteLine(type);
        }
    }
}
