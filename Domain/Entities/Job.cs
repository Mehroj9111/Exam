using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public class Job
{
    [Key]
    public int JobId { get; set; }
     [MaxLength(35)]
    public string? JobTitle { get; set; }
    public int MinSalary { get; set; }
    public int MaxSalary { get; set; }
    public List<JobHistory>? JobHistories { get; set; }
    public List<Employee>? Employees{get; set;}
}