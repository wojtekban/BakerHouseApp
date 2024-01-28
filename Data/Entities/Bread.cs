namespace BakerHouseApp.Data.Entities;

public class Bread : EntityBase
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public double Weight { get; set; }
    public DateTime Date { get; set; }
    public DateTime ExpirationDate { get; set; }
    public DateTime DateOfProduction { get; set; }
    public double Calories { get; set; }
    public decimal StandardCost { get; set; }
    public decimal Price { get; set; }
    public string? Color { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new();

        sb.AppendLine($"Id. {Id}");
        sb.AppendLine($"    Name: {Name}   Quantity Bread: {Quantity} szt.");
        sb.AppendLine($"    Weight: {Weight} g    Data Change: {Date}    Expiration Date Bread: {ExpirationDate}");
        sb.AppendLine($"    Date Of Production: {DateOfProduction}     Calories: {Calories} KCAL");
        sb.AppendLine($"    StandarCost: {StandardCost}$     Price: {Price}$");
        sb.Append($"    Color: {Color}");

        return sb.ToString();
    }
}


// public override string ToString() => $"Id: {Id}, Data zmian: {Data}, Nazwa pieczywa: {Name}, Ilość pieczywa: {Quantity},  Waga pieczywa: {Weight}g ";

