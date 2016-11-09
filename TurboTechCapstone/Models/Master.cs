using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace TurboTechCapstone.Models
{
    public class Master
    {
        [Key]
        public int TransactionID { get; set; }

        public int CustomerID { get; set; }

        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public ICollection<Customer> Customer { get; set; }
        public ICollection<Product> Product { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}