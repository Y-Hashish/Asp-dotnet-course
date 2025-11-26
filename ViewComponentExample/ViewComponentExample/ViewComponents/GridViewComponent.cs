using Microsoft.AspNetCore.Mvc;
using ViewComponentExample.Models;

namespace ViewComponentExample.ViewComponents
{
    public class GridViewComponent :ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(PersonGrid personGrid)
        {
           
            //ViewBag.Grid = personGrid;
            return View(personGrid);
        }

    }
}
