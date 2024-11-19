using Microsoft.AspNetCore.Mvc;

namespace microservice_solution2.Web.Controllers
{
    public class ProductsController: Controller
    {
        private ICatalog _catalog;
        private ICart _cart;

        public ProductsController(ICatalog catalog, ICart cart)
        {
            _catalog = catalog;
            _cart = cart;
        }

        public object GetProducts()
        {
            var res = _catalog.Get();
            return res;
        }

        public object GetCart()
        {
            var res = _cart.Get();
            return res;
        }
    }
}
