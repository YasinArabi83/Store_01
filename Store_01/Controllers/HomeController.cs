using Microsoft.AspNetCore.Mvc;
using Store_01.Reader;

namespace Store_01.Controllers
{
	public class HomeController : Microsoft.AspNetCore.Mvc.Controller
	{
		private readonly IProductReader productReader;
		public HomeController(IProductReader productReader)
		{
			this.productReader = productReader;
		}

		public IActionResult Index() => View(productReader.GetProducts());
		public IActionResult About() => View();
		public IActionResult Shop() => View(productReader.GetProducts());
        public IActionResult ContactUs() => View();
        public IActionResult Cart() => View();
        public IActionResult blog() => View();
        public IActionResult Services() => View(productReader.GetProducts());

    }
}
