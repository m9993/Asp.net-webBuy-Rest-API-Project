namespace webBuy_with_Rest_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Payment
    {
        public int paymentId { get; set; }
        public string paymentMethod { get; set; }
        public Nullable<double> deliveryCharge { get; set; }
    }
}
