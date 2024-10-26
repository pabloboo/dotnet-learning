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

        //public List<Restaurant> Search(SearchCriteria criteria)
        //{
        //    return _context.Restaurants
        //        .Where(r =>
        //            (criteria == null || criteria.Cuisine == null || string.IsNullOrEmpty(criteria.Cuisine.Name) || r.Cuisine.Name == criteria.Cuisine.Name) &&
        //            (criteria.Location == null || (r.Location.Latitude.Equals(criteria.Location.Latitude)) && (r.Location.Longitude.Equals(criteria.Location.Longitude)))
        //        )
        //        .ToList();
        //}

        public List<Restaurant> Search(SearchCriteria criteria)
        {
            var query = _context.Restaurants.AsQueryable();

            if (criteria.Cuisine != null && !string.IsNullOrEmpty(criteria.Cuisine.Name))
            {
                query = query.Where(r => r.Cuisine.Name == criteria.Cuisine.Name);
            }

            // Apply other criteria as needed

            return query.ToList();
        }

    }
}