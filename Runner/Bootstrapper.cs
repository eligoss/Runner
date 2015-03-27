using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Runner.BLL;
using Runner.DAL;
using Runner.Common;
using Runner.Controllers;

namespace Runner
{
    public class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<IComandExecute, CommandExecute>();
            container.RegisterType<IUserProvider, UserProvider>();
            container.RegisterType<IXmlProvider, UserXmlProvider>();
            container.RegisterType<IFileWorker, FileWorker>();
            container.RegisterType<IConfigManager, ConfigManager>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            
            return container;
        }
    }
}