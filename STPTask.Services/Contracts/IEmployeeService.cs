namespace STPTask.Services.Contracts
{
    using STPTask.Services.Models;
    using System.Threading.Tasks;
    public interface IEmployeeService
    {
        Task<bool> HireEmployee(EmployeeServiceModel employeeServiceModel);
    }
}
