namespace webBuy_with_Rest_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Invoice
    {
        public int invoiceId { get; set; }
        public int orderId { get; set; }
        public int productId { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<double> unitPrice { get; set; }
    }
}
