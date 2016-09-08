﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Owin;
using Microsoft.Owin.Security.OAuth; 
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;


namespace Codevelop.Service.Host
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
