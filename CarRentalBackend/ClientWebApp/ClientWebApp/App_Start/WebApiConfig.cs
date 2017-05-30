using ClientWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace ClientWebApp
{
    public static class WebApiConfig
    {
        public static ServiceReference1.Service1Client Logger = new ServiceReference1.Service1Client();

        public static void Register(HttpConfiguration config)
        {
           // Logger.Mode = Logger.State.INFO;
            // Web API configuration and services

            // Web API routes
            /*config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }*/

            ODataModelBuilder builder = new ODataConventionModelBuilder();

            builder.EntitySet<Client>("Clients");
            

            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                 model: builder.GetEdmModel());

            
        }
    }
}
