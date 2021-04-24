namespace webBuy_with_Rest_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Withdraw
    {
        public int withdrawId { get; set; }
        public int userId { get; set; }
        public Nullable<double> amount { get; set; }
        public Nullable<int> shopId { get; set; }
    }
}
