using System;
using System.Net;
using System.Net.Mail;

class Program
{
    static void Main()
    {
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress("kaan.gun-7@hotmail.com");
        mail.To.Add("buberfatmanur38@gmail.com");
        mail.Subject = "AşkımSeniSeviyorum";
        mail.Body = "Bu bir test e-postasıdır.";

        SmtpClient smtp = new SmtpClient("smtp.mail.com", 587);
        smtp.Credentials = new NetworkCredential("kaan.gun-7@hotmail.com", "şifre1.");
        smtp.EnableSsl = true;

        try
        {
            smtp.Send(mail);
            Console.WriteLine("E-posta başarıyla gönderildi.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hata: " + ex.Message);
        }
    }
}