using Edura.WebUI.Infrastructure;
using Edura.WebUI.Models;
using Edura.WebUI.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Edura.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository Repository;
        private IUnitOfWork unitofWork;
        public CartController(IProductRepository _Repository, IUnitOfWork _unitOfWork)
        {
            unitofWork = _unitOfWork;
            Repository = _Repository;
        }
        public IActionResult Index()
        {
            return View(GetCart());
        }
        public IActionResult AddToCart(int ProductId, int quantity = 1)
        {
            var product = unitofWork.Products.Get(ProductId);

            if (product != null)
            {
                var cart = GetCart();
                cart.AddProduct(product, quantity);
                SaveCart(cart);
            }

            return RedirectToAction("Index");
        }
        public IActionResult RemoveFromCart(int ProductId)
        {
            var product = unitofWork.Products.Get(ProductId);

            if (product != null)
            {
                var cart = GetCart();
                cart.RemoveProduct(product);
                SaveCart(cart);
            }
            return RedirectToAction("Index");
        }
        public void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("cart", cart);
        }
        private Cart GetCart()
        {
           return HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }
    }
}