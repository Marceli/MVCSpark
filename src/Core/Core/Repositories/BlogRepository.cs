using System.Collections.Generic;
using System.Linq;
using Core.Data;
using Core.Entities;
using NHibernate;
using NHibernate.Linq;


namespace Core.Repositories
{
	public class BlogRepository:Repository<Blog>
	{
		

		public BlogRepository(IUnitOfWork unitOfWork):base(unitOfWork)
		{
			
		}
		public Blog GetWithComments(long id)
		{
			return session.Query<Blog>().Where(b => b.Id == id).Fetch(b => b.Comments).ToList()[0];
		}
		

	}
}
