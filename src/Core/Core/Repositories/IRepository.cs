using System.Collections.Generic;

namespace Core.Repositories
{
	public interface IRepository<T> where T : IIdentityable
	{
		T Get(long id);
		void Save(T entity);
		IEnumerable<T> GetAll();
		IEnumerable<T> GetPage(int pageNo, int pageSize);
	}
}