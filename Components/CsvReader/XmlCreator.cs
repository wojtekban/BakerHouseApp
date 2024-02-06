namespace BakerHouseApp.Components.CsvReader;

internal class XmlCreator : IXmlCreator
{
    private readonly ICsvReader _csvReader;

    public XmlCreator(ICsvReader csvReader)
    {
        _csvReader = csvReader;
    }

    public void CreateXml()
    {
        var recordAssortments = _csvReader.ProcessAssortments(@"Resources\Files\asortyment.csv");

        var document = new XDocument();
        var assortments = new XElement("Assortments", recordAssortments
            .Select(x =>
                new XElement("Assortments",
                    new XAttribute("ID_ASO", x.ID_ASO),
                    new XAttribute("EAN", x.EAN),
                    new XAttribute("NAZWA", x.NAZWA),
                    new XAttribute("ID_WALUTA", x.ID_WALUTA),
                    new XAttribute("CENA_NETTO", x.CENA_NETTO),
                    new XAttribute("VAT", x.VAT),
                    new XAttribute("ID_JED", x.ID_JED),
                    new XAttribute("ID_PROD", x.ID_PROD)
                    )
            ));

        document.Add(assortments);
        document.Save(@"Resources\Files\asortyment.xml");
        Console.WriteLine($"\nSaving file {"asortyment.xml"} succesfull!\n");
    }

    public void CreateXmlCustomers()
    {
        var recordCustomers = _csvReader.ProcessCustomers(@"Resources\Files\customer.csv");

        var document = new XDocument();
        var customers = new XElement("Customers", recordCustomers
            .Select(x =>
                new XElement("Customer",
                    new XAttribute("ID_PLT", x.ID_PLT),
                    new XAttribute("NAZWA", x.NAZWA),
                    new XAttribute("ID_KRAJ", x.ID_KRAJ),
                    new XAttribute("MIASTO", x.MIASTO),
                    new XAttribute("KOD", x.KOD),
                    new XAttribute("ULICA", x.ULICA),
                    new XAttribute("NUMER_LOK", x.NR_LOK),
                    new XAttribute("NIP", x.NIP)
                    )
            ));

        document.Add(customers);
        document.Save(@"Resources\Files\customers.xml");
        Console.WriteLine($"\nSaving file {"customers.xml"} succesfull!\n");
    }
    public void QueryXml()
    {
        var document = XDocument.Load(@"Resources\Files\asortyment.xml");
        var names = document
            .Element("Assortments")?
            .Elements("Assortment")
            .Where(x => x.Attribute("ID_PROD")?.Value == "NESTLE")
            .Select(x => x.Attribute("VAT")?.Value);

        if (names != null)

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        Console.WriteLine($"\nLoading file {"assortment.xml"} succesfull!\n");
    }

    public void CreateXmlGroupJoined()
    {
        var recordAssortments = _csvReader.ProcessAssortments(@"Resources\Files\asortyment.csv");
        var recordStates = _csvReader.ProcessStates(@"Resources\Files\stany.csv");

        var groupJoined = recordStates.GroupJoin(
            recordAssortments,
            states => states.ID_PROD,
            assortments => assortments.ID_PROD,
            (m, g) =>
            new
            {
                States = m,
                Assortments = g
            }

            )
            .OrderBy(x => x.States.ID_ASO);

        var document = new XDocument();

        var states = new XElement("States", groupJoined
        .Select(x =>
        new XElement("States",
            new XAttribute("ID_ASO", x.States.ID_ASO!),
            new XAttribute("STAN", x.States.STAN!),
                new XElement("Assortmemts",
                    new XAttribute("ID_PROD", x.States.ID_PROD!),
                    new XAttribute("CENA_NETTOSum", x.Assortments.Sum(c => c.CENA_NETTO)),
                        new XElement("Assortment", x.Assortments
                            .Select(c =>
                           new XElement("ASSORTMENTS",
                               new XAttribute("ID_ASO", c.NAZWA),
                               new XAttribute("EAN", c.EAN))))))));

        document.Add(states);
        document.Save(@"Resources\Files\assortment2.xml");

        Console.WriteLine($"Saving file {"assortment2.xml"} succesfull!");
    }
}
