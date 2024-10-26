using DineFind.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DineFind.Repositories
{
    public interface IUserRepository
    {
        User GetById(int id);
        void UpdatePreferences(User user);
    }
}