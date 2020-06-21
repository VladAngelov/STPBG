namespace InterviewTask.Services.Company
{
    using Models.Company;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Web.ViewModels.Company;

    public interface ICompanyService
    {
        Task CreateCompanyAsync(string userId, CompanyServiceModel companyServiceModel);

        Task<CompanyServiceModel> GetById(int id);

        Task<List<CompanyViewModel>> GetUserCompaniesAsync(string userName);

        Task EditCompanyAsync(int id, CompanyServiceModel companyServiceModel);

        Task DeleteCompanyAsync(int id);
    }
}
