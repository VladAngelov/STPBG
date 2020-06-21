namespace InterviewTask.Services.User
{
    using Data.Models.User;
    using Models.User;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<InterviewTaskUser> GetUserByIdAsync(string userId);

        Task<UserServiceModel> GetUserByUsernameAsync(string id);
    }
}
