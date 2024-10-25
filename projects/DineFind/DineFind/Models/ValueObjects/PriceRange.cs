using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DineFind.Models.ValueObjects
{
    public class PriceRange
    {
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
    }
}