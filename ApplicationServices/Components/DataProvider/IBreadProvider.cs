using BakerHouseApp.DataAccess.Data.Entities;

namespace BakerHouseApp.ApplicationServices.Components.DataProvider;

public interface IBreadProvider
{
    // SELECT
    decimal GetMaximumPriceOfAllBread();
    decimal GetMinimumPriceOfAllBread();
    List<Bread> GetSpecificColumns();
    List<Customer> GetSpecificCustomerColumns();
    List<string> GetUniqueBreadType();
    string AnonymousClass();

    // ORDER BY
    List<Bread> OrderByNameAndCalories();
    List<Bread> OrderByName();
    List<Customer> OrderByCustomerName();
    List<Bread> OrderByNameDescending();
    List<Bread> OrderByTypeAndName();
    List<Bread> OrderByTypeAndNameDesc();

    // WHERE
    List<Bread> WhereStartsWith(string prefix);
    List<Bread> WhereStartsWithAndPriceIsGreaterThan(string prefix, decimal price);
    List<Bread> WhereTypeIs(string type);
    List<Bread> WhereStartsWithAndCostIsGreaterThan(string prefix, decimal cost);

    // FIRST, LAST, SINGLE
    Bread SingleById(int id);
    Bread SingleOrDefaultById(int id);
    Bread FirstByType(string color);
    Bread? FirstOrDefaultByType(string type);
    Bread FirstOrDefaultByTypeWithDefault(string type);
    Bread LastByType(string type);

    // TAKE
    List<Bread> TakeBread(int howMany);
    List<Bread> TakeBread(Range range);
    List<Bread> TakeBreadWhileExpirationDate(DateTime date);
    List<Bread> TakeBreadWhileNameStartsWith(string prefix);

    // SKIP
    List<Bread> SkipBread(int howMany);
    List<Bread> SkipPlayersWhileExpirationDate(DateTime date);
    List<Bread> SkipBreadWhileNameStartsWith(string prefix);

    // DISTINCT
    List<double> DistinctAllCalories();
    List<Bread> DistinctByCalories();
    List<string> DistinctAllType();
    List<Bread> DistinctByType();

    // CHUNK
    List<Bread[]> ChunkPlayers(int size);
}

