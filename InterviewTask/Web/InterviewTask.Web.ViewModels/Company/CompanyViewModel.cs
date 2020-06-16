namespace InterviewTask.Web.ViewModels.Company
{
    using BindingModels.User;
    using Services.Mapping;
    using Services.Models.Company;
    using Services.Models.Office;
    using System.Collections.Generic;

    public class CompanyViewModel : IMapFrom<CompanyServiceModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public ICollection<OfficeServiceModel> Offices { get; set; }

        public UserBindingModel User { get; set; }
    }
}
