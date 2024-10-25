using DineFind.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DineFind.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<Preference> Preferences { get; set; }
        public List<Review> Reviews { get; set; }
    }
}