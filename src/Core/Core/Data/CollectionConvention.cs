using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Core.Data
{
	public class CollectionConvention : ICollectionConvention
	{
		#region ICollectionConvention Members

		public void Apply(ICollectionInstance instance)
		{
			instance.Cascade.SaveUpdate();
			instance.Inverse();
		}

		#endregion
	}
}
