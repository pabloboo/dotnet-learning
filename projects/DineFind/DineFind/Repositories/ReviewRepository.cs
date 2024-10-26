using DineFind.Models;
using DineFind.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DineFind.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DineFindBdContext _context;

        // Constructor injection of the DineFindBdContext
        public ReviewRepository(DineFindBdContext context)
        {
            _context = context;
        }

        public void Submit(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }

        public List<Review> GetReviewsByRestaurant(int restaurantId)
        {
            return _context.Reviews
                .Where(r => r.RestaurantId == restaurantId)
                .ToList();
        }
    }
}