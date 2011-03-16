using System.Configuration;
using System.Diagnostics;
using Core.Data;
using Core.Entities;
using Core.Repositories;
using NUnit.Framework;
using System.Linq;
using NHibernate.Linq;

namespace MVCFirstTest.Data
{
	[TestFixture]
	public class BlogRepositoryTest
	{
		private IDb blogRepository;
		private IUnitOfWork unitOfWork;
		private ISessionProvider sessionProvider = new SqlLiteSessionProvider("BlogRepositoryTest.db");

		[SetUp]
		public void SetUp()
		{
			unitOfWork = new UnitOfWork(sessionProvider);
			blogRepository = new Db(unitOfWork);
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
			blogRepository.Session.Save(blog);
			reset();
			var fromDb=blogRepository.Blogs.Single(b=>b.Id==blog.Id);
			Assert.AreEqual(blog.Title,fromDb.Title);
		}
		[Test]
		public void CanSaveAndReadBlogWithComments()
		{
			var blog = new Blog { Title = "title", Body = "Body" };
			blog.AddComment(new Comment(){Author = "Marcel",Body="Body"});
			blogRepository.Session.Save(blog);
			reset();
			Debug.WriteLine("Before Getting Blog");
			var fromDb = blogRepository.Blogs.Single(b=>b.Id==blog.Id);
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
			blogRepository.Session.Save(blog);
			reset();
			Debug.WriteLine("Before Getting Blog");
			var fromDb = blogRepository.Blogs.Where(b=>b.Id==blog.Id).Fetch(b => b.Comments).ToList()[0];
			//var fromDb = blogRepository.GetWithComments(blog.Id);
			Debug.WriteLine("Before reading Blog property");

			Assert.AreEqual("title", fromDb.Title);
			Debug.WriteLine("Before reading comments");

			Assert.AreEqual(1, fromDb.Comments.ToList().Count);
		}

	}
}
