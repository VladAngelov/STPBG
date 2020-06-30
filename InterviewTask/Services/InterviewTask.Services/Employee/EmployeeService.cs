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

        public async Task<List<EmployeeServiceModel>> GetAllEmployeesAsync(int officeId)
        {
            List<Employee> employeesFromDb = await this.context
                .Employees
                .Where(e => e.OfficeId == officeId)
                .ToListAsync();

            for (int i = 0; i < employeesFromDb.Count; i++)
            {
                await VacantionDaysAsync(employeesFromDb[i].Id);
            }

            List<EmployeeServiceModel> employees = employeesFromDb.To<List<EmployeeServiceModel>>();

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

        private async Task VacantionDaysAsync(string employeeId)
        {
            var employee = await this.context
                .Employees
                .Where(e => e.Id == employeeId)
                .FirstAsync();

            DateTime startDay = employee.StartDate.Date;
            DateTime toDay = DateTime.Now.Date;

            TimeSpan span = toDay - startDay;
            int businessDays = span.Days + 1;
            int fullWeekCount = businessDays / 7;

            // find out if there are weekends during the time exceedng the full weeks
            if (businessDays > fullWeekCount * 7)
            {
                // we are here to find out if there is a 1-day or 2-days weekend
                // in the time interval remaining after subtracting the complete weeks
                int firstDayOfWeek = startDay.DayOfWeek == DayOfWeek.Sunday
                                     ? 7 : (int)startDay.DayOfWeek;
                int lastDayOfWeek = toDay.DayOfWeek == DayOfWeek.Sunday
                                    ? 7 : (int)toDay.DayOfWeek;

                if (lastDayOfWeek < firstDayOfWeek)
                {
                    lastDayOfWeek += 7;
                }

                if (firstDayOfWeek <= 6)
                {
                    if (lastDayOfWeek >= 7)// Both Saturday and Sunday are in the remaining time interval
                    {
                        businessDays -= 2;
                    }
                    else if (lastDayOfWeek >= 6)// Only Saturday is in the remaining time interval
                    {
                        businessDays -= 1;
                    }
                }
                else if (firstDayOfWeek <= 7 && lastDayOfWeek >= 7)// Only Sunday is in the remaining time interval
                {
                    businessDays -= 1;
                }
            }

            // subtract the weekends during the full weeks in the interval
            businessDays -= fullWeekCount + fullWeekCount;

            double vacantionPerDay = 20.0 / 365.0;

            double vacantionDays = Math.Ceiling(businessDays * vacantionPerDay);

            employee.VacantionDays = (int)vacantionDays;

            this.context.Employees.Update(employee);

            context.SaveChanges();
        }
    }
}
