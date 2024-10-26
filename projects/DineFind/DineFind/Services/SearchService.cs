using System.Collections.Generic;
using DineFind.Models;
using DineFind.Models.Entities;
using DineFind.Models.ValueObjects;
using DineFind.Repositories;

namespace DineFind.Services
{
    public class SearchService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public SearchService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public List<Restaurant> SearchRestaurants(SearchCriteria criteria)
        {
            return _restaurantRepository.Search(criteria);
        }
    }
}