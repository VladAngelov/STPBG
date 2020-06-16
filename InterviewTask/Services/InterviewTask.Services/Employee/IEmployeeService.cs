namespace InterviewTask.Services.Employee
{
    using Models.Employee;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Web.ViewModels.Employee;

    public interface IEmployeeService
    {
        Task<List<EmployeeViewModel>> GetAllEmployeesAsync(int officeId);

        Task<EmployeeViewModel> GetInfoAsync(int employeeId);

        Task AddEmployeeAsync(EmployeeServiceModel employeeServiceModel);

        Task RemoveEmployeeAsync(int id);

        Task EditEmployeeAsync(int id, EmployeeServiceModel employeeServiceModel);
    }
}
