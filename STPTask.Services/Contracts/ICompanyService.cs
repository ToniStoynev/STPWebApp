namespace STPTask.Services.Contracts
{
    using STPTask.Services.Models;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ICompanyService
    {
        Task<bool> RegisterCompany(CompanyServiceModel companyServiceModel);

        IQueryable<CompanyServiceModel> GetAllByOwnerId(string ownerId);
    }
}
