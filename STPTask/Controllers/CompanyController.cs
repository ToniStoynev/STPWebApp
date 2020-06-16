namespace STPTask.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using STPTask.Models.InputModels;
    using STPTask.Models.ViewModels;
    using STPTask.Services.Contracts;
    using STPTask.Services.Models;
    using System.Collections.Generic;
    using System.Linq;
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
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Register(RegisterCompanyInputModel inputModel)
        {
            var companyServiceModel = new CompanyServiceModel
            {
                Name = inputModel.Name,
                CreationDate = inputModel.CreationDate
            };

            companyServiceModel.OwnerId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.companyService.RegisterCompany(companyServiceModel);

            return this.Redirect("/Company/All");
        }

        [Authorize]
        public async Task<IActionResult> All()
        {
            string ownerId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            List<CompanyAllViewModel> viewModel = await this.companyService
                                        .GetAllByOwnerId(ownerId)
                                        .Select(company => new CompanyAllViewModel
                                        {
                                            Id = company.Id,
                                            Name = company.Name,
                                            CreationDate = company.CreationDate
                                        })
                                        .ToListAsync();

            return this.View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            var companyServiceModel = await this.companyService.GetCompanyById(id);

            var editCompanyInputModel = new RegisterCompanyInputModel
            {
                Name = companyServiceModel.Name,
                CreationDate = companyServiceModel.CreationDate
            };

            return this.View(editCompanyInputModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit([FromQuery]string id, [FromForm]RegisterCompanyInputModel registerCompanyInputModel)
        {
            var companyServiceModel = new EditCompanyServiceModel
            {
                Id = id,
                Name = registerCompanyInputModel.Name,
                CreationDate = registerCompanyInputModel.CreationDate
            };

            var result = this.companyService.EditCompany(companyServiceModel);

            return this.Redirect("/Company/All");
        }
    }
}