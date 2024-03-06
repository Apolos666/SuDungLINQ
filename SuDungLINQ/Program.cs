// See https://aka.ms/new-console-template for more information

using SuDungLINQ.Vehicle;

internal class Program
{
    private static List<Car> cars = new()
    {
        new Car("Toyota Corolla", 2023, 300000, "Toyota"),
        new Car("Toyota 2019", 2019, 230000, "Toyota"),
        new Car("Honda Civic", 2022, 180000, "Honda"),
        new Car("Ford Focus", 2021, 120000, "Ford"),
        new Car("Ford 2021", 2021, 340000, "Ford"),
        new Car("Mazda3", 1980, 130000, "Mazda"),
        new Car("BMW 3 Series", 2019, 80000, "BMW"),
    };
    
    private static List<Truck> trucks = new()
    {
        new Truck("Ford F-150", 2023, 300000, "Ford"),
        new Truck("Chevrolet Silverado", 2022, 280000, "Chevrolet"),
        new Truck("Ram 1500", 2021, 270000, "Ram"),
        new Truck("Toyota Tundra", 2020, 250000, "Toyota"),
        new Truck("GMC Sierra", 2019, 240000, "GMC"),
    };
    
    public static void Main(string[] args)
    {
        // 2a
        var carsInPriceRange = cars
            .Where(c => c.Price >= 100000f && c.Price <= 250000f).ToList();
        Console.WriteLine("2a - Car in price range 100000 - 250000:");
        carsInPriceRange.ForEach(c=> Console.WriteLine($"Car name: {c.Name}, Price: {c.Price}"));
        
        // 2b
        var carsAfter1990 = cars.Where(c => c.Year > 1990).ToList();
        Console.WriteLine("2b - Car after 1990:");
        carsAfter1990.ForEach(c => Console.WriteLine($"Car name: {c.Name}, Year: {c.Year}"));
        
        // 2c
        var carsByManufacturer = cars
            .GroupBy(c => c.Manufacturer)
            .Select(g => new
            {
                Manufacturer = g.Key,
                Count = g.Count(),
                TotalPrice = g.Sum(c => c.Price)
            })
            .ToList();
        Console.WriteLine("2c - Car by manufacturer:");
        carsByManufacturer.ForEach(c => Console.WriteLine($"Manufacturer: {c.Manufacturer}, Count: {c.Count}, Total Price: {c.TotalPrice}"));
        
        // 3a
        var sortedTrucksDesc = trucks.OrderByDescending(t => t.Year).ToList();
        Console.WriteLine("3a - Truck sorted by year descending:");
        sortedTrucksDesc.ForEach(t => Console.WriteLine($"Truck name: {t.Name}, Year: {t.Year}"));
        
        // 3b
        Console.WriteLine($"3b - Truck Comapny name");
        trucks.ForEach(t => Console.WriteLine($"Truck company: {t.Company}"));
    }
}