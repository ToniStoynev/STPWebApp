namespace STPTask.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using STPTask.Models.InputModels;
    using STPTask.Models.ViewModels;
    using STPTask.Services.Contracts;
    using System.Threading.Tasks;

    public class OfficeController : Controller
    {
        private readonly IOfficeService officeService;
        public OfficeController(IOfficeService officeService)
        {
            this.officeService = officeService;
        }

        [Authorize]
        public IActionResult Open()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Open(string id, OpenOfficeInputModel openOfficeInputModel)
        {
            openOfficeInputModel.CompanyId = id;

            await this.officeService.OpenNewOffice(openOfficeInputModel);

            return Redirect($"/Office/AllOffices?id={id}");
        }

        [Authorize]
        public async Task<IActionResult> AllOffices(string id)
        {
            var viewModel = await this.officeService
                .GetAllBOfficesByCompanyId<CompanyOfficesAllViewModel>(id)
                .ToListAsync();

            return this.View(viewModel);
        }
    }
}