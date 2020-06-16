namespace InterviewTask.Services.User
{
    using Company;
    using Employee;
    using Office;
    using System.Threading.Tasks;
    using Web.ViewModels.Company;

    public class UserService : IUserService
    {
        private readonly ICompanyService companyService;
        private readonly IOfficeService officeService;
        private readonly IEmployeeService employeeService;

        public UserService(ICompanyService companyService, 
                           IOfficeService officeService, 
                           IEmployeeService employeeService)
        {
            this.companyService = companyService;
            this.officeService = officeService;
            this.employeeService = employeeService;
        }

        public async Task<CompanyViewModel> GetAllCompaniesAsync(string userName)
        {
            var companies = this.companyService.GetMyCompaniesAsync(userName);

            return await companies;
        }
    }
}
