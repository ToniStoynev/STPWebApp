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
        public async Task<IActionResult> Open([FromQuery]string id, 
            [FromForm]OpenOfficeInputModel openOfficeInputModel)
        { 
            var officeServiceModel = AutoMapper.Mapper.Map<OfficeServiceModel>(openOfficeInputModel);

            officeServiceModel.CompanyId = id;

            await this.officeService.OpenNewOffice(officeServiceModel);

            return Redirect($"/Office/AllOffices?id={id}");
        }

        [Authorize]
        public async Task<IActionResult> AllOffices(string id)
        {
            var viewModel = await this.officeService
                .GetAllBOfficesByCompanyId(id)
                .To<CompanyOfficesAllViewModel>()
                .ToListAsync();

            return this.View(viewModel);
        }
    }
}