namespace BakerHouseApp.Components.CsvReader.Models;

public class Assortment
{
    public string ID_ASO { get; set; }
    public double EAN { get; set; }
    public string NAZWA { get; set; }
    public string ID_WALUTA { get; set; }
    public decimal CENA_NETTO { get; set; }
    public int VAT { get; set; }
    public string ID_JED { get; set; }
    public string? ID_PROD { get; set; }
}