namespace BakerHouseApp.DataProvider;

internal interface IBreadProvider
{
    // SELECT
    decimal GetMaximumPriceOfAllBread();
    decimal GetMinimumPriceOfAllBread();
    List<WheatBread> GetSpecificColumns();
    List<string> GetUniqueBreadColors();
    string AnonymousClass();

    // ORDER BY
    List<WheatBread> OrderByNameAndCalories();
    List<WheatBread> OrderByName();
    List<WheatBread> OrderByNameDescending();
    List<WheatBread> OrderByColorAndName();
    List<WheatBread> OrderByColorAndNameDesc();
 
    // WHERE
    List<WheatBread> WhereStartsWith(string prefix);
    List<WheatBread> WhereStartsWithAndPriceIsGreaterThan(string prefix, decimal price);
    List<WheatBread> WhereColorIs(string color);
    List<WheatBread> WhereStartsWithAndCostIsGreaterThan(string prefix, decimal cost);

    // FIRST, LAST, SINGLE
    WheatBread SingleById(int id);
    WheatBread SingleOrDefaultById(int id);
    WheatBread FirstByColor(string color);
    WheatBread? FirstOrDefaultByColor(string color);
    WheatBread FirstOrDefaultByColorWithDefault(string color);
    WheatBread LastByColor(string color);

    // TAKE
    List<WheatBread> TakeWheatBread(int howMany);
    List<WheatBread> TakeWheatBread(Range range);
    List<WheatBread> TakeWheatBreadWhileExpirationDate(DateTime date);
    List<WheatBread> TakeWheatBreadWhileNameStartsWith(string prefix);

     // SKIP
    List<WheatBread> SkipWheatBread(int howMany);
    List<WheatBread> SkipPlayersWhileExpirationDate(DateTime date);
    List<WheatBread> SkipWheatBreadWhileNameStartsWith(string prefix);
 
     // DISTINCT
    List<double> DistinctAllCalories();
    List<WheatBread> DistinctByCalories();
    List<string> DistinctAllColors();
    List<WheatBread> DistinctByColors();

    // CHUNK
    List<WheatBread[]> ChunkPlayers(int size);
}

