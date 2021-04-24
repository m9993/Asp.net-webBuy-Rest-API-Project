namespace webBuy_with_Rest_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public class AdminDiscount
    {
        public int adminDiscountId { get; set; }
        public int userId { get; set; }
        public string promoCode { get; set; }
        public Nullable<int> percentage { get; set; }
    }
}
