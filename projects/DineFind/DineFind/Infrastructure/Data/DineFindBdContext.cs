using DineFind.Models.Entities;
using DineFind.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DineFind.Models
{
    public class DineFindBdContext : DbContext
    {
        // Main entities in domain
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantOwner> RestaurantOwners { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Preference> Preferences { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configurations for value objects
            modelBuilder.ComplexType<Coordinates>();
            modelBuilder.ComplexType<Cuisine>();
            modelBuilder.ComplexType<CuisinePreference>();
            modelBuilder.ComplexType<PriceRange>();
            modelBuilder.ComplexType<RatingScore>();
            modelBuilder.ComplexType<SearchCriteria>();

            // Configurations for aggregates

            // Restaurant aggregate
            // Configuring Restaurant as the root entity of RestaurantAggregate
            modelBuilder.Entity<Restaurant>()
                .HasKey(r => r.Id)
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Restaurant>()
                .Property(r => r.Address)
                .IsRequired()
                .HasMaxLength(250);

            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.Reviews)
                .WithRequired(r => r.Restaurant)
                .HasForeignKey(r => r.RestaurantId);

            // Configure Reviews with a required relationship to User and Restaurant
            modelBuilder.Entity<Review>()
                .HasKey(r => r.Id)
                .HasRequired(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Review>()
                .Property(r => r.Rating.Score)
                .IsRequired();

            // User aggregate
            // Configure User as the root entity of UserAggregate
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id)
                .Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            // Configure the relationship between User and Preferences
            modelBuilder.Entity<User>()
                .HasMany(u => u.Preferences)
                .WithMany();

            // Configure the relationship between User and Reviews
            modelBuilder.Entity<User>()
                .HasMany(u => u.Reviews)
                .WithRequired(r => r.User)
                .HasForeignKey(r => r.UserId);

            // Configure Reviews with required relationships to Restaurant
            modelBuilder.Entity<Review>()
                .HasKey(r => r.Id)
                .HasRequired(r => r.Restaurant)
                .WithMany()
                .HasForeignKey(r => r.RestaurantId);

            // Configure Preferences as a separate entity if necessary
            modelBuilder.Entity<Preference>()
                .HasKey(p => p.Id);

            base.OnModelCreating(modelBuilder);
        }

        public void Seed()
        {
            // Check if the database already has data to prevent duplicating records
            //if (!Cuisines.Any())
            //{
            //    // Example data for Cuisines
            //    Cuisines.AddRange(new List<Cuisine>
            //    {
            //        new Cuisine { Name = "Italian" },
            //        new Cuisine { Name = "Mexican" },
            //        new Cuisine { Name = "Japanese" },
            //        // Add more cuisines as needed
            //    });
            //    SaveChanges();
            //}

            if (!Restaurants.Any())
            {
                // Example data for Restaurants
                Restaurants.AddRange(new List<Restaurant>
                {
                    new Restaurant { 
                        Name = "Mario's Italian Bistro", 
                        Address = "123 Main St, Anytown, USA",
                        Cuisine = new Cuisine() { Name = "Italian", Description = "" } ,
                        Rating = 4.5,
                        Location = new Coordinates() { Latitude = 40.7128, Longitude = 74.0060 }
                    },
                    new Restaurant { 
                        Name = "Casa Mexicana",
                        Address = "456 Elm St, Anytown, USA",
                        Cuisine = new Cuisine() { Name = "Mexican", Description = "" },
                        Rating = 4.0,
                        Location = new Coordinates() { Latitude = 40.7128, Longitude = 74.0060 }
                    },
                    new Restaurant {
                        Name = "Sushi Palace",
                        Address = "789 Oak St, Anytown, USA",
                        Cuisine = new Cuisine() { Name = "Japanese", Description = "" },
                        Rating = 4.2,
                        Location = new Coordinates() { Latitude = 40.7128, Longitude = 74.0060 }
                    },
                    // Add more restaurants with details
                });
                SaveChanges();
            }

            if (!Users.Any())
            {
                // Example data for Users
                Users.AddRange(new List<User>
                {
                    new User { Username = "John Doe", Email = "john@example.com" },
                    new User { Username = "Jane Smith", Email = "jane@example.com" },
                    // Add more users if needed
                });
                SaveChanges();
            }
        }
    }
}