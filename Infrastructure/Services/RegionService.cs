namespace Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;

public class RegionService
{
    private readonly DataContext _con;

    public RegionService(DataContext context)
    {
        _con = context;
    }
    public async Task<Response<List<GetRegion>>> GetRegion()
    {
        var list = await _con.Regions.Select(r => new GetRegion()
        {
            Id = r.Id,
            RegionName = r.RegionName          
        }).ToListAsync();
        return new Response<List<GetRegion>>(list);
    }

    public async Task<Response<AddRegion>> Add(AddRegion region)
    {
    try
    {
        var newRegion = new Region()
        {
           RegionName = region.RegionName
        };
        _con.Regions.Add(newRegion);
        await _con.SaveChangesAsync();
        return new Response<AddRegion>(region);
    }
    catch (Exception ex)
    {
            return new Response<AddRegion>(HttpStatusCode.InternalServerError, ex.Message);
    }
    }
    public async Task<Response<GetRegion>> Update(GetRegion region)
    {
    try
    {
        var find = await _con.Regions.FindAsync(region.Id);
        if(find == null) return new Response<GetRegion>(region);
        find.RegionName = region.RegionName; 
        await _con.SaveChangesAsync();
        return new Response<GetRegion> (region);
    }
    catch (Exception ex)
    {
            return new Response<GetRegion>(HttpStatusCode.InternalServerError, ex.Message);
    }
    }
    public async Task<Response<string>> Delete(int id)
    {
        var find = await _con.Regions.FindAsync(id);
        _con.Regions.Remove(find);
        var result = await _con.SaveChangesAsync();
        if(result > 0)
        
        return new Response<string>("Region Successfully Deleted");
        
        return new Response<string>(HttpStatusCode.BadRequest,"Region not found");
    }
  
}