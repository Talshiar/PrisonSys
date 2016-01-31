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
    public class PrisonerRepository : IPrisonerRepository
    {
        private static PrisonerRepository instance = null;
        private IList<Prisoner> prisonerList = new List<Prisoner>();

        public static PrisonerRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new PrisonerRepository();
            }

            return instance;
        }

        private void LoadPrisonersFromDatabase()
        {
            using (ISession session = NhibernateSession.OpenSession())
            {
                IQuery query = session.CreateQuery("from prisoner as ws order by ws.name asc");
                prisonerList = query.List<Prisoner>();
            }
        }

        public int Count()
        {
            LoadPrisonersFromDatabase();

            return prisonerList.Count;
        }

        public void Add(string fName, string lName, string adr, DateTime from, DateTime to, string reason)
        {
            LoadPrisonersFromDatabase();
            Prisoner prisoner = new Prisoner(fName, lName, adr, from, to, reason);

            using (ISession session = NhibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(prisoner);
                    transaction.Commit();
                }
            }
        }
        public Prisoner GetPrisonerByIndex(int index)
        {
            LoadPrisonersFromDatabase();

            if (0 <= index && index <= prisonerList.Count)
            {
                return prisonerList[index];
            }
            else
            {
                throw new Exception();
            }
        }

        public void Update(int id, Model.Prisoner pris)
        {
            LoadPrisonersFromDatabase();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Model.Prisoner Get(int id)
        {
            throw new NotImplementedException();
        }

        public Model.Prisoner GetByName(string fName, string lName)
        {
            throw new NotImplementedException();
        }
    }
}
