using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DineFind.Models.Entities
{
    public class RestaurantOwner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Restaurant> Restaurants { get; set; }
    }
}