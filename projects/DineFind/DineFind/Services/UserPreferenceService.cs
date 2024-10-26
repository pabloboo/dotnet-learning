using System.Collections.Generic;
using DineFind.Models.Entities;
using DineFind.Repositories;

namespace DineFind.Services
{
    public class UserPreferenceService
    {
        private readonly IUserRepository _userRepository;

        public UserPreferenceService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void UpdateUserPreferences(int userId, List<Preference> preferences)
        {
            var user = _userRepository.GetById(userId);
            if (user != null)
            {
                user.Preferences = preferences;
                _userRepository.UpdatePreferences(user);
            }
        }

        public List<Preference> GetUserPreferences(int userId)
        {
            var user = _userRepository.GetById(userId);
            return user?.Preferences ?? new List<Preference>();
        }
    }
}