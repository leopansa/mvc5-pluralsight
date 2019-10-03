﻿using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "Scott's Pizza", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 2, Name = "Tersiguels", Cuisine = CuisineType.French},
                new Restaurant { Id = 3, Name = "Mango Groove", Cuisine = CuisineType.Indian},
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            // Linq
            // r = restaurant 
            return restaurants.OrderBy(r => r.Name);
        }


    }
}