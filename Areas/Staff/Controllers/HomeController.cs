using Microsoft.AspNetCore.Mvc;
using WebTravel.Attribute;

namespace WebTravel.Areas.Staff.Controllers
{
    [CheckStaff]
    [Area("Staff")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
