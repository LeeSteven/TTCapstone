using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TurboTechCapstone.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double SubTotal { get; set; }
        public double Total { get; set; }
        public string Date { get; set; }
        public string Image { get; set; }
        public int CustomerId { get; set; }


        public virtual Customer Customer { get; set; }
       
        public virtual ICollection<OrderAndProducts> OrderAndProducts { get; set; }
    }
}