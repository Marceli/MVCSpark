using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using Core.Entities;
using NUnit.Framework;

namespace MVCFirstTest
{
	[TestFixture]
	public class BlogTest
	{
		[Test]
		public void CanCreateBlog()
		{
			Assert.IsNotNull(new Blog());
		}
		[Test]
		public void CanCreateBlogWithComments()
		{
			var blog = new Blog {Body = "Body", Title = "Title"};
			blog.AddComment(new Comment {Author="Author", Body="Body"});
			Assert.AreEqual(1,blog.Comments.ToList().Count);
		}
	}
}
