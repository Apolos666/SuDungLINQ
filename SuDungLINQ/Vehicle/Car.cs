namespace SuDungLINQ.Vehicle;

public class Car : Vehicle
{
    public string Manufacturer { get; set; }

    public Car(string name, int year, double price, string manufacturer) : base(name, year, price)
    {
        Manufacturer = manufacturer;
    }
}

