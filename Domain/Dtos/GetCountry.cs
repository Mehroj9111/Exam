using Domain.Entities;
namespace Domain.Dtos;
public class GetCountry
{
    public int Id { get; set; }
    public string? CountryName { get; set; }
    public int RegionId { get; set; }
}
