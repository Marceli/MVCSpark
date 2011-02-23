using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace Core.Data
{
	public interface IUnitOfWork
	{
		ISession CurrentSession { get; }
		void Dispose();
		void Commit();
	}
}
