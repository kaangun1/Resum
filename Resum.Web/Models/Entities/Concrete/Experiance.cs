using Resum.Web.Models.Entities.Abstract;

namespace Resum.Web.Models.Entities.Concrete;

public class Experiance :BaseEntity
{
    public string Title { get; set; }
    public string CompanyName { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; }

}