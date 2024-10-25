using DineFind.Models.Entities;
using DineFind.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DineFind.Models.Aggregates
{
    public class RestaurantAggregate
    {
        // Root Entity: Restaurant
        public int RestaurantId { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public Cuisine Cuisine { get; private set; }
        public Coordinates Coordinates { get; private set; }
        private readonly List<Review> _reviews;
        public IReadOnlyCollection<Review> Reviews => _reviews.AsReadOnly();
        public double AverageRating { get; private set; }

        public RestaurantAggregate(int restaurantId, string name, string address, Cuisine cuisine, Coordinates coordinates)
        {
            RestaurantId = restaurantId;
            Name = name;
            Address = address;
            Cuisine = cuisine;
            Coordinates = coordinates;
            _reviews = new List<Review>();
            AverageRating = 0;
        }

        // Method to add a new review
        public void AddReview(Review review)
        {
            if (_reviews.Any(r => r.UserId == review.UserId))
                throw new InvalidOperationException("User can only review a restaurant once.");

            _reviews.Add(review);
            CalculateAverageRating();
        }

        // Private method to calculate the average rating
        private void CalculateAverageRating()
        {
            if (_reviews.Count == 0)
            {
                AverageRating = 0;
                return;
            }

            AverageRating = _reviews.Average(r => r.Rating.Score);
        }
    }
}