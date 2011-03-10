using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Core.Resource;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Castle.Windsor.Installer;
using Core.Data;
using Core.Repositories;
using MVCFirst;
using MVCFirst.Controllers;
using NUnit.Framework;

namespace MVCFirstTest
{
	[TestFixture]
	public class WindsorConfigurationTest
	{
		private WindsorContainer windsorContainer; 

		[SetUp]
		public void SetUp()
		{
			windsorContainer = new WindsorContainer();
			windsorContainer.Install(FromAssembly.Containing(typeof(HomeController)));
			
		}

        [Test]     
		public void CanGetWindsorcontainer()
		{
			Assert.IsNotNull(windsorContainer);
		}
		[Test]
		public void CanGetUnitOfWork()
		{
			Assert.IsNotNull(windsorContainer.Resolve<IUnitOfWork>());
		}
		[Test]
		public void UnitOfWorkCanReturnSession()
		{
			Assert.IsNotNull(windsorContainer.Resolve<IUnitOfWork>().CurrentSession);
		}
        [Test]
		public  void ForBlogRepositoryInterface_ContainerShouldReturn_BlogRepository()
		{
			Assert.IsNotNull(windsorContainer.Resolve<IBlogRepository>() as BlogRepository);
		}
		[Test]
		public void ForIUnitOfWorkInterface_ContainerShouldReturn_UnitOfWork()
		{
			Assert.IsNotNull(windsorContainer.Resolve<IUnitOfWork>() as UnitOfWork);
		//[	windsorContainer.Resolve()
		}
		[Test]
		public void ForSessionProvider_ContainerShouldPopulateDBFile_WithValuteFromConfig()
		{
			var sessionProvider = windsorContainer.Resolve<ISessionProvider>();
			Assert.AreEqual("test.db",sessionProvider.DbFile);
			//[	windsorContainer.Resolve()
		}
	}
}
