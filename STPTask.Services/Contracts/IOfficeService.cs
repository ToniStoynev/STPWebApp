namespace STPTask.Services.Contracts
{
    using STPTask.Services.Common;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IOfficeService : IService
    {
        Task<bool> OpenNewOffice<TInputModel>(TInputModel inputModel);

        IQueryable<TViewModel> GetAllBOfficesByCompanyId<TViewModel>(string companyId);
    }
}
