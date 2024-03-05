namespace SuDungLINQ.Vehicle;

public class Vehicle
{
    public string Name { get; set; }
    public int Year { get; set; }
    public double Price { get; set; }

    public Vehicle(string name, int year, double price)
    {
        Name = name;
        Year = year;
        Price = price;
    }
}
