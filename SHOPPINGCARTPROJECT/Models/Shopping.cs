using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHOPPINGCARTPROJECT.Models
{
    public class Shopping
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
       
    }
}