using System;
using System.Diagnostics;
using NHibernate;

namespace Core.Data
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{


		ITransaction _transaction;
		private ISession _session;

		public UnitOfWork(ISessionProvider sessionProvider)
		{

			_session = sessionProvider.Session;
			
		}
		public ISession CurrentSession
		{
			get
			{
				if (_transaction == null)
					try
					{
						_transaction = _session.BeginTransaction();

					}
					catch { }
				return _session;

			}
		}


		public void Dispose()
		{
			if(_transaction!=null)
			{
				_transaction.Commit();
				_transaction.Dispose();
			}
			CurrentSession.Dispose();
		}
		public void Commit()
		{
			_transaction.Commit();
		}
	}
}
