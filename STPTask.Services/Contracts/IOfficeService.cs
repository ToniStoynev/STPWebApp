namespace STPTask.Services.Contracts
{
    using STPTask.Services.Models;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IOfficeService
    {
        Task<bool> OpenNewOffice(OfficeServiceModel officeServiceModel);

        IQueryable<OfficeServiceModel> GetAllBOfficesByCompanyId(string companyId);
    }
}
