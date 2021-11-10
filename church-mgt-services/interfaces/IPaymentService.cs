using church_mgt_model.ViewModels;
using System.Net.Http;
using System.Threading.Tasks;

namespace church_mgt_services.interfaces
{
    public interface IPaymentService
    {
        Task<OnlineGivingResponseViewModel> MakePaymentAsync(OnlineGivingViewModel model);
    }
}