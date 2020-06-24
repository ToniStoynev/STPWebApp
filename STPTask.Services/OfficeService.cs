namespace STPTask.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using STPTask.Data;
    using STPTask.Domain;
    using STPTask.Mappings;
    using STPTask.Services.Contracts;

    public class OfficeService : IOfficeService
    {
        private readonly STPTaskDbContext dbContext;

        public OfficeService(STPTaskDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> OpenNewOffice<TInputModel>(TInputModel inputModel)
        {
            var office = AutoMapper.Mapper.Map<Office>(inputModel);

            this.dbContext.Offices.Add(office);

            int result = await this.dbContext.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<TViewModel> GetAllBOfficesByCompanyId<TViewModel>(string companyId)
        {
            return this.dbContext.Offices
                         .Where(office => office.CompanyId == companyId)
                         .To<TViewModel>();
        }
    }
}
