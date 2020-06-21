namespace InterviewTask.Services.User
{
    using Data;
    using Data.Models.User;
    using Mapping;
    using Microsoft.EntityFrameworkCore;
    using Models.User;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly InterviewTaskDbContext context;

        public UserService(InterviewTaskDbContext context)
        {
            this.context = context;
        }

        public async Task<InterviewTaskUser> GetUserByIdAsync(string userId) 
        {
            var user = await this.context
                .Users
                .FirstAsync(u => u.Id == userId);

            return user;
        }

        public async Task<UserServiceModel> GetUserByUsernameAsync(string userName)
        {
            var user = await this.context
                  .Users
                  .To<UserServiceModel>()
                  .FirstAsync(u => u.UserName == userName);

            return user;
        }
    }
}
