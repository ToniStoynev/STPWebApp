namespace STPTask.Services.Contracts
{
    using STPTask.Services.Models;
    using System.Linq;
    using System.Threading.Tasks;
    public interface IEmployeeService
    {
        Task<bool> HireEmployee<TInputModel>(TInputModel inputModel);

       IQueryable<TViewModel> GetAllEmployeesByOfficeId<TViewModel>(string id);

        Task<TViewModel> GetEmployeeById<TViewModel>(string id);

        Task<bool> EditEmployee(EmployeeServiceModel inputModel);
    }
}
