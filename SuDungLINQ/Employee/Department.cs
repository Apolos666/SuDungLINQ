namespace SuDungLINQ.Employee;

public class Department
{
    public int Id { get; set; }
    public string DepName { get; set; }

    public Department(int id, string depName)
    {
        Id = id;
        DepName = depName;
    }
}