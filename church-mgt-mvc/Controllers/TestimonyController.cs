using church_mgt_model.Dtos;
using church_mgt_services.interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace church_mgt_mvc.Controllers
{
    public class TestimonyController : Controller
    {
        private readonly ITestimonyService _testimonyService;

        public TestimonyController(ITestimonyService testimonyService)
        {
            _testimonyService = testimonyService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AddTestimonyDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _testimonyService.AddTestimonyAsync(model);
                if (result != null)
                {
                    ViewBag.Info = result.Message;
                    return View();
                }
            }
            ViewBag.Error = "Error occur, try again!";
            return View();
        }

    }
}
