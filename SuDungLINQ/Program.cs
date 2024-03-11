// See https://aka.ms/new-console-template for more information

using SuDungLINQ.Employee;
using SuDungLINQ.Vehicle;

internal class Program
{
    // private static List<Car> cars = new()
    // {
    //     new Car("Toyota Corolla", 2023, 300000, "Toyota"),
    //     new Car("Toyota 2019", 2019, 230000, "Toyota"),
    //     new Car("Honda Civic", 2022, 180000, "Honda"),
    //     new Car("Ford Focus", 2021, 120000, "Ford"),
    //     new Car("Ford 2021", 2021, 340000, "Ford"),
    //     new Car("Mazda3", 1980, 130000, "Mazda"),
    //     new Car("BMW 3 Series", 2019, 80000, "BMW"),
    // };
    //
    // private static List<Truck> trucks = new()
    // {
    //     new Truck("Ford F-150", 2023, 300000, "Ford"),
    //     new Truck("Chevrolet Silverado", 2022, 280000, "Chevrolet"),
    //     new Truck("Ram 1500", 2021, 270000, "Ram"),
    //     new Truck("Toyota Tundra", 2020, 250000, "Toyota"),
    //     new Truck("GMC Sierra", 2019, 240000, "GMC"),
    // };

    private static List<Department> departments = new()
    {
        new Department(1, "Chung co Hoa Hoa Tham"),
        new Department(2, "Chung co Cau Rong")
    };

    private static List<Employee> employees = new()
    {
        new Employee(1, 18, 800000, new DateTime(2003, 02, 02), 1),
        new Employee(2, 18, 500000, new DateTime(2003, 03, 02), 2),
        new Employee(3, 18, 850000, new DateTime(2003, 04, 02), 1),
        new Employee(4, 18, 900000, new DateTime(2003, 05, 02), 1),
        new Employee(5, 20, 200000, new DateTime(2001, 06, 02), 2),
    };
    
    public static void Main(string[] args)
    {
        #region "BT LINQ JOIN"

        var maxSalary = employees.Max(e => e.Salary);
        Console.WriteLine($"Max salary: {maxSalary}");
        
        var minSalary = employees.Min(e => e.Salary);
        Console.WriteLine($"minSalary: {minSalary}");
        
        var averageSalary = employees.Average(e => e.Salary);
        Console.WriteLine($"averageSalary: {averageSalary}");
        
        
        var innerJoin = employees.Join(
            departments,
            e => e.DepartmentId,
            d => d.Id,
            (e, d) => new
            {
                EmployeeId = e.Id,
                DepartmentName = d.DepName
            }).ToList();
        
        Console.WriteLine("\nInner Join:");
        innerJoin.ForEach(j => Console.WriteLine($"EmployeeId: {j.EmployeeId}, DepartmentName: {j.DepartmentName}"));
        
        // Group Join
        var groupJoin = departments.GroupJoin(
            employees,
            d => d.Id,
            e => e.DepartmentId,
            (d, eGroup) => new
            {
                DepartmentName = d.DepName,
                Employees = eGroup
            });
        
        Console.WriteLine("\nGroup Join:");
        foreach (var item in groupJoin)
        {
            Console.WriteLine($"DepartmentName: {item.DepartmentName}");
            foreach (var employee in item.Employees)
            {
                Console.WriteLine($"   EmployeeId: {employee.Id}");
            }
        }
        
        // Left Join
        var leftJoin = from e in employees
            join d in departments on e.DepartmentId equals d.Id into edGroup
            from d in edGroup.DefaultIfEmpty()
            select new
            {
                EmployeeId = e.Id,
                DepartmentName = d != null ? d.DepName : "No Department"
            };
        
        Console.WriteLine("\nLeft Join:");
        foreach (var item in leftJoin)
        {
            Console.WriteLine($"EmployeeId: {item.EmployeeId}, DepartmentName: {item.DepartmentName}");
        }
        
        // Right Join
        var rightJoin = from d in departments
            join e in employees on d.Id equals e.DepartmentId into deGroup
            from e in deGroup.DefaultIfEmpty()
            select new
            {
                EmployeeId = e != null ? e.Id : 0,
                DepartmentName = d.DepName
            };

        Console.WriteLine("\nRight Join:");
        foreach (var item in rightJoin)
        {
            Console.WriteLine($"EmployeeId: {item.EmployeeId}, DepartmentName: {item.DepartmentName}");
        }

        var oldestEmployee = employees.Min(e => e.Birthday);
        var MaxAgeEmployee = employees.FirstOrDefault(e => e.Birthday == oldestEmployee);
        Console.WriteLine($"\nmax Employee Age belong to id: {MaxAgeEmployee.Id}");
        
        var youngestEmployee = employees.Max(e => e.Birthday);
        var MinAgeEmployee = employees.FirstOrDefault(e => e.Birthday == youngestEmployee);
        Console.WriteLine($"min Employee Age belong to Id: {MinAgeEmployee.Id}");

        #endregion
        
        #region SuDungLinq

        // // 2a
        // var carsInPriceRange = cars
        //     .Where(c => c.Price >= 100000f && c.Price <= 250000f).ToList();
        // Console.WriteLine("2a - Car in price range 100000 - 250000:");
        // carsInPriceRange.ForEach(c=> Console.WriteLine($"Car name: {c.Name}, Price: {c.Price}"));
        //
        // // 2b
        // var carsAfter1990 = cars.Where(c => c.Year > 1990).ToList();
        // Console.WriteLine("2b - Car after 1990:");
        // carsAfter1990.ForEach(c => Console.WriteLine($"Car name: {c.Name}, Year: {c.Year}"));
        //
        // // 2c
        // var carsByManufacturer = cars
        //     .GroupBy(c => c.Manufacturer)
        //     .Select(g => new
        //     {
        //         Manufacturer = g.Key,
        //         Count = g.Count(),
        //         TotalPrice = g.Sum(c => c.Price)
        //     })
        //     .ToList();
        // Console.WriteLine("2c - Car by manufacturer:");
        // carsByManufacturer.ForEach(c => Console.WriteLine($"Manufacturer: {c.Manufacturer}, Count: {c.Count}, Total Price: {c.TotalPrice}"));
        //
        // // 3a
        // var sortedTrucksDesc = trucks.OrderByDescending(t => t.Year).ToList();
        // Console.WriteLine("3a - Truck sorted by year descending:");
        // sortedTrucksDesc.ForEach(t => Console.WriteLine($"Truck name: {t.Name}, Year: {t.Year}"));
        //
        // // 3b
        // Console.WriteLine($"3b - Truck Comapny name");
        // trucks.ForEach(t => Console.WriteLine($"Truck company: {t.Company}"));

        #endregion

        


    }
}