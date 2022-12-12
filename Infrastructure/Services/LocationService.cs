namespace Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;

public class LocationService
{
    private readonly DataContext _con;

    public LocationService(DataContext context)
    {
        _con = context;
    }
    public async Task<Response<List<GetLocation>>> GetLocation()
    {
        var list = await _con.Locations.Select(l => new GetLocation()
        {
            Id = l.LocationId,
            StreetAddress = l.StreetAddress,         
            PostalCode = l.PostalCode,         
            City = l.City,         
            StateProvince = l.StateProvince,                  
        }).ToListAsync();
        return new Response<List<GetLocation>>(list);
    }

    public async Task<Response<AddLocation>> Add(AddLocation l)
    {
    try
    {
        var newLocation = new Location()
        {
            StreetAddress = l.StreetAddress,         
            PostalCode = l.PostalCode,         
            City = l.City,         
            StateProvince = l.StateProvince,         
            CountryId = l.CountryId, 
        };
        _con.Locations.Add(newLocation);
        await _con.SaveChangesAsync();
        return new Response<AddLocation>(l);
    }
    catch (Exception ex)
    {
            return new Response<AddLocation>(HttpStatusCode.InternalServerError, ex.Message);
    }
    }
    public async Task<Response<GetLocation>> Update(GetLocation l)
    {
    try
    {
        var find = await _con.Locations.FindAsync(l);
        if(find == null) return new Response<GetLocation>(l);
            find.StreetAddress = l.StreetAddress;         
            find.PostalCode = l.PostalCode;         
            find.City = l.City;         
            find.StateProvince = l.StateProvince;          
        await _con.SaveChangesAsync();
        return new Response<GetLocation> (l);
    }
    catch (Exception ex)
    {
            return new Response<GetLocation>(HttpStatusCode.InternalServerError, ex.Message);
    }
    }
    public async Task<Response<string>> Delete(int id)
    {
        var find = await _con.Locations.FindAsync(id);
        _con.Locations.Remove(find);
        var result = await _con.SaveChangesAsync();
        if(result > 0)
        
        return new Response<string>("Location Successfully Deleted");
        
        return new Response<string>(HttpStatusCode.BadRequest,"Location not found");
    }
  
}