using Microsoft.AspNetCore.Mvc;
using Resum.Web.Models.DbContexts;

namespace Resum.Web.Components
{
    public class GetImageViewComponent:ViewComponent
    {
        private readonly MySqlDbContext dbContext;

        public GetImageViewComponent(MySqlDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var person = dbContext.Persons.FirstOrDefault(p=>p.IsActive==true);
            return View(person);
        }
    }
}
