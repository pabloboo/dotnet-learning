using DineFind.Models.ValueObjects;
using DineFind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DineFind.Repositories
{
    public interface IRestaurantRepository
    {
        Restaurant GetById(int id);
        List<Restaurant> Search(SearchCriteria criteria);
    }
}