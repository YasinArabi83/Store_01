using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace Store_01.Pages.Roles
{
    [Authorize(Roles = "Admin")]
    public class EditRoleModel : PageModel
    {

        private RoleManager<IdentityRole> _roleManager;

        public EditRoleModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [BindProperty]
        public string Id { get; set; }
        [BindProperty]
        public string Name { get; set; }
    
        public async Task OnGet(string id)
        {


            var role = await _roleManager.FindByIdAsync(id);
            Id = id;
            Name = role.Name;


        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var role = await _roleManager.FindByIdAsync(Id);
                role.Name = Name;
                var result = await _roleManager.UpdateAsync(role);
              
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
