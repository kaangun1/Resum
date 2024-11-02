using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resum.Web.Models.Entities.Concrete;
using Resum.Web.Models.EntityConfig.Abstract;

namespace Resum.Web.Models.EntityConfig.Concrete;

public class WorkFlowConfig : BaseConfig<WorkFlow>
{
    public override void Configure(EntityTypeBuilder<WorkFlow> builder)
    {
        base.Configure(builder);
        builder.Property(p => p.WorkFlowName).HasMaxLength(50);
        builder.HasIndex(p=>p.WorkFlowName).IsUnique();
    }
}