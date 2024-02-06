namespace BakerHouseApp.Components.CsvReader.Extensions;

public static class AssortmentExtensions
{
    public static IEnumerable<Assortment> ToAssortment(this IEnumerable<string> source)
    {
        foreach (var line in source)
        {
            var columns = line.Split(';');

            yield return new Assortment
            {
                ID_ASO = columns[0],
                EAN = int.Parse(columns[1]),
                NAZWA = columns[2],
                ID_WALUTA = columns[3], //CultureInfo.InvariantCulture),
                CENA_NETTO = decimal.Parse(columns[4]),
                VAT = int.Parse(columns[5]),
                ID_JED = columns[6],
                ID_PROD = columns[7],
            };
        }
    }
}
