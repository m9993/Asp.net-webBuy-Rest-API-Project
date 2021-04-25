namespace webBuy_with_Rest_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Payment
    {
        [Required]
        public int paymentId { get; set; }

        [Required]
        public string paymentMethod { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid delivery charge")]
        public Nullable<double> deliveryCharge { get; set; }
    }
}
