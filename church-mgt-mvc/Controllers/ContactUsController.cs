using Microsoft.AspNetCore.Mvc;

namespace church_mgt_mvc.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
