namespace webBuy_with_Rest_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contact
    {
        public int contactId { get; set; }
        public string sender { get; set; }
        public string receiver { get; set; }
        public string message { get; set; }
        public string date { get; set; }
        public Nullable<int> contactStatus { get; set; }
    }
}
