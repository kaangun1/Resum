using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resum.Web.Models.DbContexts;
using Resum.Web.Models.Entities.Concrete;
using Resum.Web.Models.VMS;
using System.Security.Claims;
using System.Xml.Linq;

namespace Resum.Web.Areas.Admin.Controllers;


[Area("Admin")]
[Authorize]
public class HomeController(MySqlDbContext mysqldb, 
                            IHostEnvironment hostEnvironment , 
                            INotyfService notyfService) : Controller
{
    private readonly INotyfService notyfService = notyfService;

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult About()
    {
        AboutInsertOrUpdateVM vm = new AboutInsertOrUpdateVM();
        var person = mysqldb.Persons.FirstOrDefault(p=>p.IsActive==true);
        //Eger db'de kayit var ise viewmodel'i doldur
        if (person != null)
        {


            vm.Id = person.Id;
            vm.Name = person.Name;
            vm.SurName = person.SurName;
            vm.Address = person.Address;
            vm.Email = person.Email;
            vm.Password = person.Password;
            vm.Phone = person.Phone;
            vm.Description = person.Description;
           
            vm.IsActive = person.IsActive;
            
        }
        
        return View(vm);
    }

    [NonAction]
    public async Task<string> Test()
    {
        return "ali veli";
    }

    [HttpPost]
    public async Task<IActionResult> About(AboutInsertOrUpdateVM aboutVM)
    {
        if (!ModelState.IsValid)
        {
            return View(aboutVM);
        }

        #region Fotograf kaydetme
        /* fullpath => C:\Users\MATEBOOK 14\source\repos\WissenTemmuz2024\Resume\Resum.Web\wwwroot\images\personel.jpg
         fullPath kullanicin tarayicindan bize yukledigi ve post ettigi fotografi harddisk'e kayderken kullanacagiz
        Tarayicindan bize fotograf yuklendiginde server tarafinda bu hafiza da tutulur. Hafizadki bir datayi eger ki
        SSD yada HDD gibi bir external cihaza kaydetmek istiyorsam eger bunun icin Streaming yapmam gerekir.



          PhotoPath ise => database'e saklayacagimiz daha kisa bir path olacak
        */

        string fullPath = String.Empty;
        string photoPath= String.Empty;
        if (aboutVM.File != null)
        {
            var fileName=Path.GetFileName(aboutVM.File.FileName); //Personel
            var extension= Path.GetExtension(aboutVM.File.FileName); //.jpg
            var newFileName=String.Concat(Guid.NewGuid().ToString(),  extension);//385c549d-b7a2-404b-9e5b-23e2081c356b.jpg
            //hostEnviroment.ContentRootPath=> C:\Users\MATEBOOK 14\source\repos\WissenTemmuz2024\Resume\Resum.Web\
            photoPath = $@"/images/{newFileName}";
            fullPath = Path.Combine(hostEnvironment.ContentRootPath, $@"wwwroot"+photoPath);

            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
               await aboutVM.File.CopyToAsync(fileStream);
            }

        }
        #endregion


        #region Database'e kayit etme. 

       
        //Eger Id alani 0 ise yeni kayittir
        if (aboutVM.Id == 0) 
        {
            Person person = new Person()
            {
               Name = aboutVM.Name,
               SurName = aboutVM.SurName,
               Description = aboutVM.Description,
               Address = aboutVM.Address,
               Email = aboutVM.Email,
               Phone = aboutVM.Phone,
               Password = aboutVM.Password,
               CreateDate=DateTime.Now,
               PhotoPath = photoPath,
            };

            mysqldb.Persons.Add(person);
            mysqldb.SaveChanges();
        }
        else
        {
            var updateperson = mysqldb.Persons.Find(aboutVM.Id);
            if (updateperson != null)
            {
                updateperson.Name = aboutVM.Name;
                updateperson.SurName = aboutVM.SurName;
                updateperson.Description = aboutVM.Description;
                updateperson.Address = aboutVM.Address;
                updateperson.Email = aboutVM.Email;
                updateperson.Phone = aboutVM.Phone;
                updateperson.Password = aboutVM.Password;
                updateperson.CreateDate = DateTime.Now;
                updateperson.PhotoPath = photoPath;
            }
            mysqldb.Persons.Update(updateperson);
            mysqldb.SaveChanges();
        }
        #endregion




        return RedirectToAction("Index", "Home", new { Area = "Admin" });
    }


    [HttpGet]
    public async Task<IActionResult> Experiance()
    {

        //Asenkron metodlari eger ki  await ile cagirmaz isek , geriye Task nesnesi doner. 
        // Oylesi bir durumda  experiance.Result.ToList(); Seklinde Task'in Sonucunu liste seklinde isteriz
        // O yuzden dikkat edilmesi gerekir. ya await kullanilacak yada  experiance.Result.ToList(); seklinde kullanilacak
        var experiance = await mysqldb.Experiances.ToListAsync();
       
        return View(experiance);
    }

    [HttpGet]
    public async Task<IActionResult> ExperianceInsert()
    {
        ExperianceInsertVM insertVM = new();
        return View(insertVM);
    }

    [HttpPost]
    public async Task<IActionResult> ExperianceInsert(ExperianceInsertVM insertVM)
    {
        if (!ModelState.IsValid)
        {
            return View(insertVM);

        }

        var id = User.FindFirst(ClaimTypes.Sid)?.Value;
        Experiance exp = new Experiance();
        exp.Title =insertVM.Title;
        exp.CompanyName = insertVM.CompanyName;
        exp.Description = insertVM.Description;
        exp.StartDate = insertVM.StartDate;
        exp.CreateDate = DateTime.Now;
        exp.EndDate = (DateTime)(insertVM.EndDate == null ? DateTime.Now : insertVM.EndDate); ;
        exp.PersonId = int.Parse(id);

        mysqldb.Experiances.Add(exp);
        mysqldb.SaveChanges();
       return RedirectToAction("Experiance", "Home",new { Area="Admin"});
    }

    [HttpGet]
    public async Task<IActionResult> ExperianceEdit(int id)
    {
        var exp = mysqldb.Experiances.FirstOrDefault(x => x.Id == id);
        ExperianceUpdateVM updateVM = new ExperianceUpdateVM()
        {
            Title = exp.Title, 
            CompanyName = exp.CompanyName, 
            Description = exp.Description,
            StartDate = exp.StartDate,
            EndDate = exp.EndDate,
            Id = id
        };
        return View(updateVM);
    }


    [HttpPost]
    public async Task<IActionResult> ExperianceEdit(ExperianceUpdateVM updateVM)
    {
        if (!ModelState.IsValid)
        {
            return View(updateVM);
        }

        var exp = mysqldb.Experiances.FirstOrDefault(p => p.Id == updateVM.Id);

        exp.StartDate=updateVM.StartDate;
        exp.EndDate = (DateTime)updateVM.EndDate;
        exp.Title = updateVM.Title;
        exp.CompanyName = updateVM.CompanyName;
        exp.Description = updateVM.Description;

        mysqldb.Experiances.Update(exp);
        mysqldb.SaveChanges();

        return RedirectToAction("Experiance", "Home", new { Area = "Admin" });
    }


    public async Task<IActionResult> ExperianceDelete(int id)
    {
        var exp = mysqldb.Experiances.FirstOrDefault(x => x.Id == id);
       
        return View(exp);
      
    }

    [HttpPost]
    public async Task<IActionResult> ExperianceDelete(Experiance experiance)
    {
        var exp = mysqldb.Experiances.FirstOrDefault(x => x.Id == experiance.Id);

        mysqldb.Experiances.Remove(exp);
        mysqldb.SaveChanges();
        notyfService.Success("Iþlem Baþarili");
        return RedirectToAction("Experiance","Home",new {Area="Admin"});

    }
}