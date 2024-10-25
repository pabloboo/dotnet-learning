using DineFind.Models.Aggregates;
using DineFind.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DineFind.Models.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public RatingScore Rating { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public User User { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}