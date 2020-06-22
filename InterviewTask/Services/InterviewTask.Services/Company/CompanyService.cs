﻿namespace InterviewTask.Services.Company
{
    using Data;
    using Data.Models.Company;
    using Mapping;
    using Microsoft.EntityFrameworkCore;
    using Models.Company;
    using Models.Office;
    using Models.User;
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

        public async Task CreateCompanyAsync(string userId, CompanyServiceModel companyServiceModel)
        {
            Company company = new Company()
            {
                Name = companyServiceModel.Name,
                Address = companyServiceModel.Address,
                Offices = companyServiceModel.Offices,
                UserId = userId
            };

            this.context.Companies.Add(company);
            await this.context.SaveChangesAsync();
        }

        public async Task<CompanyServiceModel> GetById(int id)
        {
            var company = await this.context
                .Companies
                .To<CompanyServiceModel>()
                .FirstAsync(c => c.Id == id);

            return company;
        }

        public async Task<List<CompanyViewModel>> GetUserCompaniesAsync(string userName)
        {
            List<CompanyServiceModel> companiesServiceModel = await this.context
                .Companies
                .To<CompanyServiceModel>()
                .Where(c => c.User.UserName == userName)
                .ToListAsync();

            List<CompanyViewModel> companies = new List<CompanyViewModel>();

            for (int i = 0; i < companiesServiceModel.Count; i++)
            {
                var comapny = new CompanyViewModel()
                {
                    Id = companiesServiceModel[i].Id,
                    Name = companiesServiceModel[i].Name,
                    Address = companiesServiceModel[i].Address,
                    User = companiesServiceModel[i].User.To<UserServiceModel>(),
                    Offices = this.context.Offices.Select(o => new OfficeServiceModel()
                    {
                        City = o.City,
                        CompanyId = o.CompanyId,
                        Country = o.Country,
                        Headquarters = o.Headquarters,
                        Street = o.Street,
                        StreetNumber = o.StreetNumber,
                        Employees = this.context.
                                   Employees
                                   .Where(e => e.OfficeId == o.Id)
                                   .ToList()

                    }).Where(rudb => rudb.CompanyId == companiesServiceModel[i].Id)
                      .ToList()
                };

                companies.Add(comapny);
            }

            return companies;
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
