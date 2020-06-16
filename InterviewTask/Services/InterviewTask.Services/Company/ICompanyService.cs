namespace InterviewTask.Services.Company
{
    using Models.Company;
    using System.Threading.Tasks;
    using Web.ViewModels.Company;

    public interface ICompanyService
    {
        Task CreateCompanyAsync(CompanyServiceModel companyServiceModel);

        Task<CompanyViewModel> GetMyCompaniesAsync(string userName);

        Task EditCompanyAsync(int id, CompanyServiceModel companyServiceModel);

        Task DeleteCompanyAsync(int id);
    }
}
