﻿namespace InterviewTask.Web.ViewModels.User
{
    using Services.Mapping;
    using Services.Models.Company;
    using Services.Models.User;
    using System.Collections.Generic;

    public class UserDetailsViewModel : IMapFrom<UserServiceModel>, IMapTo<UserServiceModel>
    {
        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public List<CompanyServiceModel> Companies { get; set; }
    }
}
