using Domain.Entities;
namespace Domain.Dtos;
public class AddCountry
{
    public int Id { get; set; }
    public string? CountryName { get; set; }
    public int RegionId { get; set; }
}