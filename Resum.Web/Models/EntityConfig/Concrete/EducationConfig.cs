using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resum.Web.Models.Entities.Concrete;
using Resum.Web.Models.EntityConfig.Abstract;

namespace Resum.Web.Models.EntityConfig.Concrete;

public class EducationConfig :BaseConfig<Education>
{
    public override void Configure(EntityTypeBuilder<Education> builder)
    {
        base.Configure(builder);
        builder.Property(p => p.School).HasMaxLength(100);
        builder.Property(p => p.Major).HasMaxLength(50);       
       


    }
}