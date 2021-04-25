using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webBuy_with_Rest_API.Models
{
    public class ChangePassword
    {
        [Required]
        public string OldPassword{ get; set; }

        [Required, MinLength(3, ErrorMessage = "Minimum Length is 3")]
        public string NewPassword { get; set; }

        [Required, MinLength(3, ErrorMessage = "Minimum Length is 3")]
        public string ConfirmNewPassword { get; set; }

    }
}