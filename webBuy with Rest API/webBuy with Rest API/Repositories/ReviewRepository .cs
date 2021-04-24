using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webBuy_with_Rest_API.Models;

namespace webBuy_with_Rest_API.Repositories
{
    public class ReviewRepository : Repository<Review>
    {
        public List<Review> GetProductReviews(int id)
        {
            return this.context.Reviews.Where(e => e.productId == id).ToList();
        }
        public List<Review> GetProductReviewsOrderByDesc()
        {
            return this.context.Reviews.OrderByDescending(o=> o.rating).ToList();
        }
    }
}