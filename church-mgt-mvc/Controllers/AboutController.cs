using Microsoft.AspNetCore.Mvc;

namespace church_mgt_mvc.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OurHistory()
        {
            return View();
        }

        public IActionResult MissionAndVision()
        {
            return View();
        }

        public IActionResult OurBeliefs() 
        {
            return View();
        }
    }
}
