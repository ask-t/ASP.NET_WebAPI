using APIpractice.Model;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;


namespace APIpractice.Helpers
{
    public static class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    DotNetEnv.Env.Load();
                    _sessionFactory = Fluently.Configure()
                        .Database(PostgreSQLConfiguration.PostgreSQL82
                        .ConnectionString(cs => cs
                            .Host(Environment.GetEnvironmentVariable("HOST"))
                            .Port(Int32.Parse(Environment.GetEnvironmentVariable("PORT")))
                            .Username(Environment.GetEnvironmentVariable("USERNAME"))
                            .Password(Environment.GetEnvironmentVariable("PASSWORD"))
                            .Database(Environment.GetEnvironmentVariable("DATABASE"))))
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Student>())
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Course>())
                        .BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }
    }
}
