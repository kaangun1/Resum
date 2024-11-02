using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resum.Web.Models.Entities.Concrete;
using Resum.Web.Models.EntityConfig.Abstract;

namespace Resum.Web.Models.EntityConfig.Concrete;

public class PersonConfig:BaseConfig<Person>
{
    public override void Configure(EntityTypeBuilder<Person> builder)
    {
        base.Configure(builder);
        
        
        builder.Property(p => p.Address).HasMaxLength(200);
        builder.Property(p => p.Name).HasMaxLength(50);
        builder.Property(p => p.SurName).HasMaxLength(50);
        builder.Property(p => p.Description).HasMaxLength(500);
        builder.Property(p => p.Email).HasMaxLength(50);
        builder.Property(p => p.Phone).HasMaxLength(50);
        builder.Property(p => p.PhotoPath).HasMaxLength(1000);

        builder.Property(p=>p.Password).HasMaxLength(500);



        #region Index Ayarlar
            builder.HasIndex(p=>p.Email).IsUnique();
            builder.HasIndex(p=>p.Phone).IsUnique();
        #endregion

        builder.HasData(new Person()
        {
            Id = 1,
            Name = "Ali",
            SurName = "Yilmaz",
            Email = "ali@gmail.com",
            Phone = "08888888888",
            Address = "Istanbul Kadikoy",
            Description = "Şudur budur",
            IsActive = true,
            PhotoPath = "/Images/person.jpg",
            Password = "qweasd"


        });
    }
}