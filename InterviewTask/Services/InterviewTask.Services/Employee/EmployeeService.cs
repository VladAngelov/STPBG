namespace InterviewTask.Services.Employee
{
    using Data;
    using Data.Models.Employee;
    using Mapping;
    using Models.Employee;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Web.ViewModels.Employee;

    public class EmployeeService : IEmployeeService
    {
        private readonly InterviewTaskDbContext context;

        public EmployeeService(InterviewTaskDbContext context)
        {
            this.context = context;
        }

        public async Task AddEmployeeAsync(int id, EmployeeServiceModel employeeServiceModel)
        {
            Employee employee = AutoMapper.Mapper
                .Map<Employee>(employeeServiceModel);
            employee.OfficeId = id;
            employee.Office = this.context
                .Offices
                .Where(o => o.Id == id)
                .FirstOrDefault();
            
            this.context.Employees.Add(employee);
            await this.context.SaveChangesAsync();       
        }

        public async Task EditEmployeeAsync(int id, EmployeeServiceModel employeeServiceModel)
        {
            Employee employeeFromDb = await this.context
               .Employees
               .SingleOrDefaultAsync(employee => employee.Id == id);

            if (employeeFromDb == null)
            {
                throw new ArgumentNullException(nameof(employeeFromDb));
            }

            employeeFromDb.FirstName = employeeServiceModel.FirstName;
            employeeFromDb.LastName = employeeServiceModel.LastName;
            employeeFromDb.OfficeId = employeeServiceModel.OfficeId;
            employeeFromDb.Salary = employeeServiceModel.Salary;
            employeeFromDb.Office = this.context
                .Offices
                .Where(o => o.Id == employeeServiceModel.OfficeId)
                .FirstOrDefault();

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

            List<EmployeeViewModel> employees = new List<EmployeeViewModel>();

            for (int i = 0; i < employeesServiceModel.Count; i++)
            {
                var employee = employeesServiceModel[i].To<EmployeeViewModel>();

                employees.Add(employee);
            }

            return employees;
        }

        public async Task<EmployeeViewModel> GetInfoAsync(int employeeId)
        {
            var employee = await this.context.Employees
                .To<EmployeeViewModel>()
                .FirstAsync(c => c.EmployeeId == employeeId);

            return employee;
        }

        public async Task RemoveEmployeeAsync(int id)
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
