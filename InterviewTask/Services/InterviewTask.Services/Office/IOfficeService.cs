namespace InterviewTask.Services.Office
{
    using Models.Office;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Web.ViewModels.Office;

    public interface IOfficeService
    {
        Task CreateOfficeAsync(int companyId, OfficeServiceModel officeServiceModel);

        Task<List<OfficeViewModel>> GetMyAllOfficesAsync(int companyId);

        Task<OfficeServiceModel> GetByIdAsync(int officeId);

        Task EditOfficeAsync(int id, OfficeServiceModel officeServiceModel);

        Task DeleteOfficeAsync(int id);
    }
}
