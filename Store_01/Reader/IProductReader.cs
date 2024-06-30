using Store_01.Models;

namespace Store_01.Reader
{
	public interface IProductReader
	{
		List<Product> GetProducts();
	}
}
