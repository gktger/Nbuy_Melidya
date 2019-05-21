using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Melidya.Models
{
    public class SepetModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public int Stock { get; set; }
    }
}