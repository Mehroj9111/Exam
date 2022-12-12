using System.Net;
namespace WebApi.Controllers;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[Controller]")]
public class EmployeeController
{
    private readonly EmployeeService _employeeService;
    public EmployeeController (EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }
    [HttpGet]
    public async Task<Response<List<GetEmployee>>> GetEmployee()
    {
        return  await _employeeService.GetEmployee();
    }
    
    [HttpPost]
    public async Task<Response<AddEmployee>> Post([FromForm] AddEmployee  employeeService)
    {
        return await _employeeService.Add(employeeService);
    }
    [HttpPut]
    public async Task<Response<AddEmployee>> Update(AddEmployee employeeService)
    {
        return await _employeeService.Update(employeeService);
    }
    [HttpDelete]
    public async Task<Response<string>> Delete(int id)
    {
        return await _employeeService.Delete(id);
    }   
}