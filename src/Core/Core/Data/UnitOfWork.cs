using System;
using NHibernate;

namespace Core.Data
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{


		ITransaction _transaction;
		public UnitOfWork(ISessionProvider sessionProvider)
		{

			CurrentSession = sessionProvider.Session;
			try
			{
				_transaction = CurrentSession.BeginTransaction();
			}
			catch { }
		}
		public ISession CurrentSession { get; private set; }


		public void Dispose()
		{
			_transaction.Commit();
			_transaction.Dispose();
			CurrentSession.Dispose();
		}
		public void Commit()
		{
			_transaction.Commit();
		}
	}
}
