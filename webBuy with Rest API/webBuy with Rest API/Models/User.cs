namespace webBuy_with_Rest_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public int userId { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string role { get; set; }
        public Nullable<int> userStatus { get; set; }
    }
}
