
using System.Collections.Generic;


namespace Core.Entities
{
	public class Blog:IIdentityable
	{
		public virtual long Id { get; set; }
		public virtual string Title { get; set; }
		public virtual string Body { get; set; }
		IList<Comment> comments=new List<Comment>();
		public virtual IEnumerable<Comment> Comments
		{
			get { return comments; }
			set { comments = (IList < Comment >) value; }
		}
		public virtual void AddComment(Comment comment)
		{
			comments.Add(comment);
			comment.Blog = this;

		}
	}
}
