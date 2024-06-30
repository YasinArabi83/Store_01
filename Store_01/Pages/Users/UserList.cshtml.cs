using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Store_01.Pages.Users
{
    [Authorize(Roles = "Admin")]

    public class UserListModel : PageModel
    {
        private UserManager<IdentityUser> _userManager;

        public UserListModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IEnumerable<IdentityUser> Users { get; set; } = Enumerable.Empty<IdentityUser>();
        public List<string> userRoles { get; set; }


        public async Task OnGet()
        {
            Users = _userManager.Users.ToList();
            foreach (var item in Users)
            {
                var role= (await _userManager.GetRolesAsync(item)).ToList();
                userRoles= role;
            }

        }
        public async Task<IActionResult> OnPost(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
            return RedirectToPage("UserList");
        }

    }
}
