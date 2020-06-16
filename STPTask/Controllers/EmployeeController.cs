namespace STPTask.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using STPTask.Models.InputModels;
    using STPTask.Services.Contracts;
    using STPTask.Services.Models;
    using System.Threading.Tasks;

    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [Authorize]
        public async Task<IActionResult> HireEmployee()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> HireEmployee([FromQuery]string id, [FromForm]HireEmployeeInputModel hireEmployeeInputModel)
        {
            var employeeServiceModel = new EmployeeServiceModel
            {
                FirstName = hireEmployeeInputModel.FirstName,
                LastName = hireEmployeeInputModel.LastName,
                StartingDate = hireEmployeeInputModel.StartingDate,
                Salary = hireEmployeeInputModel.Salary,
                ExperienceLevel = hireEmployeeInputModel.ExperienceLevel,
                VacantionDays = hireEmployeeInputModel.VacantionDays,
                OfficeId = id
            };

            await this.employeeService.HireEmployee(employeeServiceModel);

            return Redirect("/Office/All");
        }
    }
}