using church_mgt_model.ViewModels;
using church_mgt_services.interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace church_mgt_mvc.Controllers
{
    public class OnlineGivingController : Controller
    {
        private readonly IPaymentService _paymentService;

        public OnlineGivingController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(OnlineGivingViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _paymentService.MakePaymentAsync(model);
                if(result != null)
                {
                    return Redirect(result.Authorization_Url);
                }
            }
            ViewBag.Error = "Error occur, try again!";
            return View();
        }

        public IActionResult SuccessPayment()
        {
            return View();
        }
    }
}
