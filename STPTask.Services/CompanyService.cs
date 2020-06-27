namespace STPTask.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using STPTask.Data;
    using STPTask.Domain;
    using STPTask.Mappings;
    using STPTask.Services.Contracts;

    public class CompanyService : ICompanyService
    {
        private readonly STPTaskDbContext dbContext;

        public CompanyService(STPTaskDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> RegisterCompany<TInputModel>(TInputModel inputModel)
        {
            var company = AutoMapper.Mapper.Map<Company>(inputModel);

            this.dbContext.Companies.Add(company);
            int result = await dbContext.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<TViewModel> GetAllByOwnerId<TViewModel>(string ownerId)
        {
            return this.dbContext.Companies
                       .Where(company => company.OwnerId == ownerId)
                       .To<TViewModel>();
        }

        public async Task<TViewModel> GetCompanyById<TViewModel>(string id)
        {
            var companyFromDb = await this.dbContext.Companies
                .SingleOrDefaultAsync(company => company.Id == id);

            var viewModel = AutoMapper.Mapper.Map<TViewModel>(companyFromDb);

            return viewModel;
        }

        public async Task<bool> EditCompany<TInputModel>(string id, TInputModel inputModel)
        {
            var companyFromDb = await this.dbContext.Companies
                .SingleOrDefaultAsync(company => company.Id == id);

            AutoMapper.Mapper.Map(inputModel, companyFromDb);

            int result = await this.dbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeleteCompany(string id)
        {
            var companyFromDb = await this.dbContext
                .Companies
                .FirstOrDefaultAsync(company => company.Id == id);

            this.dbContext.Companies.Remove(companyFromDb);

            int result = await this.dbContext.SaveChangesAsync();

            return result > 0;
        }
    }
}
