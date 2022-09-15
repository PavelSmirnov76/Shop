using Shop.Models;

namespace Shop.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product>? GetProducts {set;get;}
    }
}
