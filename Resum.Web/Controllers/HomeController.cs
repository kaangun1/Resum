using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Resum.Web.Models;
using Resum.Web.Models.DbContexts;

namespace Resum.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MySqlDbContext dbContext;

    public HomeController(ILogger<HomeController> logger,MySqlDbContext dbContext)
    {
        _logger = logger;
        this.dbContext = dbContext;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult About()
    {
        var person = dbContext.Persons.FirstOrDefault();

        return View(person);
    }
    public IActionResult Experiance()
    {
        var exps = dbContext.Experiances.ToList();
        return View(exps);
    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}