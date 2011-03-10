using System.Collections.Generic;
using System.Linq;
using Core.Data;
using Core.Entities;
using NHibernate;
using NHibernate.Linq;


namespace Core.Repositories
{
	public class Repository<T> : IRepository<T> where T:IIdentityable
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

		public IEnumerable<T> GetAll()
		{
			return from entity in session.Query<T>() select entity;
		}
		public IEnumerable<T> GetPage(int pageNo,int pageSize)
		{
			return (from entity in session.Query<T>()  select entity).Take(pageSize).Skip(pageSize*pageNo);
		}

	}
}