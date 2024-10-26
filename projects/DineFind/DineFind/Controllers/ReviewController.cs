using System.Web.Mvc;
using DineFind.Models.Entities;
using DineFind.Services;
using System.Collections.Generic;
using DineFind.Repositories;

namespace DineFind.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ReviewService _reviewService;

        // Default parameterless constructor
        public ReviewController()
        {
            _reviewService = new ReviewService(new ReviewRepository(new Models.DineFindBdContext()));
        }

        public ReviewController(ReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // GET: Review
        public ActionResult Index(int restaurantId)
        {
            var reviews = _reviewService.GetReviewsByRestaurant(restaurantId);
            return View(reviews);
        }

        // GET: Review/Create
        public ActionResult Create(int restaurantId)
        {
            ViewBag.RestaurantId = restaurantId;
            return View();
        }

        // POST: Review/Create
        [HttpPost]
        public ActionResult Create(Review review)
        {
            try
            {
                _reviewService.SubmitReview(review);
                return RedirectToAction("Index", new { restaurantId = review.RestaurantId });
            }
            catch
            {
                return View();
            }
        }
    }
}