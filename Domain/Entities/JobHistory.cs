using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public class JobHistory
{
     
    public int Id { get; set; }
    public int EmployeeId { get; set; }
     public virtual Employee ? Employees { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int JobId { get; set; }
    public virtual Job ? Jobs { get; set; }
    public int DepartmentId { get; set; }
    public virtual Department ? Departments { get; set; }

}