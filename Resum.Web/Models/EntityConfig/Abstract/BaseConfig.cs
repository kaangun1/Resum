using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resum.Web.Models.Entities.Abstract;

namespace Resum.Web.Models.EntityConfig.Abstract;

public class BaseConfig<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.CreateDate).HasDefaultValue(DateTime.Now);
    }
}