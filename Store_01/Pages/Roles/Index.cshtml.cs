using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Store_01.Pages.Roles
{
    public class IndexModel : PageModel
    {
        [Authorize(Roles = "Admin")]

        public void OnGet()
        {
        }
    }
}
