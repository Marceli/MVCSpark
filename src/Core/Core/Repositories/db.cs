using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Data;
using Core.Entities;
using NHibernate;
using NHibernate.Linq;

namespace Core.Repositories
{

	public interface IDb 
	{
		IQueryable<Blog> Blogs { get; }
		ISession Session { get; }
	}

	public class Db : IDb
	{
		private ISession session;
		public Db(IUnitOfWork unitOfWork)
		{
			session = unitOfWork.CurrentSession;

		}
		public IQueryable<Blog> Blogs
		{
			get
			{
				return session.Query<Blog>();
			}
		}
		public ISession Session
		{
			get
			{
				return session;
			}
		}

	}
}
