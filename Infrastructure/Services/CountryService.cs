namespace Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;

public class CountryService
{
    private readonly DataContext _contt;

    public CountryService(DataContext context)
    {
        _contt = context;
    }
    public async Task<Response<List<GetCountry>>> GetCountry()
    {
        var list = await _contt.Countries.Select(c => new GetCountry()
        {
            Id = c.Id,
            CountryName = c.CountryName,         
            RegionId = c.RegionId         
        }).ToListAsync();
        return new Response<List<GetCountry>>(list);
    }

    public async Task<Response<AddCountry>> Add(AddCountry c)
    {
    try
    {
        var newCountry = new Country()
        {
           CountryName = c.CountryName,         
            RegionId = c.RegionId 
        };
        _contt.Countries.Add(newCountry);
        await _contt.SaveChangesAsync();
        c.Id = newCountry.Id;
        return new Response<AddCountry>(c);
    }
    catch (Exception ex)
    {
            return new Response<AddCountry>(HttpStatusCode.InternalServerError, ex.Message);
    }
    }
    public async Task<Response<GetCountry>> Update(GetCountry country)
    {
    try
    {
        var find = await _contt.Countries.FindAsync(country.Id);
        if(find == null) return new Response<GetCountry>(country);
        find.CountryName = country.CountryName; 
        find.RegionId = country.RegionId; 
        await _contt.SaveChangesAsync();
        return new Response<GetCountry> (country);
    }
    catch (Exception ex)
    {
            return new Response<GetCountry>(HttpStatusCode.InternalServerError, ex.Message);
    }
    }
    public async Task<Response<string>> Delete(int id)
    {
        var find = await _contt.Countries.FindAsync(id);
        _contt.Countries.Remove(find);
        var result = await _contt.SaveChangesAsync();
        if(result > 0)
        
        return new Response<string>("Country Successfully Deleted");
        
        return new Response<string>(HttpStatusCode.BadRequest,"Country not found");
    }
  
}