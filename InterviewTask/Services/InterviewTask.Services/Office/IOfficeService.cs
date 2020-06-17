﻿namespace InterviewTask.Services.Office
{
    using Models.Office;
    using System.Threading.Tasks;
    using Web.ViewModels.Office;

    public interface IOfficeService
    {
        Task CreateOfficeAsync(OfficeServiceModel officeServiceModel);

        Task<OfficeViewModel> GetMyAllOfficesAsync(int companyId);

        Task<OfficeViewModel> GetMyOfficeAsync(int officeId);

        Task EditOfficeAsync(int id, OfficeServiceModel officeServiceModel);

        Task DeleteOfficeAsync(int id);
    }
}
