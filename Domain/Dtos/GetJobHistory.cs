using Domain.Entities;
namespace Domain.Dtos;
public class GetJobHistory
{
   public int Id { get; set; }
   public int EmployeeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int JobId { get; set; }
    public string? DepartmentName { get; set; }
}