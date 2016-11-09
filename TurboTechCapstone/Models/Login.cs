using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TurboTechCapstone.Models
{
    public class Login
    {
        [Key, ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }


        public virtual Customer Customer { get; set; }
    }
}