using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using CP.Data.Services;
using CP.Data.Services.DepotData;
using CP.Data.Services.SiteData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace CP.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<DepotData>().As<IDepotData>().InstancePerRequest();
            builder.RegisterType<SiteData>().As<ISiteData>().InstancePerRequest();
            builder.RegisterType<AppDbContext>().InstancePerRequest();
            
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}