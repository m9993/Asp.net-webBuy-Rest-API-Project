namespace webBuy_with_Rest_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comission
    {
        public int comissionId { get; set; }
        public string date { get; set; }
        public Nullable<double> amount { get; set; }
        public int shopId { get; set; }
    }
}
