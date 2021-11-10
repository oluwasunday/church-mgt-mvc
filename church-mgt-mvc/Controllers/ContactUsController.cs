using church_mgt_model.ViewModels;
using church_mgt_services.interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace church_mgt_mvc.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactUsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _contactUsService.AddContactUsAsync(model);
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
