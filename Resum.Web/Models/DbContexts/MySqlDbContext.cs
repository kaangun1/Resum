using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Resum.Web.Models.Entities.Concrete;

namespace Resum.Web.Models.DbContexts;

public class MySqlDbContext:DbContext
{
    public DbSet<Award> Awards { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Experiance> Experiances { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<WorkFlow> WorkFlows { get; set; }

    public MySqlDbContext()
    {
        
    }

    public MySqlDbContext(DbContextOptions<MySqlDbContext> options):base(options)
    {
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("Server=localhost;Database=Resumes;Uid=root;Pwd=21449473262;");
   
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}