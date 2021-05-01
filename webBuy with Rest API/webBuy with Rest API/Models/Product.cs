namespace webBuy_with_Rest_API.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Product
    {
        public int productId { get; set; }
        public string name { get; set; }
        public int shopId { get; set; }
        public Nullable<double> unitPrice { get; set; }
        public Nullable<int> quantity { get; set; }
        public string date { get; set; }
        public string image { get; set; }
        public Nullable<int> productStatus { get; set; }
        public int categoryId { get; set; }

    }
}
