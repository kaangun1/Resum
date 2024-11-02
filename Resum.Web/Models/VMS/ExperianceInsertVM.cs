using System.ComponentModel.DataAnnotations;

namespace Resum.Web.Models.VMS
{
    public class ExperianceInsertVM
    {
        [Required(ErrorMessage ="Başlik Alani Girilemk zorundadir",AllowEmptyStrings =false)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Şirket  Girilemk zorundadir", AllowEmptyStrings = false)]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Aciklama alani zorunludur", AllowEmptyStrings = false)]
        public string Description { get; set; }


        [Required(ErrorMessage = "Başlangic Tarihi zorunlu alandir", AllowEmptyStrings = false)]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }


        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
    }
}
