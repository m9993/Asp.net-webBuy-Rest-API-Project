namespace webBuy_with_Rest_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Review
    {
        public int reviewId { get; set; }
        public int productId { get; set; }
        public string review { get; set; }
        public Nullable<int> rating { get; set; }
        public int userId { get; set; }
    }
}
