namespace InterviewTask.Services.Models.User
{
    using Data.Models.User;
    using Services.Mapping;
    using Microsoft.AspNetCore.Identity;

    public class UserServiceModel : IdentityUser, IMapFrom<InterviewTaskUser>
    {
        public string FullName { get; set; }
    }
}
