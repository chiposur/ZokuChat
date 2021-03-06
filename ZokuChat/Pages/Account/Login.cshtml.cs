using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using ZokuChat.Data;
using ZokuChat.Helpers;
using ZokuChat.Models;

namespace ZokuChat.Pages.Account
{
    public class LoginModel : PageModel
    {
		private readonly Context _context;
		private readonly SignInManager<User> _signInManager;

		[BindProperty]
		public Login Login { get; set; }

		public LoginModel(Context context, SignInManager<User> userManager)
		{
			_context = context;
			_signInManager = userManager;
		}

		public void OnGet()
        {
        }

		public async Task<IActionResult> OnPostAsync(string returnUrl)
		{
			returnUrl = returnUrl != null ? returnUrl : UrlHelper.GetRoomsUrl();
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(
					Login.UserName,
					Login.Password,
					true,
					lockoutOnFailure: true);
				
				if (result.Succeeded)
				{
					return LocalRedirect(returnUrl);
				}
				else if (result.IsLockedOut)
				{
					return RedirectToPage("Lockout");
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Invalid login attempt.");
				}
			}

			// If we got this far, something failed, redisplay form
			return Page();
		}
    }
}