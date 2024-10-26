using System.Web.Mvc;
using DineFind.Models.Entities;
using DineFind.Services;
using System.Collections.Generic;
using DineFind.Repositories;

namespace DineFind.Controllers
{
    public class UserController : Controller
    {
        private readonly UserPreferenceService _userPreferenceService;

        // Default parameterless constructor
        public UserController()
        {
            _userPreferenceService = new UserPreferenceService(new UserRepository(new Models.DineFindBdContext()));
        }

        public UserController(UserPreferenceService userPreferenceService)
        {
            _userPreferenceService = userPreferenceService;
        }

        // GET: User
        public ActionResult Index()
        {
            // This would typically pull all users for display (implementation not shown)
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var userPreferences = _userPreferenceService.GetUserPreferences(id);
            if (userPreferences == null)
                return HttpNotFound();
            return View(userPreferences);
        }

        // POST: User/UpdatePreferences/5
        [HttpPost]
        public ActionResult UpdatePreferences(int userId, List<Preference> preferences)
        {
            _userPreferenceService.UpdateUserPreferences(userId, preferences);
            return RedirectToAction("Details", new { id = userId });
        }
    }
}
