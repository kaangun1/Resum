using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resum.Web.Models.Entities.Concrete;
using Resum.Web.Models.EntityConfig.Abstract;

namespace Resum.Web.Models.EntityConfig.Concrete;

public class ExperianceConfig:BaseConfig<Experiance>
{
    public override void Configure(EntityTypeBuilder<Experiance> builder)
    {
        base.Configure(builder);
        builder.Property(p => p.Title).HasMaxLength(50);
        builder.Property(p => p.Description).HasMaxLength(500);
        builder.Property(p => p.CompanyName).HasMaxLength(50);

    }
}