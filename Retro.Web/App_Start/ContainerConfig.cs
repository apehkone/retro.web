using System;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Commando.Core.Util;
using Microsoft.AspNet.Identity;
using Retro.Domain.Entities;
using Retro.Domain.Persistence;
using Retro.Web.Security;

namespace Retro.Web
{
    public class ContainerConfig
    {
        public static void Run() {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<DbConfig>().As<IDbConfig>();
            builder.RegisterType<DbContext>().As<IDbContext>();
            builder.RegisterType<DocumentRepository<Retrospective>>().As<IDocumentRepository<Retrospective>>();

            builder.RegisterBasicDispatcher(assembly => assembly.GetCustomAttributes(false).Cast<Attribute>().Any(attribute => attribute is AssemblyProductAttribute && ((AssemblyProductAttribute)attribute).Product.StartsWith("Retro")));

            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}