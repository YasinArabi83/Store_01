using Store_01.Models;

namespace Store_01.Reader
{
	public class ProductReader : IProductReader
	{
		private readonly StoreContext store;
		public ProductReader(StoreContext store)
		{
			this.store = store;
		}

		public List<Product> GetProducts()
		{
		return	store.Products.Select(a => a).ToList();
		}




	}
}
