namespace Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;

public class DepartmentService
{
    private readonly DataContext _conte;

    public DepartmentService(DataContext context)
    {
        _conte = context;
    }
    public async Task<Response<List<GetDepartment>>> GetDepartment()
    {
        var list = await _conte.Departments.Select(d => new GetDepartment()
        {
            Id = d.DepartmentId,
            DepaartmentName = d.DepaartmentName,         
            ManagerId = d.ManagerId,
            LocationId = d.LocationId
        }).ToListAsync();
        return new Response<List<GetDepartment>>(list);
    }

    public async Task<Response<AddDepartment>> Add(AddDepartment d)
    {
        var newDepartment = new Department()
        {
           DepaartmentName = d.DepaartmentName,         
            ManagerId = d.ManagerId,
            LocationId = d.LocationId
        };
        _conte.Departments.Add(newDepartment);
        await _conte.SaveChangesAsync();
        d.Id = newDepartment.DepartmentId;
        return new Response<AddDepartment>(d);
    }
    public async Task<Response<GetDepartment>> Update(GetDepartment d)
    {
        var find = await _conte.Departments.FindAsync(d.Id);
        if(find == null) return new Response<GetDepartment>(d);
            find.DepaartmentName = d.DepaartmentName;    
            find.ManagerId = d.ManagerId;
            find.LocationId = d.LocationId;
        await _conte.SaveChangesAsync();
        return new Response<GetDepartment> (d);
    }
    public async Task<Response<string>> Delete(int id)
    {
        var find = await _conte.Departments.FindAsync(id);
        _conte.Departments.Remove(find);
        var result = await _conte.SaveChangesAsync();
        if(result > 0)
        
        return new Response<string>("Department Successfully Deleted");
        
        return new Response<string>(HttpStatusCode.BadRequest,"Department not found");
    }
  
}
