﻿namespace STPTask.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using STPTask.Data;
    using STPTask.Domain;
    using STPTask.Mappings;
    using STPTask.Services.Contracts;
    using STPTask.Services.Models;

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
                .Include(x => x.Office)
                .SingleOrDefaultAsync(employee => employee.Id == id);

            var employeeServiceModel = AutoMapper.Mapper.Map<TViewModel>(employeeFromDb);

            return employeeServiceModel;
        }

        public async Task<bool> EditEmployee(EmployeeServiceModel employeeServiceModel)
        {
            var employeeFromDb = await this.dbContext
                .Employees
                .FirstOrDefaultAsync(employee => employee.Id == employeeServiceModel.Id);

            employeeFromDb.FirstName = employeeServiceModel.FirstName;
            employeeFromDb.LastName = employeeServiceModel.LastName;
            employeeFromDb.Salary = employeeServiceModel.Salary;
            employeeFromDb.VacantionDays = employeeServiceModel.VacantionDays;
            employeeFromDb.ExperienceLevel = employeeServiceModel.ExperienceLevel;
            employeeFromDb.OfficeId = employeeServiceModel.OfficeId;


            this.dbContext.Update(employeeFromDb);

            int result = await this.dbContext.SaveChangesAsync();

            return result > 0;
        }
    }
}
