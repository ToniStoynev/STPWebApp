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
            var companyServiceModel = AutoMapper.Mapper.Map<CompanyServiceModel>(inputModel);

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
                                        .To<CompanyAllViewModel>()
                                        .ToListAsync();

            return this.View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            var companyServiceModel = await this.companyService.GetCompanyById(id);

            var editCompanyInputModel = AutoMapper.Mapper.Map<RegisterCompanyInputModel>(companyServiceModel);

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


            var result = await this.companyService.EditCompany(companyServiceModel);

            return this.Redirect("/Company/All");
        }

        [Authorize]
        public async Task<IActionResult> Delete()
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