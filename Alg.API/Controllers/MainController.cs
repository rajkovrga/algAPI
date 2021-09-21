using Microsoft.AspNetCore.Mvc;

namespace Alg.API.Controllers
{
    public class MainController : Controller
    {
        // GET
        public IActionResult Index(int id)
        {
            return Ok();
        }
    }
}