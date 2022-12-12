namespace Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;

public class JobGradeService
{
    private readonly DataContext _con;

    public JobGradeService(DataContext context)
    {
        _con = context;
    }
    public async Task<Response<List<GetJobGrade>>> GetJobGrade()
    {
        var list = await _con.JobGrades.Select(g => new GetJobGrade()
        {
            Id = g.Id,
            GradeLevel = g.GradeLevel,         
            LoweslSal = g.LoweslSal,
            HighestSal = g.HighestSal        
        }).ToListAsync();
        return new Response<List<GetJobGrade>>(list);
    }

    public async Task<Response<AddJobGrade>> Add(AddJobGrade g)
    {
    try
    {
        var newJobGrade = new JobGrade()
        {
          GradeLevel = g.GradeLevel,         
            LoweslSal = g.LoweslSal,
            HighestSal = g.HighestSal
        };
        _con.JobGrades.Add(newJobGrade);
        await _con.SaveChangesAsync();
        return new Response<AddJobGrade>(g);
    }
    catch (Exception ex)
    {
            return new Response<AddJobGrade>(HttpStatusCode.InternalServerError, ex.Message);
    }
    }
    public async Task<Response<GetJobGrade>> Update(GetJobGrade jobGrade)
    {
    try
    {
        var find = await _con.JobGrades.FindAsync(jobGrade.Id);
        if(find == null) return new Response<GetJobGrade>(jobGrade);
        find.GradeLevel = jobGrade.GradeLevel; 
        find.LoweslSal = jobGrade.LoweslSal; 
        find.HighestSal = jobGrade.HighestSal; 
        await _con.SaveChangesAsync();
        return new Response<GetJobGrade> (jobGrade);
    }
    catch (Exception ex)
    {
            return new Response<GetJobGrade>(HttpStatusCode.InternalServerError, ex.Message);
    }
    }
    public async Task<Response<string>> Delete(int id)
    {
        var find = await _con.Countries.FindAsync(id);
        _con.Countries.Remove(find);
        var result = await _con.SaveChangesAsync();
        if(result > 0)
        
        return new Response<string>("JobGrade Successfully Deleted");
        
        return new Response<string>(HttpStatusCode.BadRequest,"JobGraden not found");
    }
  
}