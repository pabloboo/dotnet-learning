using DineFind.Models.Entities;
using DineFind.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DineFind.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Cuisine Cuisine { get; set; }
        public double Rating { get; set; }
        public List<Review> Reviews { get; set; }
        public Coordinates Location { get; set; }
    }
}