﻿namespace STPTask.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using STPTask.Data;
    using STPTask.Domain;
    using STPTask.Mappings;
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
            var company = AutoMapper.Mapper.Map<Company>(companyServiceModel);

            this.dbContext.Companies.Add(company);
            int result = await dbContext.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<CompanyServiceModel> GetAllByOwnerId(string ownerId)
        {
            return this.dbContext.Companies
                       .Where(company => company.OwnerId == ownerId)
                       .To<CompanyServiceModel>();
        }

        public async Task<CompanyServiceModel> GetCompanyById(string id)
        {
            var companyFromDb = await this.dbContext.Companies
                .SingleOrDefaultAsync(company => company.Id == id);

            var companyServiceModel = AutoMapper.Mapper.Map<CompanyServiceModel>(companyFromDb);

            return companyServiceModel;
        }

        public async Task<bool> EditCompany(EditCompanyServiceModel companyServiceModel)
        {
            var companyFromDb = await this.dbContext.Companies
                .SingleOrDefaultAsync(company => company.Id == companyServiceModel.Id);

            companyFromDb.Name = companyServiceModel.Name;
            companyFromDb.CreationDate = companyServiceModel.CreationDate;

            this.dbContext.Update(companyFromDb);

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
