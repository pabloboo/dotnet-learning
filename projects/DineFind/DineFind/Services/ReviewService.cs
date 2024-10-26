using System.Collections.Generic;
using DineFind.Models.Entities;
using DineFind.Repositories;

namespace DineFind.Services
{
    public class ReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public void SubmitReview(Review review)
        {
            _reviewRepository.Submit(review);
        }

        public List<Review> GetReviewsByRestaurant(int restaurantId)
        {
            return _reviewRepository.GetReviewsByRestaurant(restaurantId);
        }
    }
}