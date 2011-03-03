﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Core.Data
{
	public class IdGenerationConvention : IIdConvention
	{
		#region IIdConvention Members

		public void Apply(IIdentityInstance instance)
		{
			instance.GeneratedBy.HiLo("1000");
		}

		#endregion
	}
}
