namespace STPTask.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using STPTask.Mappings;
    using STPTask.Models.InputModels;
    using STPTask.Models.ViewModels;
    using STPTask.Services.Contracts;
    using STPTask.Services.Models;
    using System.Linq;
    using System.Threading.Tasks;

    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly IOfficeService officeService;

        public EmployeeController(IEmployeeService employeeService, IOfficeService officeService)
        {
            this.employeeService = employeeService;
            this.officeService = officeService;
        }

        [Authorize]
        public IActionResult HireEmployee()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> HireEmployee(string id, HireEmployeeInputModel hireEmployeeInputModel)
        {
            hireEmployeeInputModel.OfficeId = id;

            await this.employeeService.HireEmployee(hireEmployeeInputModel);

            return Redirect($"/Employee/AllEmployees?id={id}");
        }

        [Authorize]
        public async Task<IActionResult> AllEmployees(string id)
        {
            var viewModel = await this.employeeService
                .GetAllEmployeesByOfficeId<EmployeeAllViewModel>(id)
                .ToListAsync();

            return View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            var employeeServiceModel = await this.employeeService.GetEmployeeById<EditEmployeeInputModel>(id);

            var companyId = employeeServiceModel.Office.CompanyId;

            var editEmployeeInputModel = AutoMapper.Mapper.Map<EditEmployeeInputModel>(employeeServiceModel);

            ViewData["offices"] = this.officeService
                .GetAllBOfficesByCompanyId<CompanyOfficesAllViewModel>(companyId)
                .ToList();

            return this.View(editEmployeeInputModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit([FromQuery]string id, 
                [FromForm]EditEmployeeInputModel editEmployeeInputModel)
        {
            var employeeServiceModel = new EmployeeServiceModel
            {
                Id = id,
                FirstName = editEmployeeInputModel.FirstName,
                LastName = editEmployeeInputModel.LastName,
                StartingDate = editEmployeeInputModel.StartingDate,
                Salary = editEmployeeInputModel.Salary,
                VacantionDays = editEmployeeInputModel.VacantionDays,
                ExperienceLevel = editEmployeeInputModel.ExperienceLevel,
                OfficeId = editEmployeeInputModel.OfficeId
            };

            await this.employeeService.EditEmployee(employeeServiceModel);

            return Redirect($"/Company/All");
        }
    }
}