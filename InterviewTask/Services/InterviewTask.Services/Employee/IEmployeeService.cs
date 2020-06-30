namespace InterviewTask.Services.Employee
{
    using Models.Employee;
    using Models.Office;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEmployeeService
    {
        Task<List<EmployeeServiceModel>> GetAllEmployeesAsync(int officeId);

        Task<EmployeeServiceModel> GetInfoAsync(string employeeId);

        Task AddEmployeeAsync(int officeId, EmployeeServiceModel employeeServiceModel);

        Task RemoveEmployeeAsync(string id);

        Task EditEmployeeAsync(string id, EmployeeServiceModel employeeServiceModel);

        Task<List<OfficeServiceModel>> GetCompanyOfficesAsync(string employeeId);
    }
}
