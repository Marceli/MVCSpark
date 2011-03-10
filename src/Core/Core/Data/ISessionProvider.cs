using NHibernate;
namespace Core.Data
{
	public interface ISessionProvider
	{
		ISession Session { get; }
		void Populate();
		string DbFile { get; }
	}
}
