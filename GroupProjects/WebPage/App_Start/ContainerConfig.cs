﻿using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WebPage
{
     public class ContainerConfig
     {
          internal static void RegisterContainer(HttpConfiguration httpConfiguration)
          {
               var builder = new ContainerBuilder();

               builder.RegisterControllers(typeof(MvcApplication).Assembly);
               builder.RegisterApiControllers(typeof(MvcApplication).Assembly);               
               var container = builder.Build();
               DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
               httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
          }
     }
}