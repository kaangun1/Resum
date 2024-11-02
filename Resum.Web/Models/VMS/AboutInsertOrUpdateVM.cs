using System.ComponentModel.DataAnnotations;

namespace Resum.Web.Models.VMS
{
    public class AboutInsertOrUpdateVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Isim alani zorunludur")]
        [MaxLength(50,ErrorMessage ="50 karakterden Fazla Olamaz")]
        [MinLength(2,ErrorMessage ="En az 2 karakter olmalidir")]
        public string Name { get; set; }



        [Required(ErrorMessage = "Soyisim alani zorunludur")]
        [MaxLength(50, ErrorMessage = "50 karakterden Fazla Olamaz")]
        [MinLength(2, ErrorMessage = "En az 2 karakter olmalidir")]
        public string SurName { get; set; }


        [Required(ErrorMessage = "Isim alani zorunludur")]
        [MaxLength(15, ErrorMessage = "15 karakterden Fazla Olamaz")]
        [MinLength(10, ErrorMessage = "En az 10 karakter olmalidir")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email alani zorunludur")]
        [MaxLength(50, ErrorMessage = "50 karakterden Fazla Olamaz")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Adres alani zorunludur")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Aciklama alani zorunludur")]
        public string Description { get; set; }

        

      

        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Şifre alani zorunludur")]
        [MaxLength(50, ErrorMessage = "50 karakterden Fazla Olamaz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre alani zorunludur")]
        [MaxLength(50, ErrorMessage = "50 karakterden Fazla Olamaz")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Dosya ismi giriniz")]
        
        public IFormFile? File { get; set; }
    }
}
