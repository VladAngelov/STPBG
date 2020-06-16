namespace InterviewTask.Services.Company
{
    using Data;
    using Data.Models.Company;
    using Mapping;
    using Models.Company;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Web.ViewModels.Company;

    public class CompanyService : ICompanyService
    {
        private readonly InterviewTaskDbContext context;

        public CompanyService(InterviewTaskDbContext context)
        {
            this.context = context;
        }

        public async Task CreateCompanyAsync(CompanyServiceModel companyServiceModel)
        {
            Company company = AutoMapper.Mapper.Map<Company>(companyServiceModel);

            this.context.Companies.Add(company);

            await this.context.SaveChangesAsync();          
        }

        public async Task<CompanyViewModel> GetMyCompaniesAsync(string userName)
        {
            List<Company> companies = await this.context
                .Companies
                .Where(c => c.User.UserName == userName)
                .ToListAsync();

            return companies.To<CompanyViewModel>();
        }

        public async Task EditCompanyAsync(int id, CompanyServiceModel companyServiceModel)
        {
            Company companyFromDb = await this.context
                .Companies
                .SingleOrDefaultAsync(company => company.Id == id);

            if (companyFromDb == null)
            {
                throw new ArgumentNullException(nameof(companyFromDb));
            }

            companyFromDb.Name = companyServiceModel.Name;
            companyFromDb.Address = companyServiceModel.Address;
            companyFromDb.Offices = companyServiceModel.Offices;

            this.context.Companies.Update(companyFromDb);

            context.SaveChanges();
        }

        public async Task DeleteCompanyAsync(int id)
        {
            Company companyFromDb = await this.context
                .Companies
                .FindAsync(id);

            if (companyFromDb == null)
            {
                throw new ArgumentNullException(nameof(companyFromDb));
            }

            this.context.Companies.Remove(companyFromDb);

            this.context.SaveChanges();
        }
    }
}
