namespace STPTask.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using STPTask.Models.InputModels;
    using STPTask.Models.ViewModels;
    using STPTask.Services.Contracts;
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
            var viewModel = await this.employeeService.GetEmployeeById<EditEmployeeInputModel>(id);

            var companyId = viewModel.Office.CompanyId;

            ViewData["offices"] = this.officeService
                                      .GetAllBOfficesByCompanyId<CompanyOfficesAllViewModel>(companyId)
                                      .ToList();

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(string id, EditEmployeeInputModel editEmployeeInputModel)
        {
            await this.employeeService.EditEmployee(id, editEmployeeInputModel);

            return Redirect($"/Company/All");
        }
    }
}