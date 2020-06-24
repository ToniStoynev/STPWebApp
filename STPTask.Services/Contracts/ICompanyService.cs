namespace STPTask.Services.Contracts
{
    using STPTask.Services.Models;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ICompanyService
    {
        Task<bool> RegisterCompany<TInputModel>(TInputModel companyServiceModel);

        IQueryable<TViewModel> GetAllByOwnerId<TViewModel>(string ownerId);

        Task<TViewModel> GetCompanyById<TViewModel>(string id);

        Task<bool> EditCompany(EditCompanyServiceModel companyServiceModel);

        Task<bool> DeleteCompany(string id);
    }
}
