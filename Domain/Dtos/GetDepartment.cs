using Domain.Entities;
namespace Domain.Dtos;
public class GetDepartment
{
   public int Id { get; set; }
    public string? DepaartmentName { get; set; }
    public int ManagerId { get; set; }
    public int LocationId { get; set; }
}