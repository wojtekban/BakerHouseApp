
namespace BakerHouseApp.Data.Entities;

public class Customer: EntityBase
{
    public string CustName { get; set; }
    public string AddressStreet { get; set; }
    public string AddressCityName { get; set; }
    public decimal AddressZipCode { get; set; }
    public decimal NipNum { get; set; }
   
    public override string ToString()
    {
        StringBuilder sb = new();

        sb.AppendLine($"Id. {Id}");
        sb.AppendLine($"    CustName: {CustName}");
        sb.AppendLine($"    AddressStreet: {AddressStreet}");
        sb.AppendLine($"    AddressCityName: {AddressCityName} AddressZipCode: {AddressZipCode}");
        sb.AppendLine($"    NipNum: {NipNum}");
      
        return sb.ToString();
    }


    //public override string ToString() => $"Id: {Id}, CustName: {CustName}, AddressStreet: {AddressStreet}, AddressCityName: {AddressCityName}, AddressZipCode: {AddressZipCode}, NipNum: {NipNum}";
}
