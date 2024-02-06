namespace BakerHouseApp.Components.CsvReader;

public interface ICsvReader
{
    List<States> ProcessStates(string filePath);

    List<Assortment> ProcessAssortments(string filePath);
    List<Customers> ProcessCustomers(string filePath);
}
