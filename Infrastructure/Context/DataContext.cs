using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Context;

public class DataContext:DbContext
{
 public DataContext(DbContextOptions<DataContext> options) : base(options)
 {

 }
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
            
 modelBuilder.Entity<Employee>()
   .HasOne(d => d.Manager)
   .WithMany()
   .HasForeignKey(d => d.ManagerId);

modelBuilder.Entity<Department>()
     .HasOne<Location>(l => l.Locations)
     .WithMany(d => d.Departments)
     .HasForeignKey(l => l.LocationId);
     
 modelBuilder.Entity<JobHistory>()
     .HasOne<Employee>(s => s.Employees)
     .WithMany(g => g.JobHistories)
     .HasForeignKey(s => s.EmployeeId);

 modelBuilder.Entity<JobHistory>()
     .HasOne<Job>(j => j.Jobs)
     .WithMany(h => h.JobHistories)
     .HasForeignKey(j => j.JobId);

modelBuilder.Entity<Employee>()
     .HasOne<Job>(j => j.Jobs)
     .WithMany(e => e.Employees)
     .HasForeignKey(j => j.JobId);

 modelBuilder.Entity<Country>()
     .HasOne<Region>(r => r.Regions)
     .WithMany(c => c.Countries)
     .HasForeignKey(r => r.RegionId);

modelBuilder.Entity<Location>()
     .HasOne<Country>(s => s.Countries)
     .WithMany(g => g.Locations)
     .HasForeignKey(s => s.CountryId);
            
 modelBuilder.Entity<JobHistory>()
     .HasOne<Department>(s => s.Departments)
     .WithMany(g => g.JobHistories)
     .HasForeignKey(s => s.DepartmentId);
}
 public DbSet<Employee> Employees {get; set;}
 public DbSet<Job> Jobs  {get; set;}
 public DbSet<JobHistory> JobHistories {get; set;}
 public DbSet<JobGrade> JobGrades {get; set;}
 public DbSet<Department> Departments {get; set;}
 public DbSet<Location> Locations  {get; set;}
 public DbSet<Country>  Countries  {get; set;}
 public DbSet<Region> Regions {get; set;}

}