namespace STPTask.Services
{
    using System.Threading.Tasks;
    using STPTask.Data;
    using STPTask.Domain;
    using STPTask.Services.Contracts;
    using STPTask.Services.Models;

    public class EmployeeService : IEmployeeService
    {
        private readonly STPTaskDbContext dbContext;
        public EmployeeService(STPTaskDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<bool> HireEmployee(EmployeeServiceModel employeeServiceModel)
        {
            var employee = new Employee
            {
               FirstName = employeeServiceModel.FirstName,
               LastName = employeeServiceModel.LastName,
               StartingDate = employeeServiceModel.StartingDate,
               Salary = employeeServiceModel.Salary,
               VacantionDays = employeeServiceModel.VacantionDays,
               ExperienceLevel = employeeServiceModel.ExperienceLevel,
               OfficeId = employeeServiceModel.OfficeId
            };

            this.dbContext.Employees.Add(employee);
            int result = await dbContext.SaveChangesAsync();

            return result > 0;
        }
    }
}
