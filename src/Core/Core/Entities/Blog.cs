using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
	public class Blog
	{
		public int Id { get; internal set; }
		public string Title { get; set; }
		public string Body { get; set; }
		public IList<Comment> Comments=new List<Comment>();
	}
}
