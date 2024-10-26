using System;
using System.Web.Mvc;
using DineFind.Models.Entities;
using DineFind.Models.ValueObjects;
using DineFind.Services;
using System.Collections.Generic;

namespace DineFind.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly SearchService _searchService;
        private readonly RestaurantRecommendationService _recommendationService;

        public RestaurantController(SearchService searchService, RestaurantRecommendationService recommendationService)
        {
            _searchService = searchService;
            _recommendationService = recommendationService;
        }

        // GET: Restaurant
        public ActionResult Index()
        {
            var restaurants = _searchService.SearchRestaurants(new SearchCriteria());
            return View(restaurants);
        }

        // GET: Restaurant/Details/5
        public ActionResult Details(int id)
        {
            var restaurant = _searchService.GetRestaurantById(id);
            if (restaurant == null)
                return HttpNotFound();
            return View(restaurant);
        }

        // POST: Restaurant/Search
        [HttpPost]
        public ActionResult Search(SearchCriteria criteria)
        {
            var results = _searchService.SearchRestaurants(criteria);
            return View("Index", results);
        }

        // GET: Restaurant/Recommend/5
        public ActionResult Recommend(int userId)
        {
            var recommendations = _recommendationService.RecommendRestaurants(userId);
            return View("Index", recommendations);
        }
    }
}