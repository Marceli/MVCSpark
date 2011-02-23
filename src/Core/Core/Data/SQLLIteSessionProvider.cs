using System;
using System.IO;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Core.Data
{
	public class SqlLiteSessionProvider:ISessionProvider
	{
		private ISessionFactory factory;

		public SqlLiteSessionProvider()
		{
			factory = Fluently.Configure().
				Database(SQLiteConfiguration.Standard.UsingFile(GetDbFile()).ShowSql())
				.Mappings(SetMappings)
				.ExposeConfiguration(BuildSchema).BuildSessionFactory();
		}

		public void SetMappings(MappingConfiguration m)
		{
			m.AutoMappings.Add(GetModel());
		}
		public AutoPersistenceModel GetModel()
		{
			AutoPersistenceModel model = AutoMap.AssemblyOf<Blog>(new AppAutoConfiguration())
				.Conventions.AddFromAssemblyOf<Blog>();

			model.BuildMappings();
			model.WriteMappingsTo(GetDataBaseDirectoryPath());
			return model;
		}

		public static string GetDataBaseDirectoryPath()
		{
			DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

			while (!dir.FullName.ToLower().EndsWith("src"))
			{
				dir = dir.Parent;
			}
			dir = dir.Parent;
			var result = Path.Combine(dir.FullName, @"db");
			return result;
		}

		private string GetDbFile()
		{
			return Path.Combine(GetDataBaseDirectoryPath(),"test.db");
		}

		public ISession Session
		{
			get { return factory.OpenSession(); }
		}

		private void BuildSchema(NHibernate.Cfg.Configuration config)
        {
		    Console.WriteLine(GetDbFile());
		    if (File.Exists(GetDbFile()))
		        File.Delete(GetDbFile());
		    new SchemaExport(config).Create(true, true);
		}
	}
}
