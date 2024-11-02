using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Resum.Web.Models.DbContexts;
using Resum.Web.Models.VMS;
using System.Security.Claims;

namespace Resum.Web.Controllers
{
    public class AccountController(MySqlDbContext dbContext,INotyfService notyfService) : Controller
    {
        public IActionResult Login()
        {
            var loginVm = new LoginVm();
            return View(loginVm);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVm loginVm)
        {
            if (!ModelState.IsValid)
            {
                notyfService.Error("Email yada Sifre Hatali");

                return View(loginVm);

            }

            var user = dbContext.Persons.FirstOrDefault(p=>p.Email == loginVm.Email
                                                        && p.Password==loginVm.Password 
                                                        && p.IsActive==true);

            if (user == null)
            {
                notyfService.Error("Email yada Sifre Hatali");
                return View(loginVm);
            }


            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Sid,user.Id.ToString()),
                new Claim(ClaimTypes.Email, loginVm.Email),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.MobilePhone,user.Phone),
                new Claim(ClaimTypes.UserData,user.PhotoPath)
            };
            var claimIdentity= new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

            var claimIdentityPrincible = new ClaimsPrincipal(claimIdentity);
            var authenticationPriciple = new AuthenticationProperties()
            {
                IsPersistent = loginVm.RememberMe
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme
                                            , claimIdentityPrincible
                                            , authenticationPriciple);

            return RedirectToAction("Index","Home",new {Area="Admin"});
        }
    }
}
