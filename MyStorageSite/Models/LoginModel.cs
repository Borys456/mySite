﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyStorageSite.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Empty Email")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Empty password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
