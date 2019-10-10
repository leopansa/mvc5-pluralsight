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

        // Later here we are gonna use Dependency Injection and Inversion of Control Container 
        // This uses the ContainerConfig Class and the AutoFac.Mvc Nuget package
        public HomeController(IRestaurantData db)
        {
            
            this.db = db; //this is the Dependecy Injection made by AutoFac
            //db = new InMemoryRestaurantData(); //Replace this with the Dependency Injection
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