namespace STPTask.Services.Contracts
{
    using System.Linq;
    using System.Threading.Tasks;

    public interface IOfficeService
    {
        Task<bool> OpenNewOffice<TInputModel>(TInputModel inputModel);

        IQueryable<TViewModel> GetAllBOfficesByCompanyId<TViewModel>(string companyId);
    }
}
