namespace STPTask.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using STPTask.Data;
    using STPTask.Domain;
    using STPTask.Services.Contracts;
    using STPTask.Services.Models;

    public class CompanyService : ICompanyService
    {
        private readonly STPTaskDbContext dbContext;

        public CompanyService(STPTaskDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> RegisterCompany(CompanyServiceModel companyServiceModel)
        {
            var company = new Company
            {
                Name = companyServiceModel.Name,
                CreationDate = companyServiceModel.CreationDate,
                OwnerId = companyServiceModel.OwnerId
            };

            this.dbContext.Companies.Add(company);
            int result = await dbContext.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<CompanyServiceModel> GetAllByOwnerId(string ownerId)
        {
            return this.dbContext.Companies
                       .Where(company => company.OwnerId == ownerId)
                       .Select(company => new CompanyServiceModel
                       {
                           Id = company.Id,
                           Name = company.Name,
                           CreationDate = company.CreationDate
                       });
        }
    }
}
