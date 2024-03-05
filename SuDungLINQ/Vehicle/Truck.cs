namespace SuDungLINQ.Vehicle;

public class Truck : Vehicle
{
    public string Company { get; set; }

    public Truck(string name, int year, double price, string company) : base(name, year, price)
    {
        Company = company;
    }
}