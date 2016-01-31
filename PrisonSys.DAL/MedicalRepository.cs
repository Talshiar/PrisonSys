using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrisonSys.Model.Repositories;
using PrisonSys.Model;
using NHibernate;

namespace PrisonSys.DAL
{
    public class MedicalRepository : IMedicalRepository
    {
        private static MedicalRepository instance = null;
        private IList<Medical> medicalList = new List<Medical>();
        
        public static MedicalRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new MedicalRepository();
            }

            return instance;
        }

        private void LoadMedicalsFromDatabase()
        {
            using (ISession nhSession = NhibernateSession.OpenSession())
            {

            }
        }
        public void Add(Model.Medical med)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Model.Medical Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
