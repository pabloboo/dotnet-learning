using DineFind.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;

namespace DineFind.Models.Entities
{
    public class Preference
    {
        public int Id { get; set; }
        public CuisinePreference CuisinePreference { get; set; }
        public PriceRange PriceRange { get; set; }
        public int Distance { get; set; } // Distance in kilometers
    }
}