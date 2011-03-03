using System;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Core.Data;
using Core.Repositories;
using MVCFirst.Controllers;

namespace MVCFirst
{
	public class WinsorConfiguration
	{
		private bool isTest;

		public WinsorConfiguration()
		{
		}

		public WinsorConfiguration(bool isTest)
		{
			this.isTest = isTest;
		}

		public WindsorContainer GetContainer()
		{
			var windsorContainer = new WindsorContainer();
        	windsorContainer.Register(AllTypes.FromAssembly(typeof (HomeController).Assembly).
        	                    	Where(IsController).
        	                    	Configure(component => component.LifeStyle.Transient).
        	                    	Configure(component => component.Named(component.Implementation.FullName.ToLower())));

			windsorContainer.Register(Component.For<ISessionProvider>().ImplementedBy<SqlLiteSessionProvider>().LifeStyle.Singleton);

			if (isTest)
			{
				windsorContainer.Register(Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>().LifeStyle.Transient);
			}
			else
			{
				windsorContainer.Register(Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>().LifeStyle.PerWebRequest);
			}
			windsorContainer.Register(AllTypes.FromAssembly(typeof (BlogRepository).Assembly).
			                          	Where(t => t.Namespace == "Core.Repositories").
			                          	Configure(component => component.LifeStyle.Transient));
			                          	//Configure(component => component.Named(component.Implementation.FullName.ToLower())));


			return windsorContainer;
		}
		public static bool IsController(Type type)
		{
			return type != null
				&& type.IsPublic
				&& type.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)
				&& !type.IsAbstract
				&& typeof(IController).IsAssignableFrom(type);
		}
	}
}
