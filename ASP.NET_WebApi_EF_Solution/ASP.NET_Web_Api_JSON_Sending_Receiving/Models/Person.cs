using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NET_Web_Api_JSON_Sending_Receiving.Models
{
    public class Person
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
    }
}