namespace STPTask.Areas.Identity.Pages.Account
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using STPTask.Domain;

    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<STPUser> _signInManager;

        public LogoutModel(SignInManager<STPUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnGet()
        {
            await _signInManager.SignOutAsync();
           
           return LocalRedirect("/Home/Index");
           
        }
    }
}