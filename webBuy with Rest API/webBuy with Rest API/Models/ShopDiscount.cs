namespace webBuy_with_Rest_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ShopDiscount
    {
        public int shopDiscountId { get; set; }
        public int shopId { get; set; }
        public string promoCode { get; set; }
        public Nullable<int> percentage { get; set; }
    }
}
