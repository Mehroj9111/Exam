using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public class Location
{
    public int LocationId { get; set; }
     [MaxLength(40)]
    public string? StreetAddress { get; set; }
     [MaxLength(12)]
    public string? PostalCode { get; set; }
     [MaxLength(30)]
    public string? City { get; set; }
     [MaxLength(25)]
    public string? StateProvince { get; set; }
    public int CountryId { get; set; }
    public virtual Country? Countries { get; set; }
    public List<Department>? Departments;
}