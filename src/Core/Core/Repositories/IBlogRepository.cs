using Core.Entities;

namespace Core.Repositories
{
	public interface IBlogRepository:IRepository<Blog>
	{
		Blog GetWithComments(long id);
	}
}