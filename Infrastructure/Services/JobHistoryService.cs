namespace Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;

public class JobHistoryService
{
    private readonly DataContext _cont;

    public JobHistoryService(DataContext context)
    {
        _cont = context;
    }
    public async Task<Response<List<GetJobHistory>>> GetJobHistory()
    {
        var list = await _cont.JobHistories.Select(h => new GetJobHistory()
        {
            Id = h.Id,
            StartDate = h.StartDate,
            EndDate = h.EndDate,
            JobId = h.JobId,                       
        }).ToListAsync();

        return new Response<List<GetJobHistory>>(list);
    }
    public async Task<Response<AddJobHistory>> Add(AddJobHistory jobHistory)
    {
    try
    {
        var newJobHistory = new JobHistory()
        {
            StartDate = jobHistory.StartDate,
            EndDate = jobHistory.EndDate,
            JobId = jobHistory.JobId,            
            DepartmentId = jobHistory.DepartmentId   
        };
        _cont.JobHistories.Add(newJobHistory);
        await _cont.SaveChangesAsync();
        return new Response<AddJobHistory>(jobHistory);
    }
     catch (Exception ex)
    {
            return new Response<AddJobHistory>(HttpStatusCode.InternalServerError, ex.Message);
    }
    }
    public async Task<Response<GetJobHistory>> Update(GetJobHistory jobHistory)
    {
    try
    {
        var find = await _cont.JobHistories.FindAsync(jobHistory.Id);

        if(find == null) return new Response<GetJobHistory>(jobHistory);
        find.StartDate = jobHistory.StartDate;
        find.EndDate = jobHistory.EndDate;
        find.JobId = jobHistory.JobId;
        await _cont.SaveChangesAsync();

        return new Response<GetJobHistory> (jobHistory);
    }
     catch (Exception ex)
    {
            return new Response<GetJobHistory>(HttpStatusCode.InternalServerError, ex.Message);
    }
    }
    public async Task<Response<string>> Delete(int id)
    {
        var find = await _cont.JobHistories.FindAsync(id);

        _cont.JobHistories.Remove(find);
        var result = await _cont.SaveChangesAsync();
        if(result > 0)
        
        return new Response<string>("JobHistory Successfully Deleted");

        return new Response<string>(HttpStatusCode.BadRequest,"JobHistory not found");



    }
  
}