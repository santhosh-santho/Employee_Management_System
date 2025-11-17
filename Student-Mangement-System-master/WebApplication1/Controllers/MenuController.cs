using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
       
        public IActionResult Privacy()
        {
            return View();
        }
        
    }
}
 