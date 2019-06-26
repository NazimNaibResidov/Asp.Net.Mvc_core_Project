using Edura.WebUI.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;


namespace Edura.WebUI.Components
{
    public class FeaturedProducts:ViewComponent
    {
        private IProductRepository repository;

        public FeaturedProducts(IProductRepository _repository)
        {
            repository = _repository;
        }

        public IViewComponentResult Invoke()
        {
          
                return View(repository
                .GetAll()
                .Where(i => i.IsApproved && i.IsFeatured)
                .OrderByDescending(x=>x.ProductId)
                .Take(7)
                .ToList());
        }
    }
}
