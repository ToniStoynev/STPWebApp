namespace STPTask.Services.Contracts
{
    using STPTask.Services.Common;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ICompanyService : IService
    {
        Task<bool> RegisterCompany<TInputModel>(TInputModel companyServiceModel);

        IQueryable<TViewModel> GetAllByOwnerId<TViewModel>(string ownerId);

        Task<TViewModel> GetCompanyById<TViewModel>(string id);

        Task<bool> EditCompany<TInputModel>(string id, TInputModel inputModel);

        Task<bool> DeleteCompany(string id);
    }
}
