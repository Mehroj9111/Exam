using Domain.Entities;
namespace Domain.Dtos;
public class GetJobGrade
{
    public int Id { get; set; }
    public string? GradeLevel { get; set; }
    public int LoweslSal { get; set; }
    public int HighestSal { get; set; }
}