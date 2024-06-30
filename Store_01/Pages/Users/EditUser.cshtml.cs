using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace Store_01.Pages.Users
{
    [Authorize(Roles = "Admin")]

    public class EditUserModel : PageModel
    {

        private UserManager<IdentityUser> _userManager;

        public EditUserModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        [BindProperty]
        public string Id { get; set; }
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string? Password { get; set; }
        [BindProperty]
        [EmailAddress]
        public string Email { get; set; }
        public async Task OnGet(string id)
        {


            var user = await _userManager.FindByIdAsync(id);
            Id = id;
            UserName = user.UserName;
            Email = user.Email;


        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var User = await _userManager.FindByIdAsync(Id);
                User.UserName = UserName;
                User.Email = Email;
                var result = await _userManager.UpdateAsync(User);
                if (result.Succeeded && !Password.IsNullOrEmpty())
                {
                    await _userManager.RemovePasswordAsync(User);
                    User = await _userManager.FindByIdAsync(Id);
                    result = await _userManager.AddPasswordAsync(User, Password);
                }
                if (result.Succeeded)
                {
                   return RedirectToPage("UserList");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return Page();
        }
    }
}
