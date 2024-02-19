using BakerHouseApp.ApplicationServices.Components.CsvReader;
using BakerHouseApp.ApplicationServices.Components.CsvReader.Models;

namespace BakerHouseApp.ApplicationServices.Components.DataProvider;

public class CsvProvider : ICsvProvider
{
    private readonly ICsvReader _csvReader;

    public CsvProvider(ICsvReader csvReader)
    {
        _csvReader = csvReader;
    }

    public void DataFromCsvFile()
    {
        var assortments = _csvReader.ProcessAssortments(@"Resources\Files\asortyment.csv");
        var states = _csvReader.ProcessStates(@"Resources\Files\stany.csv");
        var customers = _csvReader.ProcessCustomers(@"Resources\Files\customer.csv");

        // Advanced LINQ Methods
        GroupByAssortments(assortments);
        JoinAssortmentsAndStates(assortments, states);
        GroupJoinAssortmentsAndStatesByIdAso(assortments, states);
    }

    private static void GroupByAssortments(List<Assortment> assortments)
    {
        var groups = assortments
            .GroupBy(assortment => assortment.ID_PROD)
            .Select(g => new
            {
                NAZWA = g.Key,
                Max = g.Max(assortment => assortment.CENA_NETTO),
                Average = g.Average(assortment => assortment.CENA_NETTO)
            })
            .OrderBy(assortment => assortment.Average);

        foreach (var group in groups)
        {
            Console.WriteLine($"\n{group.NAZWA}");
            Console.WriteLine($"\t Max: {group.Max}");
            Console.WriteLine($"\t Avg: {group.Average}");
        }
    }

    private static void JoinAssortmentsAndStates(List<Assortment> assortments, List<States> states)
    {
        var assortmentInProducent = assortments.Join(
            states,
            x => x.ID_PROD,
            x => x.ID_PROD,
            (assortment, states) =>
                new
                {
                    states.ID_JED,
                    assortment.CENA_NETTO,
                    assortment.NAZWA,
                })
            .OrderByDescending(x => x.ID_JED)
            .ThenBy(x => x.NAZWA);

        foreach (var assortment in assortmentInProducent)
        {
            Console.WriteLine($"\n ID_PROD: {assortment.ID_JED}");
            Console.WriteLine($"\t CENA NETTO: {assortment.CENA_NETTO}");
            Console.WriteLine($"\t NAZWA: {assortment.NAZWA}");
        }
    }

    private static void GroupJoinAssortmentsAndStatesByIdAso(List<Assortment> assortments, List<States> states)
    {
        var groups = states.GroupJoin(
            assortments,
           state => state.ID_ASO,
            assortment => assortment.ID_ASO,
            (m, g) =>
            new
            {
                States = m,
                Assortment = g
            })
            .OrderBy(x => x.States.ID_PROD);

        foreach (var group in groups)
        {
            Console.WriteLine($"\n Manufacturer: {group.States.ID_PROD}");
            Console.WriteLine($"\t Cars: {group.Assortment.Count()}");
            Console.WriteLine($"\t Max: {group.Assortment.Max(x => x.CENA_NETTO)}");
            Console.WriteLine($"\t Min: {group.Assortment.Min(x => x.CENA_NETTO)}");
            Console.WriteLine($"\t Avg: {group.Assortment.Average(x => x.CENA_NETTO)}");
        }
    }
}