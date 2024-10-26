using System.Collections.Generic;
using System.Linq;
using DineFind.Models;
using DineFind.Models.Entities;
using DineFind.Models.ValueObjects;
using DineFind.Repositories;

namespace DineFind.Services
{
    public class RestaurantRecommendationService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IUserRepository _userRepository;

        public RestaurantRecommendationService(
            IRestaurantRepository restaurantRepository,
            IUserRepository userRepository)
        {
            _restaurantRepository = restaurantRepository;
            _userRepository = userRepository;
        }

        public List<Restaurant> RecommendRestaurants(int userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null || !user.Preferences.Any())
                return new List<Restaurant>();

            var cuisinePreference = user.Preferences.Select(p => p.CuisinePreference).FirstOrDefault();
            var cuisine = new Cuisine { Name = cuisinePreference.Name};

            // Filter restaurants based on user preferences (e.g., cuisine)
            return _restaurantRepository.Search(new SearchCriteria
            {
                Cuisine = cuisine
            });
        }
    }
}
