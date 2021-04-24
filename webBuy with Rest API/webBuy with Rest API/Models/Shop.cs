namespace webBuy_with_Rest_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Shop
    {
        public int shopId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public Nullable<int> shopStatus { get; set; }
        public Nullable<double> balance { get; set; }
        public Nullable<int> setComission { get; set; }
    }
}
