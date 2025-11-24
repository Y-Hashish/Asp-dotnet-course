using CustomValidator.CustomModelBinding;
using CustomValidator.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomValidator.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult home()
        {
            return Content("hello from home");
        }

        //[Route("person")]
        //public IActionResult person([FromHeader(Name ="User-Agent")] string header ,Person p)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        string errors = string.Join("\n", ModelState.Values.SelectMany(x => x.Errors).
        //            Select(x =>x.ErrorMessage));
        //        return BadRequest(errors);
        //    }
        //    return Ok($"{p}");
        //}
        [Route("person")]
        public IActionResult person( [FromBody] Person p)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n", ModelState.Values.SelectMany(x => x.Errors).
                    Select(x => x.ErrorMessage));
                return BadRequest(errors);
            }
            return Ok($"{p}");
        }
    }
}
