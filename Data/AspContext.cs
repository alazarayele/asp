using asp.Model;
using Microsoft.EntityFrameworkCore;

namespace asp.Data;

public class AspContext:DbContext
{
    public DbSet<Student> Students {get; set;}

    public DbSet<Course> Courses {get;set;}
    public AspContext(DbContextOptions<AspContext> dbContextOptions):base(dbContextOptions) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Student>(x=>x.HasMany(y=>y.Courses).WithOne(z=>z.Student).HasForeignKey(c=>c.StudentId));
    }    
}