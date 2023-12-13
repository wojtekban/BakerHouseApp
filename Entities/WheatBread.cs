namespace BakerHouseApp.Entities
{
    public class WheatBread : EntityBase
    {
        public string? NameBread { get; set; }
        public string? QuantityBread { get; set; }
        public string? WeightBread { get; set; }


        public override string ToString() => $"Id: {Id}, Nazwa pieczywa: {NameBread}, Ilość pieczywa: {QuantityBread},  Waga pieczywa: {WeightBread}g";
    }
}