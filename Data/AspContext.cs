using asp.Model;
using Microsoft.EntityFrameworkCore;

namespace asp.Data;

public class AspContext:DbContext
{
    public DbSet<Student> Students {get; set;}

    public DbSet<Course> Courses {get;set;}

    public DbSet<Country> Countries{get;set;}

    public DbSet<CapitalCity> CapitalCities{get;set;}

    public DbSet<Employee> Employees{get;set;}

     public DbSet<Project> Projects{get;set;}

      public DbSet<EmployeeProject> EmployeeProjects{get;set;}
    public AspContext(DbContextOptions<AspContext> dbContextOptions):base(dbContextOptions) {}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Student>(x=>x.HasMany(y=>y.Courses).WithOne(z=>z.Student).HasForeignKey(c=>c.StudentId));

        modelBuilder.Entity<EmployeeProject>()
        .HasKey(ep=>new {ep.EmployeeId,ep.ProjectId});
    
     modelBuilder.Entity<EmployeeProject>()
        .HasOne(ep=>ep.Employee)
        .WithMany(e=>e.EmployeeProjects)
        .HasForeignKey(ep=>ep.EmployeeId);
       
    modelBuilder.Entity<EmployeeProject>()
        .HasOne(ep=>ep.Project)
        .WithMany(e=>e.EmployeeProjects)
        .HasForeignKey(ep=>ep.ProjectId);
       


    
    }    
}