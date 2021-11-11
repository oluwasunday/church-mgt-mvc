using church_mgt_model;
using church_mgt_model.Dtos;
using System.Threading.Tasks;

namespace church_mgt_services.interfaces
{
    public interface ITestimonyService
    {
        Task<Response<AddTestimonyDto>> AddTestimonyAsync(AddTestimonyDto model);
    }
}