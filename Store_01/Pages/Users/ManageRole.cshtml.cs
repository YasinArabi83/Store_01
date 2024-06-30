using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace Store_01.Pages.Users
{
    [Authorize(Roles = "Admin")]

    public class ManageRoleModel : PageModel
    {

        private RoleManager<IdentityRole> roleManager;
        private UserManager<IdentityUser> userManager;


        public ManageRoleModel(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        [BindProperty]
        public List<string> Roles { get; set; }
        [BindProperty]
        public string Id { get; set; }
        public IdentityUser curentUser { get; set; }
        public List<IdentityRole> allRoles { get; set; }
        public List<string> userRoles { get; set; }


        public async Task OnGet(string id)
        {
            curentUser = await userManager.FindByIdAsync(id);
            userRoles =( await userManager.GetRolesAsync(curentUser)).ToList();
            allRoles = roleManager.Roles.ToList();
        }
        public async Task<IActionResult> OnPost()
        {

            curentUser= await userManager.FindByIdAsync(Id);
            userRoles = (await userManager.GetRolesAsync(curentUser)).ToList();
            allRoles = roleManager.Roles.ToList();
            foreach (var item in allRoles)
            {
                if (Roles.Contains(item.Name))
                {
                    if (!(await userManager.IsInRoleAsync(curentUser,item.Name)))
                    {
                        await userManager.AddToRoleAsync(curentUser, item.Name); 
                    }
                   
                }
                else
                {
                    if ((await userManager.IsInRoleAsync(curentUser, item.Name)))
                    {
                        await userManager.RemoveFromRoleAsync(curentUser, item.Name);
                    }
                }
            }
            return RedirectToPage("UserList");
        }
    }
}
