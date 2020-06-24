namespace STPTask.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using STPTask.Models.InputModels;
    using STPTask.Models.ViewModels;
    using STPTask.Services.Contracts;
    using STPTask.Services.Models;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class CompanyController : Controller
    {
        private readonly ICompanyService companyService;
        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        [Authorize]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Register(RegisterCompanyInputModel inputModel)
        {
            inputModel.OwnerId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.companyService.RegisterCompany(inputModel);

            return this.Redirect("/Company/All");
        }

        [Authorize]
        public async Task<IActionResult> All()
        {
            string ownerId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var viewModel = await this.companyService
                                        .GetAllByOwnerId<CompanyAllViewModel>(ownerId)
                                        .ToListAsync();

            return this.View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            var viewModel = await this.companyService.GetCompanyById<RegisterCompanyInputModel>(id);

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(string id, RegisterCompanyInputModel registerCompanyInputModel)
        {
            var companyServiceModel = new EditCompanyServiceModel
            {
                Id = id,
                Name = registerCompanyInputModel.Name,
                CreationDate = registerCompanyInputModel.CreationDate
            };

            var result = await this.companyService.EditCompany(companyServiceModel);

            return this.Redirect("/Company/All");
        }

        [Authorize]
        public IActionResult Delete()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            await this.companyService.DeleteCompany(id);

            return RedirectToAction(nameof(All));
        }
    }
}