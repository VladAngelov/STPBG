namespace InterviewTask.Services.Employee
{
    using Data;
    using Data.Models.Employee;
    using Mapping;
    using Microsoft.EntityFrameworkCore;
    using Models.Employee;
    using Models.Office;
    using Office;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Web.ViewModels.Employee;

    public class EmployeeService : IEmployeeService
    {
        private readonly InterviewTaskDbContext context;
        private readonly IOfficeService officeService;

        public EmployeeService(InterviewTaskDbContext context, IOfficeService officeService)
        {
            this.context = context;
            this.officeService = officeService;
        }

        public async Task<List<OfficeServiceModel>> GetCompanyOfficesAsync(string employeeId)
        {
            var employee = await this.context
                .Employees
                .Where(e => e.Id == employeeId)
                .FirstAsync();

            var currnetOffice = await this.context
                 .Offices
                 .Where(o => o.Id == employee.OfficeId)
                 .FirstAsync();

            var companyOffices = await this.officeService
                .GetMyAllOfficesAsync(currnetOffice.CompanyId);

            return companyOffices;
        }

        public async Task AddEmployeeAsync(int id, EmployeeServiceModel employeeServiceModel)
        {
            Employee employee = new Employee()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = employeeServiceModel.FirstName,
                LastName = employeeServiceModel.LastName,
                ExperienceLevel = employeeServiceModel.ExperienceLevel,
                Salary = employeeServiceModel.Salary,
                StartDate = employeeServiceModel.StartDate,
                VacantionDays = employeeServiceModel.VacantionDays,
                OfficeId = id,
                Office = this.context
                    .Offices
                    .Where(o => o.Id == id)
                    .FirstOrDefault()
            };

            this.context.Employees.Add(employee);
            await this.context.SaveChangesAsync();
        }

        public async Task EditEmployeeAsync(string id, EmployeeServiceModel employeeServiceModel)
        {
            Employee employeeFromDb = await this.context
               .Employees
               .SingleOrDefaultAsync(employee => employee.Id == id);

            var office = await this.context
                .Offices
                .Where(o => o.FullAddress == employeeServiceModel.Office.FullAddress)
                .FirstOrDefaultAsync();

            employeeFromDb.Office = office;

            if (employeeFromDb == null)
            {
                throw new ArgumentNullException(nameof(employeeFromDb));
            }

            employeeFromDb.To<EmployeeServiceModel>();

            this.context.Employees.Update(employeeFromDb);

            context.SaveChanges();
        }

        public async Task<List<EmployeeViewModel>> GetAllEmployeesAsync(int officeId)
        {
            List<EmployeeServiceModel> employeesServiceModel = await this.context
                .Employees
                .Where(e => e.OfficeId == officeId)
                .To<EmployeeServiceModel>()
                .ToListAsync();

            var employees = employeesServiceModel.To<List<EmployeeViewModel>>();

            return employees;
        }

        public async Task<EmployeeServiceModel> GetInfoAsync(string employeeId)
        {
            var employee = await this.context.Employees
                .To<EmployeeServiceModel>()
                .FirstAsync(c => c.Id == employeeId);

            return employee;
        }

        public async Task RemoveEmployeeAsync(string id)
        {
            Employee employeeFromDb = await this.context
                .Employees
                .FindAsync(id);

            if (employeeFromDb == null)
            {
                throw new ArgumentNullException(nameof(employeeFromDb));
            }

            this.context.Employees.Remove(employeeFromDb);

            this.context.SaveChanges();
        }
    }
}
