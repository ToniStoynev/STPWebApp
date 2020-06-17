namespace STPTask.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using STPTask.Data;
    using STPTask.Domain;
    using STPTask.Mappings;
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
            var office = AutoMapper.Mapper.Map<Office>(officeServiceModel);

            this.dbContext.Offices.Add(office);

            int result = await this.dbContext.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<OfficeServiceModel> GetAllBOfficesByCompanyId(string companyId)
        {
            return this.dbContext.Offices
                         .Where(office => office.CompanyId == companyId)
                         .To<OfficeServiceModel>();
        }
    }
}
