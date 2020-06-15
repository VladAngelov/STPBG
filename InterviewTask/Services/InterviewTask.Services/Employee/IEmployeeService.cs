using System.Threading.Tasks;

namespace InterviewTask.Services.Employee
{
    public interface IEmployeeService
    {
        Task GetAllEmployees();

        Task GetInfo(int employeeId);
    }
}
