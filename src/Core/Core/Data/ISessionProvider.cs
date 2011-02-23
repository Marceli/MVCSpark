using NHibernate;
namespace Core.Data
{
	public interface ISessionProvider
	{
		ISession Session { get; }
	}
}
