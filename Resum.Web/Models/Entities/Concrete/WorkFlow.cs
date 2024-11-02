using Resum.Web.Models.Entities.Abstract;

namespace Resum.Web.Models.Entities.Concrete;

public class WorkFlow:BaseEntity
{
    public string WorkFlowName { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; }
}