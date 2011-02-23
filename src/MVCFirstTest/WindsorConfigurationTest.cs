using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using Core.Data;
using MVCFirst;
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
			windsorContainer = new WinsorConfiguration(true).GetContainer();
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
	}
}
