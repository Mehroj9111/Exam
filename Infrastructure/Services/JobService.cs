namespace Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;

public class JobService
{
    private readonly DataContext _context;

    public JobService(DataContext context)
    {
        _context = context;
    }


    public async Task<Response<List<GetJob>>> GetJob()
    {
        var list = await _context.Jobs.Select(s => new GetJob()
        {
            Id = s.JobId,
            JobTitle = s.JobTitle,
            MinSalary = s.MinSalary,
            MaxSalary = s.MaxSalary            
        }).ToListAsync();

        return new Response<List<GetJob>>(list);
    }
    public async Task<Response<AddJob>> Add(AddJob job)
    {
    try
    {
        var newJob = new Job()
        {
            JobTitle = job.JobTitle,
            MinSalary  = job.MinSalary,
            MaxSalary  = job.MaxSalary
        };
        _context.Jobs.Add(newJob);
        await _context.SaveChangesAsync();
        return new Response<AddJob>(job);
    }
     catch (Exception ex)
    {
            return new Response<AddJob>(HttpStatusCode.InternalServerError, ex.Message);
    }
    }
    public async Task<Response<GetJob>> Update(GetJob job)
    {
    try
    {
        var find = await _context.Jobs.FindAsync(job.Id);

        if(find == null) return new Response<GetJob>(job);
        find.JobTitle = job.JobTitle;
        find.MinSalary = job.MinSalary;
        find.MaxSalary = job.MaxSalary;
        await _context.SaveChangesAsync();

        return new Response<GetJob> (job);
    }
     catch (Exception ex)
    {
            return new Response<GetJob>(HttpStatusCode.InternalServerError, ex.Message);
    }
    }
    public async Task<Response<string>> Delete(int id)
    {
        var find = await _context.Jobs.FindAsync(id);

        _context.Jobs.Remove(find);
        var result = await _context.SaveChangesAsync();
        if(result > 0)
        
        return new Response<string>("Job Successfully Deleted");

        return new Response<string>(HttpStatusCode.BadRequest,"Job not found");



    }
  
}