using System;
using System.Diagnostics;
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
				Debug.WriteLine("New Db Session");
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
