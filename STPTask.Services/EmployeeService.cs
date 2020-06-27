namespace STPTask.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using STPTask.Data;
    using STPTask.Domain;
    using STPTask.Mappings;
    using STPTask.Services.Contracts;

    public class EmployeeService : IEmployeeService
    {
        private readonly STPTaskDbContext dbContext;
        public EmployeeService(STPTaskDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> HireEmployee<TInputModel>(TInputModel inputModel)
        {
            var employee = AutoMapper.Mapper.Map<Employee>(inputModel);

            this.dbContext.Employees.Add(employee);

            int result = await dbContext.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<TViewModel> GetAllEmployeesByOfficeId<TViewModel>(string id)
        {
            return this.dbContext
                        .Employees
                        .Where(employee => employee.OfficeId == id)
                        .To<TViewModel>();
        }

        public async Task<TViewModel> GetEmployeeById<TViewModel>(string id)
        {
            var employeeFromDb = await this.dbContext.Employees
                .AsNoTracking()
                .Include(x => x.Office)
                .SingleOrDefaultAsync(employee => employee.Id == id);

            var employeeServiceModel = AutoMapper.Mapper.Map<TViewModel>(employeeFromDb);

            return employeeServiceModel;
        }

        public async Task<bool> EditEmployee<TInputModel>(string id, TInputModel inputModel)
        {
            var employeeFromDb = await this.dbContext
                .Employees
                .SingleOrDefaultAsync(employee => employee.Id == id);

            AutoMapper.Mapper.Map(inputModel, employeeFromDb);

            int result = await this.dbContext.SaveChangesAsync();

            return result > 0;
        }
    }
}
