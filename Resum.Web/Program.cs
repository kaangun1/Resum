using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Resum.Web.Models.DbContexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();//Burasi Proje Calisrken yeniden derlendiginde yada Hot Load Yapildiginda 
                                  // Tarayiciyi otomatik olarak refresh eder

builder.Services.AddDbContext<MySqlDbContext>(p=>
    p.UseMySQL(builder.Configuration.GetConnectionString("Resum")));

builder.Services.AddNotyf(p => {
    p.Position = NotyfPosition.BottomRight;
    p.DurationInSeconds = 10;
    p.IsDismissable = true;

});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(p =>
                {
                    p.Cookie.Name = "MyCookie";
                    p.AccessDeniedPath= "/Account/AccesDenied";
                    p.LoginPath= "/Account/Login";
                    p.LogoutPath = "/Account/Logout";
                    p.Cookie.HttpOnly = true;
                    p.Cookie.SameSite = SameSiteMode.Strict;
                    p.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                    p.SlidingExpiration = true;
                });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseNotyf();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name : "areas",
        pattern : "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();