using SportsStore.Domain.Abstract;
using SportsStore.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository repository;

        public NavController()
        {
            repository = new EFProductRepository();
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.GetProducts()
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            
            return PartialView(categories);
        }
    }
}