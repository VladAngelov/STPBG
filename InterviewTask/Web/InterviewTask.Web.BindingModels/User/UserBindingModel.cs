namespace InterviewTask.Web.BindingModels.User
{
    using Services.Models.Company;
    using System.Collections.Generic;

    public class UserBindingModel
    {
        public string Id { get; set; }
       
        public string Username { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public List<CompanyServiceModel> Companies { get; set; }
    }
}
