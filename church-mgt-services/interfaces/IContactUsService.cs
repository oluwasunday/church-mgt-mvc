using church_mgt_model;
using church_mgt_model.ViewModels;
using System.Threading.Tasks;

namespace church_mgt_services.interfaces
{
    public interface IContactUsService
    {
        Task<Response<ContactUsViewModel>> AddContactUsAsync(ContactUsViewModel model);
    }
}