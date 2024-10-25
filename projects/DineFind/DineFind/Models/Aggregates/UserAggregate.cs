using DineFind.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DineFind.Models.Aggregates
{
    public class UserAggregate
    {
        // Root Entity: User
        public int UserId { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public List<Preference> Preferences { get; private set; }
        private List<Review> _reviews;
        public IReadOnlyCollection<Review> Reviews => _reviews.AsReadOnly();

        public UserAggregate(int userId, string username, string email)
        {
            UserId = userId;
            Username = username;
            Email = email;
            Preferences = new List<Preference>();
            _reviews = new List<Review>();
        }

        // Method to add or update preferences
        public void SetPreferences(List<Preference> preferences)
        {
            Preferences = preferences;
        }

        // Method to add a review
        public void AddReview(Review review)
        {
            if (_reviews.Any(r => r.RestaurantId == review.RestaurantId))
                throw new InvalidOperationException("User can only review a restaurant once.");

            _reviews.Add(review);
        }
    }
}