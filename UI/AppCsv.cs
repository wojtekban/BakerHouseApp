namespace BakerHouseApp.UI;

public class AppCsv : IApp
{
    private readonly ICsvProvider _csvProvider;

    public AppCsv(ICsvProvider csvProvider)
    {
        _csvProvider = csvProvider;
    }

    public void Run()
    {
        _csvProvider.DataFromCsvFile();
    }
}
