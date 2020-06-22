namespace InterviewTask.Services.Employee
{
    using Models.Employee;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Web.ViewModels.Employee;

    public interface IEmployeeService
    {
        Task<List<EmployeeViewModel>> GetAllEmployeesAsync(int officeId);

        Task<EmployeeServiceModel> GetInfoAsync(string employeeId);

        Task AddEmployeeAsync(int officeId, EmployeeServiceModel employeeServiceModel);

        Task RemoveEmployeeAsync(string id);

        Task EditEmployeeAsync(string id, EmployeeServiceModel employeeServiceModel);
    }
}
