﻿
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Core.Data;

using MVCFirst.Controllers;

namespace MVCFirst
{
	public class ControllersInstaller:IWindsorInstaller
	{
	    public void Install(IWindsorContainer container, IConfigurationStore store)
	    {
			
			container.Register(FindControllers().Configure(ConfigureControllers()));
		}
		private ConfigureDelegate ConfigureControllers()
	    {
	        return c => c.LifeStyle.Transient;
	    }
	 
		private BasedOnDescriptor FindControllers()
		{
			return AllTypes.FromThisAssembly()
				.BasedOn<IController>()
				.If(Component.IsInSameNamespaceAs<HomeController>())
				.If(t => t.Name.EndsWith("Controller"));
		}
	}
}
