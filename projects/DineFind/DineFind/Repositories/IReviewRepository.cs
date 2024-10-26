using DineFind.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DineFind.Repositories
{
    public interface IReviewRepository
    {
        void Submit(Review review);
        List<Review> GetReviewsByRestaurant(int restaurantId);
    }
}