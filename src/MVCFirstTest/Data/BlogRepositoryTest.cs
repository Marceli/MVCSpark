using System.Configuration;
using System.Diagnostics;
using Core.Data;
using Core.Entities;
using Core.Repositories;
using NUnit.Framework;
using System.Linq;

namespace MVCFirstTest.Data
{
	[TestFixture]
	public class BlogRepositoryTest
	{
		private BlogRepository blogRepository;
		private IUnitOfWork unitOfWork;
		private ISessionProvider sessionProvider = new SqlLiteSessionProvider(ConfigurationManager.AppSettings["DBFile"]);

		[SetUp]
		public void SetUp()
		{
			unitOfWork = new UnitOfWork(sessionProvider);
			blogRepository = new BlogRepository(unitOfWork);
		}

		[TearDown]
		public void TearDown()
		{
			unitOfWork.Dispose();
		}
		private void reset()
		{
			TearDown();
			SetUp();
		}

		[Test]
		public void CanSaveAndReadBlog()
		{
			var blog = new Blog{Title = "title", Body = "Body"};
			blogRepository.Save(blog);
			reset();
			var fromDb=blogRepository.Get(blog.Id);
			Assert.AreEqual(blog.Title,fromDb.Title);
		}
		[Test]
		public void CanSaveAndReadBlogWithComments()
		{
			var blog = new Blog { Title = "title", Body = "Body" };
			blog.AddComment(new Comment(){Author = "Marcel",Body="Body"});
			blogRepository.Save(blog);
			reset();
			Debug.WriteLine("Before Getting Blog");
			var fromDb = blogRepository.Get(blog.Id);
			Debug.WriteLine("Before reading Blog property");

			Assert.AreEqual("title",fromDb.Title);
			Debug.WriteLine("Before reading comments");

			Assert.AreEqual(1, fromDb.Comments.ToList().Count);
		}
		[Test]
		public void CanSaveAndEarlyReadBlogWithComments()
		{
			var blog = new Blog { Title = "title", Body = "Body" };
			blog.AddComment(new Comment() { Author = "Marcel", Body = "Body" });
			blogRepository.Save(blog);
			reset();
			Debug.WriteLine("Before Getting Blog");
			var fromDb = blogRepository.GetWithComments(blog.Id);
			Debug.WriteLine("Before reading Blog property");

			Assert.AreEqual("title", fromDb.Title);
			Debug.WriteLine("Before reading comments");

			Assert.AreEqual(1, fromDb.Comments.ToList().Count);
		}

	}
}
