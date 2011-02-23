using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Data;
using NHibernate;
using NHibernate.Linq;

namespace Core.Repositories
{
	public class BlogRepository
	{
		private ISession session;

		public BlogRepository(IUnitOfWork unitOfWork)
		{
			this.session = unitOfWork.CurrentSession;
		}
		public Blog GetBlog(int id)
		{
			return session.Query<Blog>().First<Blog>(t=>t.Id=id);
		}
	}
}
