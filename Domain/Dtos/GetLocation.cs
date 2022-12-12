using Domain.Entities;
namespace Domain.Dtos;
public class GetLocation
{
    public int Id { get; set; }
    public string? StreetAddress { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }
    public string? StateProvince { get; set; }
    public string? CountryName { get; set; }
}