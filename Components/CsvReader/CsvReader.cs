namespace BakerHouseApp.Components.CsvReader;

internal class CsvReader : ICsvReader
{
    public List<Assortment> ProcessAssortments(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<Assortment>();
        }

        var assortments =
            File.ReadAllLines(filePath)
            .Skip(1)
            .Where(line => line.Length > 1)
            .ToAssortment();

        return assortments.ToList();
    }

    public List<States> ProcessStates(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<States>();
        }

        var states = File.ReadAllLines(filePath)
            .Skip(1)
            .Where(line => line.Length > 1)
            .Select(line =>
            {
                var columns = line.Split(';');
                return new States()
                {
                    ID_ASO = columns[0],
                    DATA_STANU = DateTime.Parse(columns[1]),
                    STAN = decimal.Parse(columns[2]),
                    ID_JED = columns[3],
                    ID_PROD = columns[4],
                    WART_NETTO = decimal.Parse(columns[5]),
                    ID_WALUTA = columns[6]
                };
            });

        return states.ToList();
    }

    public List<Customers> ProcessCustomers(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<Customers>();
        }

        var customers = File.ReadAllLines(filePath)
            .Skip(1)
            .Where(line => line.Length > 1)
            .Select(line =>
            {
                var columns = line.Split(';');
                return new Customers()
                {
                    ID_PLT = int.Parse(columns[0]),
                    NAZWA = columns[1],
                    ID_KRAJ = columns[2],
                    MIASTO = columns[3],
                    KOD = columns[4],              
                    ULICA = columns[5],
                    NR_LOK = columns[6],
                    NIP = decimal.Parse(columns[7])
                    
                };
            });

        return customers.ToList();
    }
}