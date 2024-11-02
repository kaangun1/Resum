using Resum.Web.Models.Entities.Abstract;

namespace Resum.Web.Models.Entities.Concrete;

public class Skill:BaseEntity
{
    public string SkillName { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; }
}