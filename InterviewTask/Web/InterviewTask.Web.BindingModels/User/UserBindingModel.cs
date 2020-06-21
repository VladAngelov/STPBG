namespace InterviewTask.Web.BindingModels.User
{
    using Services.Mapping;
    using Services.Models.Company;
    using Services.Models.User;
    using System.Collections.Generic;

    public class UserBindingModel : IMapFrom<UserServiceModel>, IMapTo<UserServiceModel>
    {
        public string Username { get; set; }

        public string Id { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public List<CompanyServiceModel> Companies { get; set; }
    }
}
