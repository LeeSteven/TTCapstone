using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TurboTechCapstone.Models
{
    public class OrderAndProducts
    {
        public int Id { get; set; }
        public int Product_Id { get; set; }
        public int Order_Id { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}