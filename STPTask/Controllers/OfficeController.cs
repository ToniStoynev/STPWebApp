namespace STPTask.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using STPTask.Models.InputModels;
    using STPTask.Models.ViewModels;
    using STPTask.Services.Contracts;
    using STPTask.Services.Models;
    using System.Linq;
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
        public async Task<IActionResult> Open([FromQuery]string id, [FromForm]OpenOfficeInputModel openOfficeInputModel)
        {
            var officeServiceModel = new OfficeServiceModel
            {
                Country = openOfficeInputModel.Country,
                City = openOfficeInputModel.City,
                Street = openOfficeInputModel.Street,
                StreetNumber = openOfficeInputModel.StreetNumber,
                IsHeadquerter = openOfficeInputModel.IsHeadquerter
            };

            officeServiceModel.CompanyId = id;

            await this.officeService.OpenNewOffice(officeServiceModel);

            return Redirect($"/Office/AllOffices?id={id}");
        }

        [Authorize]
        public async Task<IActionResult> AllOffices(string id)
        {
            var viewModel = await this.officeService
                .GetAllBOfficesByCompanyId(id)
                .Select(office => new CompanyOfficesAllViewModel
                {
                    Id = office.Id,
                    Country = office.Country,
                    City = office.City,
                    Street = office.Street,
                    StreetNumber = office.StreetNumber,
                    IsHeadquarter = office.IsHeadquerter
                })
                .ToListAsync();


            return this.View(viewModel);
        }
    }
}