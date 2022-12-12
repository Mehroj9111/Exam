using System.Net;
namespace WebApi.Controllers;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[Controller]")]
public class RegionController
{
    private readonly RegionService _regionService;
    public RegionController (RegionService regionService)
    {
        _regionService = regionService;
    }
    [HttpGet]
    public async Task<Response<List<GetRegion>>> GetRegion()
    {
        return  await _regionService.GetRegion();
    }
    
    [HttpPost]
    public async Task<Response<AddRegion>> Post(AddRegion  region)
    {
        return await _regionService.Add(region);
    }
    [HttpPut]
    public async Task<Response<GetRegion>> Update(GetRegion region)
    {
        return await _regionService.Update(region);
    }
    [HttpDelete]
    public async Task<Response<string>> Delete(int id)
    {
        return await _regionService.Delete(id);
    }   
}