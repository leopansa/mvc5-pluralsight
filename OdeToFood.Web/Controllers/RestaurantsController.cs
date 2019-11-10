using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData db; 

        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            //id from the URL that is defined int the RouteConfig.cs
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");

            } else
            {
                return View(model);
            }

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            //model Binding -> Name + Cuisine = Restaurant
            
            //-- Validation inside the Controller from the View
            /*
            if(String.IsNullOrEmpty(restaurant.Name))
            {
                ModelState.AddModelError(nameof(restaurant.Name), "The name is required!");
            }
            */
            if(ModelState.IsValid)
            {
                db.Add(restaurant);
                return View();
            }
            
            return View();
        }
    }
}