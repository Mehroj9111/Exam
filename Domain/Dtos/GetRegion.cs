using Domain.Entities;
namespace Domain.Dtos;
public class GetRegion
{
    public int Id { get; set; }
    public string? RegionName { get; set; }
}