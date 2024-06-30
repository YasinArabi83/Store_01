using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Store_01.Pages.Roles
{
    public class RoleListModel : PageModel
    {
        private RoleManager<IdentityRole> _roleManager;

        public RoleListModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IEnumerable<IdentityRole> roles { get; set; } = Enumerable.Empty<IdentityRole>();
        public void OnGet()
        {
            roles = _roleManager.Roles.ToList();
        }
        public async Task<IActionResult> OnPost(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                await _roleManager.DeleteAsync(role);
            }
            return RedirectToPage("RoleList");
        }

    }
}
