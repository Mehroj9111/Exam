using System.Net;
namespace WebApi.Controllers;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[Controller]")]
public class JobController
{
    private readonly JobService _jobService;
    public JobController (JobService jobService)
    {
        _jobService = jobService;
    }
    [HttpGet]
    public async Task<Response<List<GetJob>>> GetJob()
    {
        return  await _jobService.GetJob();
    }
    
    [HttpPost]
    public async Task<Response<AddJob>> Post(AddJob  country)
    {
        return await _jobService.Add(country);
    }
    [HttpPut]
    public async Task<Response<GetJob>> Update(GetJob country)
    {
        return await _jobService.Update(country);
    }
    [HttpDelete]
    public async Task<Response<string>> Delete(int id)
    {
        return await _jobService.Delete(id);
    }   
}