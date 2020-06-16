namespace InterviewTask.Services.User
{
    using System.Threading.Tasks;
    using Web.ViewModels.Company;
    
    public interface IUserService
    {
        Task<CompanyViewModel> GetAllCompaniesAsync(string userName);
    }
}
