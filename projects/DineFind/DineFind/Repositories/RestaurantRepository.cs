using DineFind.Models;
using DineFind.Models.Entities;
using DineFind.Models.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace DineFind.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly DineFindBdContext _context;

        // Constructor injection of the DineFindBdContext
        public RestaurantRepository(DineFindBdContext context)
        {
            _context = context;
        }

        public Restaurant GetById(int id)
        {
            return _context.Restaurants.Find(id);
        }

        public List<Restaurant> Search(SearchCriteria criteria)
        {
            return _context.Restaurants
                .Where(r =>
                    (string.IsNullOrEmpty(criteria.Cuisine.Name) || r.Cuisine.Name == criteria.Cuisine.Name) &&
                    (criteria.Location == null || r.Location.Equals(criteria.Location))
                )
                .ToList();
        }
    }
}