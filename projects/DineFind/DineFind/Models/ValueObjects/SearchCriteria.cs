using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;

namespace DineFind.Models.ValueObjects
{
    public class SearchCriteria
    {
        public Cuisine Cuisine { get; set; }
        public Coordinates Location { get; set; }
        public PriceRange PriceRange { get; set; }
    }
}