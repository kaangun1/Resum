using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resum.Web.Models.Entities.Concrete;
using Resum.Web.Models.EntityConfig.Abstract;

namespace Resum.Web.Models.EntityConfig.Concrete;

public class AwardConfig:BaseConfig<Award>
{
    public override void Configure(EntityTypeBuilder<Award> builder)
    {
        base.Configure(builder);
        builder.Property(p => p.AwardName).HasMaxLength(50);
        builder.HasIndex(p=>p.AwardName).IsUnique();
    }
}