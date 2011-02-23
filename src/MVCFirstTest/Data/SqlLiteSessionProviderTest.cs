using NUnit.Framework;
using Core.Data;
namespace MVCFirstTest.Data
{
	[TestFixture]
	public class SqlLiteSessionProviderTest
	{
		[Test]
		public void CanObtainSession()
		{
			ISessionProvider sessionProvider = new SqlLiteSessionProvider();
			Assert.IsNotNull(sessionProvider.Session);
			
		}
	}
}