using Resum.Web.Models.Entities.Abstract;

namespace Resum.Web.Models.Entities.Concrete;

public class Education:BaseEntity
{
    public string School { get; set; }
    public string Major { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public double Gpa { get; set; } 
    public int PersonId { get; set; }
    public Person Person { get; set; }
}