namespace InterviewTask.Web.ViewModels.User
{
    using Services.Mapping;
    using Services.Models.User;

    public class UserDetailsViewModel : IMapFrom<UserServiceModel>
    {
        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}
