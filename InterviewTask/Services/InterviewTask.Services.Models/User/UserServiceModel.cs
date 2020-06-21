namespace InterviewTask.Services.Models.User
{
    using Data.Models.User;
    using Mapping;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using InterviewTask.Services.Models.Company;

    public class UserServiceModel : IdentityUser, IMapFrom<InterviewTaskUser>
    {
        public string FullName { get; set; }

        public List<CompanyServiceModel>Companies { get; set; }
    }
}
