namespace BakerHouseApp.Entities
{
    public class Bread : EntityBase
    {
        public string? Name { get; set; }
        public int? Quantity { get; set; }
        public double? Weight { get; set; }


        public override string ToString() => $"Id: {Id}, Nazwa pieczywa: {Name}, Ilość pieczywa: {Quantity},  Waga pieczywa: {Weight}g";
    }
}