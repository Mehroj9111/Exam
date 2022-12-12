using System.Net;
namespace WebApi.Controllers;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[Controller]")]
public class JobHistoryController
{
    private readonly JobHistoryService _jobHistoryService;
    public JobHistoryController (JobHistoryService jobHistoryService)
    {
        _jobHistoryService = jobHistoryService;
    }
    [HttpGet]
    public async Task<Response<List<GetJobHistory>>> GetJobHistory()
    {
        return  await _jobHistoryService.GetJobHistory();
    }
    
    [HttpPost]
    public async Task<Response<AddJobHistory>> Post(AddJobHistory  history)
    {
        return await _jobHistoryService.Add(history);
    }
    [HttpPut]
    public async Task<Response<GetJobHistory>> Update(GetJobHistory history)
    {
        return await _jobHistoryService.Update(history);
    }
    [HttpDelete]
    public async Task<Response<string>> Delete(int id)
    {
        return await _jobHistoryService.Delete(id);
    }   
}