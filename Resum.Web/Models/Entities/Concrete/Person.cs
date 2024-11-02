using System.Security.Principal;
using Resum.Web.Models.Entities.Abstract;

namespace Resum.Web.Models.Entities.Concrete;

public class Person :BaseEntity
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public string PhotoPath { get; set; }

    public bool IsActive { get; set; }
    public string Password { get; set; }

    public List<Education> Educations { get; set; } = new List<Education>();
    public List<Award> Awards { get; set; } = new List<Award>();
    public List<Skill> Skills { get; set; } = new List<Skill>();
    public List<Experiance> Expriances { get; set; } =  new List<Experiance>();
    public List<WorkFlow> WorkFlows { get; set; } = new List<WorkFlow>();

  
}