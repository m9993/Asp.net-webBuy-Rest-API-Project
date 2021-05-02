using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webBuy_with_Rest_API.Models;

namespace webBuy_with_Rest_API.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public List<Product> GetByShopId(int id)
        {
            return this.context.Products.Where(e => e.shopId == id).ToList();
        }
        public List<Product> SerachProduct(string searchKey)
        {
            return this.context.Products.Where(s => s.name.Contains(searchKey)).ToList();
        }
        public List<Product> GetLastAddedProducts()
        {
            return this.context.Products.OrderByDescending(o => o.date).ToList();
        }
    }
}