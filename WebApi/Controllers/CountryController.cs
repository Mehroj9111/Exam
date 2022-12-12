using System.Net;
namespace WebApi.Controllers;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[Controller]")]
public class CountryController
{
    private readonly CountryService _countryService;
    public CountryController (CountryService countryService)
    {
        _countryService = countryService;
    }
    [HttpGet]
    public async Task<Response<List<GetCountry>>> GetCountry()
    {
        return  await _countryService.GetCountry();
    }
    
    [HttpPost]
    public async Task<Response<AddCountry>> Post(AddCountry  country)
    {
        return await _countryService.Add(country);
    }
    [HttpPut]
    public async Task<Response<GetCountry>> Update(GetCountry country)
    {
        return await _countryService.Update(country);
    }
    [HttpDelete]
    public async Task<Response<string>> Delete(int id)
    {
        return await _countryService.Delete(id);
    }   
}