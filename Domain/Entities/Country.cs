using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public class Country
{
    [Key]
    public int Id { get; set; }
    public string? CountryName { get; set; }
    public int RegionId { get; set; }
    public List<Location>? Locations;
    public virtual Region ? Regions { get; set; }

}