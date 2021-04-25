namespace webBuy_with_Rest_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Shop
    {
        [Required]
        public int shopId { get; set; }
        public string name { get; set; }
        public string email { get; set; }

        [Required]
        [Range(0, 1)]
        public Nullable<int> shopStatus { get; set; }
        public Nullable<double> balance { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public Nullable<int> setComission { get; set; }
    }
}
