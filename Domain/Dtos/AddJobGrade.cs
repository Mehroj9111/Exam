using Domain.Entities;
namespace Domain.Dtos;
public class AddJobGrade
{
    public string? GradeLevel { get; set; }
    public int LoweslSal { get; set; }
    public int HighestSal { get; set; }
}