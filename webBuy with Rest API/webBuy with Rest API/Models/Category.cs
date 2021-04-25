namespace webBuy_with_Rest_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        [Required]
        public int categoryId { get; set; }


        [Required]
        public string name { get; set; }
    }
}
