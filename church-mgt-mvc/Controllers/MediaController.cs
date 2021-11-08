using Microsoft.AspNetCore.Mvc;

namespace church_mgt_mvc.Controllers
{
    public class MediaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
