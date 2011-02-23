using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Automapping;

namespace Core.Data
{
	public class AppAutoConfiguration : DefaultAutomappingConfiguration
	{
//		public override bool IsComponent(Type type)
//		{
//			return type == typeof(Name);
//		}
		public override bool ShouldMap(Type type)
		{
			return type.Namespace == "Core.Entities" || type.Namespace == "Core.ValueTypes";
		}
	}
}
