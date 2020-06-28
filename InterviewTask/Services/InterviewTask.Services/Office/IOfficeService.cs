namespace InterviewTask.Services.Office
{
    using Models.Office;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IOfficeService
    {
        Task CreateOfficeAsync(int companyId, OfficeServiceModel officeServiceModel);

        Task<List<OfficeServiceModel>> GetMyAllOfficesAsync(int companyId);

        Task<OfficeServiceModel> GetByIdAsync(int officeId);

        Task EditOfficeAsync(int id, OfficeServiceModel officeServiceModel);

        Task DeleteOfficeAsync(int id);
    }
}
