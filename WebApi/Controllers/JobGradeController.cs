using System.Net;
namespace WebApi.Controllers;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[Controller]")]
public class JobGradeController
{
    private readonly JobGradeService _jobGardeService;
    public JobGradeController (JobGradeService jobGardeService)
    {
        _jobGardeService = jobGardeService;
    }
    [HttpGet]
    public async Task<Response<List<GetJobGrade>>> GetJobGrade()
    {
        return  await _jobGardeService.GetJobGrade();
    }
    
    [HttpPost]
    public async Task<Response<AddJobGrade>> Post(AddJobGrade  jobGarde)
    {
        return await _jobGardeService.Add(jobGarde);
    }
    [HttpPut]
    public async Task<Response<GetJobGrade>> Update(GetJobGrade jobGarde)
    {
        return await _jobGardeService.Update(jobGarde);
    }
    [HttpDelete]
    public async Task<Response<string>> Delete(int id)
    {
        return await _jobGardeService.Delete(id);
    }   
}