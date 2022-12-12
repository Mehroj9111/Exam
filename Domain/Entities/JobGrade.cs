using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public class JobGrade
{
    [Key]
    public int Id { get; set; }
     [MaxLength(2)]
    public string? GradeLevel { get; set; }
    public int LoweslSal { get; set; }
    public int HighestSal { get; set; }
}