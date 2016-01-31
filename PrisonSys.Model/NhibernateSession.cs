using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using System.Reflection;

namespace PrisonSys.Model
{
    public static class NhibernateSession
    {
        public static ISession OpenSession()
        {
            Configuration c = new Configuration();
            c.Configure();
            c.AddAssembly(Assembly.GetCallingAssembly());
            ISessionFactory f = c.BuildSessionFactory();
            return f.OpenSession();
        }
    }
}
