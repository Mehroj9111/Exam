using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Domain.Entities;
public class Employee
{
    [Key]
    public int EmployeeId { get; set; }
     [MaxLength(20)]
    public string? FirstName { get; set; }
     [MaxLength(25)]
    public string? LastName { get; set; }
     [MaxLength(25)]
    public string? Email { get; set; }
     [MaxLength(20)]
    public string? PhoneNumber { get; set; }
    public DateTime HeirDate { get; set; }
    public int JobId { get; set; }
    public virtual Job?  Jobs { get; set; }
    public int Salary { get; set; }
    public int CommissionPct { get; set; }
    public int ManagerId { get; set; }
    public Employee? Manager { get; set; }
    [NotMapped]
     public IFormFile ? File { get; set; }
     public string? FileName { get; set; }
    public int DepartmentId { get; set; }
    public virtual Department? Depaartments { get; set; }
    public List<JobHistory>? JobHistories{ get; set; }
    

}