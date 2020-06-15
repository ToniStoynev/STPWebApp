namespace STPTask.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using STPTask.Data;
    using STPTask.Domain;
    using STPTask.Services.Contracts;
    using STPTask.Services.Models;

    public class OfficeService : IOfficeService
    {
        private readonly STPTaskDbContext dbContext;

        public OfficeService(STPTaskDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> OpenNewOffice(OfficeServiceModel officeServiceModel)
        {
            var office = new Office
            {
                Country = officeServiceModel.Country,
                City = officeServiceModel.City,
                Street = officeServiceModel.Street,
                StreetNumber = officeServiceModel.StreetNumber,
                IsHeadquarter = officeServiceModel.IsHeadquerter,
                CompanyId = officeServiceModel.CompanyId
            };

            this.dbContext.Offices.Add(office);

            int result = await this.dbContext.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<OfficeServiceModel> GetAllBOfficesByCompanyId(string companyId)
        {
            return this.dbContext.Offices
                         .Where(office => office.CompanyId == companyId)
                         .Select(office => new OfficeServiceModel
                         {
                             Country = office.Country,
                             City = office.City,
                             Street = office.Street,
                             StreetNumber = office.StreetNumber,
                             IsHeadquerter = office.IsHeadquarter,
                             CompanyId = office.CompanyId
                         });
        }
    }
}
