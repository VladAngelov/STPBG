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

        // GET: UserController
        public async Task<IActionResult> Profile()
        {
            UserDetailsViewModel userDetailsViewModel = (await this.userService
               .GetUserByUsernameAsync(User.Identity.Name))
               .To<UserDetailsViewModel>();

            return View(userDetailsViewModel);
        }


        //// GET: UserController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: UserController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
