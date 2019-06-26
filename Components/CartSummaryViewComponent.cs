using Edura.WebUI.Infrastructure;
using Edura.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Components
{
    public class CartSummaryViewComponent:ViewComponent
    {
        public string Invoke()
        {
           return HttpContext.Session.GetJson<Cart>("cart")?.products.Count().ToString() ?? (0).ToString();
        }
    }
}
