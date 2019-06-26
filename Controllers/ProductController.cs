using Edura.WebUI.Models;
using Edura.WebUI.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Edura.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public int PageSize = 6;
        private readonly IProductRepository Repository;
        public ProductController(IProductRepository repository)
        {
           this.Repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            var data = Repository
                .GetAll()
                .Include(x => x.Images)
                .Include(x => x.Attrubutes)
                .Include(x => x.ProductCategories)
                .ThenInclude(x => x.Category)
                .Select(x => new ProductDetailsModel()
                {

                    Product =x,
                    ProductImages = x.Images,
                    ProductAttributes=x.Attrubutes,
                    Categories=x.ProductCategories.Select(i=>i.Category).ToList()



                }).FirstOrDefault();

            return View(data);
        }
        public IActionResult List(string category, int page = 1)

        {
            var products = Repository.GetAll();
            if (!string.IsNullOrEmpty(category))
            {
                products = products
                .Include(i => i.ProductCategories)
                .ThenInclude(i => i.Category)
                .Where(i => i.ProductCategories.Any(x => x.Category.CategoryName == category));
            }
            var count = products.Count();
            products = products.Skip((page - 1) * PageSize).Take(PageSize);
            return View(
                new ProductListModel()
                {
                    Products=products,
                    PagingInfo=new PagingInfo
                    {
                        CurrentPage=page,
                         ItemsPerPage=PageSize,
                         TotalItems=count
                    }
                }


                );
        }
    }
}