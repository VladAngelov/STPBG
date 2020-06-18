namespace InterviewTask.Services.Office
{
    using Data;
    using Data.Models.Employee;
    using Data.Models.Office;
    using Mapping;
    using Microsoft.EntityFrameworkCore;
    using Models.Office;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Web.ViewModels.Office;

    public class OfficeService : IOfficeService
    {
        private readonly InterviewTaskDbContext context;

        public OfficeService(InterviewTaskDbContext context)
        {
            this.context = context;
        }

        public async Task CreateOfficeAsync(OfficeServiceModel officeServiceModel)
        {
            Office office = AutoMapper.Mapper.Map<Office>(officeServiceModel);

            this.context.Offices.Add(office);

            await this.context.SaveChangesAsync();
        }

        public async Task<OfficeViewModel> GetMyOfficeAsync(int officeId)
        {
            Office office = await this.context
                .Offices
                .FirstOrDefaultAsync(o => o.Id == officeId);

            return office.To<OfficeViewModel>();
        }

        public async Task<OfficeViewModel> GetMyAllOfficesAsync(int companyId)
        {
            List<Office> offices = await this.context
              .Offices
              .Where(o => o.CompanyId == companyId)
              .ToListAsync();

            return offices.To<OfficeViewModel>();
        }

        public async Task EditOfficeAsync(int id, OfficeServiceModel officeServiceModel)
        {
            Office officeFromDb = await this.context
                .Offices
                .SingleOrDefaultAsync(office => office.Id == id);

            if (officeFromDb == null)
            {
                throw new ArgumentNullException(nameof(officeFromDb));
            }

            officeFromDb.Country = officeServiceModel.Country;
            officeFromDb.City = officeServiceModel.City;
            officeFromDb.Headquarters = officeServiceModel.Headquarters;
            officeFromDb.Street = officeServiceModel.Street;
            officeFromDb.StreetNumber = officeServiceModel.StreetNumber;

            this.context.Offices.Update(officeFromDb);

            context.SaveChanges();
        }

        public async Task DeleteOfficeAsync(int id)
        {
            Office officeFromDb = await this.context
               .Offices
               .FindAsync(id);

            if (officeFromDb == null)
            {
                throw new ArgumentNullException(nameof(officeFromDb));
            }

            List<Employee> employees = await this.context
                .Employees.Where(e => e.OfficeId == id)
                .ToListAsync();

            this.context.Employees.RemoveRange(employees);
            this.context.Offices.Remove(officeFromDb);

            this.context.SaveChanges();
        }

    }
}
