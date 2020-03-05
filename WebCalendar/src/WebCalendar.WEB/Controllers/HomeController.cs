using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebCalendar.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}