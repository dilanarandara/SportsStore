using SportsStore.Domain.Abstract;
using SportsStore.Domain.Repository;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        private int pageSize = 2;

        public ProductController()
        {
            this.repository = new EFProductRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(string category, int page = 1)
        {
            var products = repository.GetProducts().Where(p => category == null || p.Category == category);
            ProductsListViewModel vm = new ProductsListViewModel()
            {
                Products = products.OrderBy(p => p.Name).Skip((page - 1) * pageSize).Take(pageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ? products.Count() : products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            };

            return View(vm);
        }
    }
}