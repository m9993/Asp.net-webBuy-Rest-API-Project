namespace webBuy_with_Rest_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int orderId { get; set; }
        public Nullable<double> total { get; set; }
        public int paymentId { get; set; }
        public string date { get; set; }
    }
}
