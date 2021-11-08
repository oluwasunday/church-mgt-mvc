using Microsoft.AspNetCore.Mvc;

namespace church_mgt_mvc.Controllers
{
    public class OnlineGivingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
