using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi; //nuget package
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http; //WebApi
using System.Web.Mvc;

// to follow the namespaces from the other files in App_Start
namespace OdeToFood.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            //Autofac API
            var builder = new ContainerBuilder();

            //MvcApplication is define in the class of Global.asax from the start point of the Application
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            //builder.RegisterType<InMemoryRestaurantData>()
            builder.RegisterType<SqlRestaurantData>().As<IRestaurantData>()
                .InstancePerRequest();
            //.SingleInstance(); //this will never be use in real application because it would be only an one instance from all the users of the data.
            builder.RegisterType<OdeToFoodDbContext>().InstancePerRequest();

            var container = builder.Build();
            
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); //mvc
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container); //webApi

        }
    }
}