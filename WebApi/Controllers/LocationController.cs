using System.Net;
namespace WebApi.Controllers;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[Controller]")]
public class LocationController
{
    private readonly LocationService _locationService;
    public LocationController (LocationService locationService)
    {
        _locationService = locationService;
    }
    [HttpGet]
    public async Task<Response<List<GetLocation>>> GetLocation()
    {
        return  await _locationService.GetLocation();
    }
    
    [HttpPost]
    public async Task<Response<AddLocation>> Post(AddLocation  location)
    {
        return await _locationService.Add(location);
    }
    [HttpPut]
    public async Task<Response<GetLocation>> Update(GetLocation location)
    {
        return await _locationService.Update(location);
    }
    [HttpDelete]
    public async Task<Response<string>> Delete(int id)
    {
        return await _locationService.Delete(id);
    }   
}