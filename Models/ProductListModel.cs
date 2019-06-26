using Edura.WebUI.Entity;
using System.Collections.Generic;

namespace Edura.WebUI.Models
{
    public class ProductListModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
