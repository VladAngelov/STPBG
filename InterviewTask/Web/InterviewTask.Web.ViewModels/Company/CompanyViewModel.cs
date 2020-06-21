namespace InterviewTask.Web.ViewModels.Company
{
    using ViewModels.User;
    using Office;
    using Services.Mapping;
    using Services.Models.Company;
    using System.Collections.Generic;
    using InterviewTask.Services.Models.User;
    using InterviewTask.Services.Models.Office;

    public class CompanyViewModel : IMapFrom<CompanyServiceModel>, IMapTo<CompanyServiceModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public List<OfficeServiceModel> Offices { get; set; }

        public UserServiceModel User { get; set; }
    }
}
