namespace SuDungLINQ.Employee;

public class Employee
{
    public int Id { get; set; }
    public int Age { get; set; }
    public decimal Salary { get; set; }
    public DateTime Birthday { get; set; }
    public int DepartmentId { get; set; }
    
    public Employee(int id, int age, decimal salary, DateTime birthday, int departmentId)
    {
        Id = id;
        Age = age;
        Salary = salary;
        Birthday = birthday;
        DepartmentId = departmentId;
    }
}