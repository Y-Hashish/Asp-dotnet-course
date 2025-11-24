using CustomValidator.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomValidator.Controllers
{
    public class AssignmentController : Controller
    {
        [Route("order")]
        [HttpPost]
        public IActionResult Index([Bind(nameof(Order.OrderDate), nameof(Order.InvoicePrice), nameof(Order.Products))] Order order)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n", ModelState.Values.
                    SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                return new ContentResult
                {
                    Content = errors,
                    ContentType = "application/text",
                    StatusCode = 400

                };
            }
            Random random = new Random();
            order.OrderNo = random.Next();
            return new JsonResult(order.OrderNo);
        }
    }
}
