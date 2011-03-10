using System.Configuration;
using Castle.Core.Resource;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Core.Data;
using Core.Repositories;

namespace MVCFirst
{
	public class WindsorInstaller:IWindsorInstaller
	{
		

		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(
				Component.For<ISessionProvider>().
					ImplementedBy<SqlLiteSessionProvider>().
					DependsOn(new {dbFile = ConfigurationManager.AppSettings["DBFile"]}).LifeStyle.Singleton);
			container.Register(AllTypes.FromAssembly(typeof (BlogRepository).Assembly).
				                            Where(t => t.Namespace == "Core.Repositories" && t.IsClass).WithService.DefaultInterface().Configure(c=>c.LifeStyle.Transient));
			var xmlInterpreter = new XmlInterpreter();
			xmlInterpreter.ProcessResource(new ConfigResource("castle"),store);

		}
	}
}
