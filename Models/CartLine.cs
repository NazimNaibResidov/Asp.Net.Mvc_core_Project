using Edura.WebUI.Entity;
using System.Collections;


namespace Edura.WebUI.Models
{
    public class CartLine
    {
        public int CateLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
