namespace STPTask.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
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

        public async Task<CompanyServiceModel> GetCompanyById(string id)
        {
            var companyFromDb = await this.dbContext.Companies
                .SingleOrDefaultAsync(company => company.Id == id);

           var companyServiceModel = new CompanyServiceModel
           {
               Id = companyFromDb.Id,
               Name = companyFromDb.Name,
               CreationDate = companyFromDb.CreationDate,
               OwnerId = companyFromDb.OwnerId
           };

            return companyServiceModel;
        }

        public async Task<bool> EditCompany(EditCompanyServiceModel companyServiceModel)
        {
            var companyFromDb = this.dbContext.Companies
                .SingleOrDefault(company => company.Id == companyServiceModel.Id);

            companyFromDb.Name = companyServiceModel.Name;
            companyFromDb.CreationDate = companyServiceModel.CreationDate;

           this.dbContext.Update(companyFromDb);

            int result = await this.dbContext.SaveChangesAsync();

            return result > 0;
        }
    }
}
