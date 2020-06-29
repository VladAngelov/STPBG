namespace InterviewTask.Web.App.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Mapping;
    using Services.User;
    using System.Threading.Tasks;
    using ViewModels.User;

    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> Profile()
        {
            UserDetailsViewModel userDetailsViewModel = (await this.userService
               .GetUserByUsernameAsync(User.Identity.Name))
               .To<UserDetailsViewModel>();

            return View(userDetailsViewModel);
        }
    }
}
