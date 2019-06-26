using Edura.WebUI.Entity;
using System.Collections.Generic;
using System.Linq;


namespace Edura.WebUI.Models
{
    public class Cart
    {
        public List<CartLine> products = new List<CartLine>();
        public List<CartLine> Products => products;
        public void AddProduct(Product product,int quantity)
        {
            var prd = products
                     .Where(x => x.Product.ProductId == product.ProductId)
                     .FirstOrDefault();
            if (prd==null)
            {
                products.Add(new CartLine()
                {
                    Product=product,
                    Quantity=quantity
                });

            }
                
        }
        public void RemoveProduct(Product product)
        {
            products.RemoveAll(x => x.Product.ProductId == product.ProductId);
        }
        public decimal TotalPrice()
        {
            return(decimal) products.Sum(x => x.Product.Price * x.Quantity);
        }
        public void ClearAll()
        {
            products.Clear();
        }

    }
}
