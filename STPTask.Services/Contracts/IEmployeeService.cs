namespace STPTask.Services.Contracts
{
    using STPTask.Services.Models;
    using System.Linq;
    using System.Threading.Tasks;
    public interface IEmployeeService
    {
        Task<bool> HireEmployee(EmployeeServiceModel employeeServiceModel);

        IQueryable<EmployeeServiceModel> GetAllEmployeesByOfficeId(string id);

        Task<EmployeeServiceModel> GetEmployeeById(string id);

        Task<bool> EditEmployee(EmployeeServiceModel employeeServiceModel);
    }
}
