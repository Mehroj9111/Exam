using System.Net;
namespace WebApi.Controllers;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[Controller]")]
public class DepartmentController
{
    private readonly DepartmentService _departmentService;
    public DepartmentController (DepartmentService departmentService)
    {
        _departmentService = departmentService;
    }
    [HttpGet]
    public async Task<Response<List<GetDepartment>>> GetCountry()
    {
        return  await _departmentService.GetDepartment();
    }
    
    [HttpPost]
    public async Task<Response<AddDepartment>> Post(AddDepartment  department)
    {
        return await _departmentService.Add(department);
    }
    [HttpPut]
    public async Task<Response<GetDepartment>> Update(GetDepartment department)
    {
        return await _departmentService.Update(department);
    }
    [HttpDelete]
    public async Task<Response<string>> Delete(int id)
    {
        return await _departmentService.Delete(id);
    }   
}