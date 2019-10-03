using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class HomeController : Controller
    {
        IRestaurantData db; //Chp 2. Lesson 8 Temporary solution to access data.

        public HomeController()
        {
            //Later here we are gonna use Dependency Injection
            db = new InMemoryRestaurantData();
        }
        public ActionResult Index()
        {
            //Building Model
            var model = db.GetAll(); //This is the Model
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}