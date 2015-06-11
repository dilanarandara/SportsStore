using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Repository
{
    public class EFProductRepository : IProductRepository
    {
        private SportsStoreContext context = new SportsStoreContext();

        public IEnumerable<Entities.Product> GetProducts()
        {
            return context.Products.AsEnumerable<Entities.Product>();
        }
    }
}
