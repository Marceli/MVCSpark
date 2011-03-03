using System;
using System.Configuration;
using System.IO;
using Core.Entities;
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
			var dbfile = ConfigurationManager.AppSettings["DBFile"];
			return Path.Combine(GetDataBaseDirectoryPath(),dbfile);
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
		public void Populate()
		{
			var session=this.Session;
			using(var transaction = session.BeginTransaction())
			{

				for (int i = 0; i < 100; i++)
				{
					var blog = new Blog{Body = "Body" + i, Title = "Title" + i};
					
					for (int j = 0; j < 5; j++)
					{
						var comment = new Comment {Author = "Fredek" + j, Body = "Comment Body" + j, Blog = blog};
						blog.AddComment(comment);
					}
					session.Save(blog);
				}
				transaction.Commit();

			}
			session.Close();

		}
	}
}
