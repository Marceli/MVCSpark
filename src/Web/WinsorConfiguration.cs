using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Core.Data;
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
			                          	Where(t => t is IController).
			                          	Configure(component => component.LifeStyle.Transient).
			                          	Configure(component => component.Named(component.Implementation.FullName.ToLower())))
				.Register(Component.For<ISessionProvider>().ImplementedBy<SqlLiteSessionProvider>().LifeStyle.Singleton);
			if (isTest)
			{
				windsorContainer.Register(Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>().LifeStyle.PerThread);
			}
			else
			{
				windsorContainer.Register(Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>().LifeStyle.PerWebRequest);
			}

			return windsorContainer;
		}
	}
}
