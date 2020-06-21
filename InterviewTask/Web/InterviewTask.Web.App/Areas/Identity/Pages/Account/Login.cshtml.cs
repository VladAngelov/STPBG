namespace InterviewTask.Web.App.Areas.Identity.Pages.Account
{
    using InterviewTask.Data.Models.User;
    using InterviewTask.Web.BindingModels.TextConstants;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly UserManager<InterviewTaskUser> _userManager;
        private readonly SignInManager<InterviewTaskUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(SignInManager<InterviewTaskUser> signInManager,
            ILogger<LoginModel> logger,
            UserManager<InterviewTaskUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        // public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = StaticTextConstants.EMAIL_ERROR_MESSAGE)]
            [EmailAddress]
            [Display(Name = StaticTextConstants.EMAIL_ADDRESS_DISPLAY)]
            public string Email { get; set; }

            [Required(ErrorMessage = StaticTextConstants.PASSWORD_ERROR_MESSAGE)]
            [DataType(DataType.Password)]
            [Display(Name = StaticTextConstants.PASSWORD_DISPLAY)]
            public string Password { get; set; }

            [Display(Name = StaticTextConstants.REMEMBER_ME_DISPLAY)]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            // await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            // ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            //returnUrl = returnUrl ?? Url.Content("~/");

            returnUrl = "/User/Profile";

            if (ModelState.IsValid)
            {
                var result = Microsoft.AspNetCore.Identity.SignInResult.Failed;
                try
                {
                    InterviewTaskUser signedUser = await _userManager
                                   .FindByEmailAsync(Input.Email);

                     result = await _signInManager.PasswordSignInAsync(
                        signedUser.UserName,
                        Input.Password,
                        Input.RememberMe,
                        lockoutOnFailure: false);

                }
                catch (System.Exception)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
     
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                //if (result.RequiresTwoFactor)
                //{
                //    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                //}
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
