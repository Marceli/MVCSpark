using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Core.Entities
{
	public class Comment:IIdentityable
	{
		
		public virtual long Id {get;set;}
		public virtual Blog Blog { get; set; }
		public virtual string Author { get; set; }
		public virtual string Body { get; set; }
	}
}