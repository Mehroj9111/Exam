using Domain.Entities;
namespace Domain.Dtos;
public class AddRegion
{
    public int Id { get; set; }
    public string? RegionName { get; set; }
}