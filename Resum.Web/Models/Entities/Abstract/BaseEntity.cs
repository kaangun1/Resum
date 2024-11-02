namespace Resum.Web.Models.Entities.Abstract;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; }
}