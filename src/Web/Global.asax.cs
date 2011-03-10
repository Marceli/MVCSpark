using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Core.Data;

namespace MVCFirst
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new { controller = "Blog", action = "Index", id = UrlParameter.Optional } // Parameter defaults
			);

		}

		public WindsorContainer Container { get; private set; }


		protected void Application_Start()
		{
			// here is comment with gold in it
			// silver in it
			AreaRegistration.RegisterAllAreas();
			RegisterRoutes(RouteTable.Routes);
			Container = new WindsorContainer();
			Container.Install(FromAssembly.This());
			ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(Container));
			var sessionProvider = Container.Resolve<ISessionProvider>();
			sessionProvider.Populate();
		}
		protected void Application_End()
		{
			Container.Dispose();
		}
		
	}
}