using Resum.Web.Models.Entities.Abstract;

namespace Resum.Web.Models.Entities.Concrete;

public class Award:BaseEntity
{
    public string AwardName { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; }
}