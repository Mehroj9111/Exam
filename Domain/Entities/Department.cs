using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public class Department
{
    [Key]
    public int DepartmentId { get; set; }
     [MaxLength(30)]
    public string? DepaartmentName { get; set; }
    public int ManagerId { get; set; }
    public  List<Employee>?  Employees { get; set; }
    public int LocationId { get; set; }
    public Location Locations { get; set; }
     public List<JobHistory>? JobHistories { get; set; }
}