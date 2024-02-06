namespace BakerHouseApp;

public class AppXml : IApp
{
    private readonly IXmlCreator _xmlCreator;

    public AppXml(IXmlCreator xmlCreator)
    {
        _xmlCreator = xmlCreator;
    }

    public void Run()
    {
        _xmlCreator.CreateXml();
        _xmlCreator.CreateXmlCustomers();
        _xmlCreator.QueryXml();
        _xmlCreator.CreateXmlGroupJoined();
    }
}
