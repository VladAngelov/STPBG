namespace InterviewTask.Web.ViewModels.Company
{
    using Office;
    using Services.Models.User;
    using Services.Mapping;
    using Services.Models.Company;
    using System.Collections.Generic;

    public class CompanyViewModel : IMapFrom<CompanyServiceModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public ICollection<OfficeViewModel> Offices { get; set; }

        public UserServiceModel User { get; set; }
    }
}
