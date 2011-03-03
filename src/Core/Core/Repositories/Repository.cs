using System.Collections.Generic;
using System.Linq;
using Core.Data;
using Core.Entities;
using NHibernate;
using NHibernate.Linq;


namespace Core
{
	public class Repository<T> where T:IIdentityable
	{
		protected ISession session;

		public Repository(IUnitOfWork unitOfWork)
		{
			session = unitOfWork.CurrentSession;
		}

		public T Get(long id)
		{
			return session.Query<T>().First(t => t.Id == id);
		}
		


		public void Save(T entity)
		{
			session.SaveOrUpdate(entity);
		}

		public IList<T> GetAll()
		{
			var query = from entity in session.Query<T>() select entity;
			return query.ToList();
		}
	}
}