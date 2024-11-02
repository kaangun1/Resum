using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resum.Web.Models.EntityConfig.Abstract;

namespace Resum.Web.Models.Entities.Concrete;

public class SkillConfig:BaseConfig<Skill>
{
    public override void Configure(EntityTypeBuilder<Skill> builder)
    {
        base.Configure(builder);
        builder.Property(p => p.SkillName).HasMaxLength(50);
        builder.HasIndex(p=>p.SkillName).IsUnique();
    }
}