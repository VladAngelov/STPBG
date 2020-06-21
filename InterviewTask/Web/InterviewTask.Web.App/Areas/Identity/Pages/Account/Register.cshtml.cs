namespace InterviewTask.Web.App.Areas.Identity.Pages.Account
{
    using InterviewTask.Data.Models.User;
    using InterviewTask.Web.BindingModels.TextConstants;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<InterviewTaskUser> _signInManager;
        private readonly UserManager<InterviewTaskUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        //private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<InterviewTaskUser> userManager,
            SignInManager<InterviewTaskUser> signInManager,
            ILogger<RegisterModel> logger
            /*,IEmailSender emailSender*/)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            //_emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(100, ErrorMessage = StaticTextConstants.LENGTH_ERROR_MESSAGE, MinimumLength = 3)]
            [Display(Name = StaticTextConstants.USERNAME_DISPLAY)]
            public string Username { get; set; }

            [Required]
            [Display(Name = StaticTextConstants.FIRST_NAME_DISPLAY)]
            [StringLength(30, ErrorMessage = StaticTextConstants.LENGTH_ERROR_MESSAGE, MinimumLength = 3)]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = StaticTextConstants.LAST_NAME_DISPLAY)]
            [StringLength(30, ErrorMessage = StaticTextConstants.LENGTH_ERROR_MESSAGE, MinimumLength = 3)]
            public string LastName { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = StaticTextConstants.EMAIL_DISPLAY)]
            public string Email { get; set; }
                        
            [Required]
            [StringLength(100, ErrorMessage = StaticTextConstants.LENGTH_ERROR_MESSAGE, MinimumLength = 3)]
            [DataType(DataType.Password)]
            [Display(Name = StaticTextConstants.PASSWORD_DISPLAY)]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = StaticTextConstants.PASSWORD_CONFIRM_DISPLAY)]
            [Compare(StaticTextConstants.PASSWORD_DISPLAY, 
                     ErrorMessage = StaticTextConstants.CONFIRMATION_PASSWORD_ERROR_MESSAGE)]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
           // ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = "/Identity/Account/Login";
          
            // ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
          
            if (ModelState.IsValid)
            {
                var user = new InterviewTaskUser 
                { 
                    UserName = Input.Username, 
                    Email = Input.Email,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    FullName = Input.FirstName + " " + Input.LastName
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                   // _logger.LogInformation("User created a new account with password.");

                    return LocalRedirect(returnUrl);

                    #region Email Functionality
                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                    //    protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    //if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    //{
                    //    return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    //}
                    //else
                    //{
                    //    await _signInManager.SignInAsync(user, isPersistent: false);
                    //    return LocalRedirect(returnUrl);
                    //}
                    #endregion
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
