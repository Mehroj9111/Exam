namespace Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;

public class EmployeeService
{
    private readonly DataContext _contex;
    private readonly IWebHostEnvironment  _hostEnvironment;
    public EmployeeService(DataContext context,IWebHostEnvironment hostEnvironment)
    {
        _contex = context;
        _hostEnvironment = hostEnvironment;
    }
    public async Task<Response<List<GetEmployee>>> GetEmployee()
    {
        var list = await _contex.Employees.Select(e => new GetEmployee()
        {
            Id = e.EmployeeId,
            FirstName = e.FirstName,
            LastName = e.LastName,         
            Email = e.Email,
            PhoneNumber = e.PhoneNumber,
            HeirDate = e.HeirDate,
            JobId = e.JobId,
            Salary = e.Salary,
            CommissionPct = e.CommissionPct,
            ManagerId = e.ManagerId,
            DepartmentId = e.DepartmentId,
            FileName = e.File.FileName        
        }).ToListAsync();
        return new Response<List<GetEmployee>>(list.ToList());
    }
    public async Task<Response<AddEmployee>> Add(AddEmployee e)
    {
    try
    {
        var path = Path.Combine(_hostEnvironment.WebRootPath, "Images");
        if(Directory.Exists(path) == false)
        {
            Directory.CreateDirectory(path);
        }
        var Img = Path.Combine(path, e.File.FileName);
            using (var stream = File.Create(Img))
            {
                await e.File.CopyToAsync(stream);
            }

        var newEmployee = new Employee()
        {
            FirstName = e.FirstName,
            LastName = e.LastName,         
            Email = e.Email,
            PhoneNumber = e.PhoneNumber,
            HeirDate = e.HeirDate,
            JobId = e.JobId,
            Salary = e.Salary,
            CommissionPct = e.CommissionPct,
            ManagerId = e.ManagerId,
            DepartmentId = e.DepartmentId,     
        };
        _contex.Employees.Add(newEmployee);
        await _contex.SaveChangesAsync();
        e.Id = newEmployee.EmployeeId;
        return new Response<AddEmployee>(e);
    }
    catch (Exception ex)
    {
            return new Response<AddEmployee>(HttpStatusCode.InternalServerError, ex.Message);
    }
    }
    public async Task<Response<AddEmployee>> Update(AddEmployee e)
    {
    try
    {
        var find = await _contex.Employees.FindAsync(e.Id);
        if(find == null) return new Response<AddEmployee>(e);
           find.FirstName = e.FirstName;
           find.LastName = e.LastName;       
           find.Email = e.Email;
           find.PhoneNumber = e.PhoneNumber;
           find.HeirDate = e.HeirDate;
           find.JobId = e.JobId;
           find.Salary = e.Salary;
           find.CommissionPct = e.CommissionPct;
           find.ManagerId = e.ManagerId;
           find.DepartmentId = e.DepartmentId;  
           find.File = e.File;         
        await _contex.SaveChangesAsync();
        return new Response<AddEmployee> (e);
    }
    catch (Exception ex)
    {
            return new Response<AddEmployee>(HttpStatusCode.InternalServerError, ex.Message);
    }
    }
    public async Task<Response<string>> Delete(int id)
    {
        var find = await _contex.Employees.FindAsync(id);
        _contex.Employees.Remove(find);
        var result = await _contex.SaveChangesAsync();
        if(result > 0)
        
        return new Response<string>("Employee Successfully Deleted");
        
        return new Response<string>(HttpStatusCode.BadRequest,"Employee not found");
    }
}