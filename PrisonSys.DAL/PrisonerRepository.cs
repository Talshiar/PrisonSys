using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrisonSys.Model.Repositories;
using PrisonSys.Model;
using NHibernate;
using PrisonSys.Interface;

namespace PrisonSys.DAL
{
    public class PrisonerRepository : Subject, IPrisonerRepository
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
            using (ISession session = NhibernateService.OpenSession())
            {
                IQuery query = session.CreateQuery(
                    "from PrisonSys.Model.Prisoner as p order by p.Id asc");
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

            using (ISession session = NhibernateService.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(prisoner);
                    transaction.Commit();
                }
            }
            LoadPrisonersFromDatabase();
            Notify();
        }
        public Prisoner GetPrisonerByIndex(int index)
        {
            LoadPrisonersFromDatabase();

            if (0 <= index && index <= prisonerList.Count)
                return prisonerList[index];
            else
                throw new Exception();
        }

        public void Update(int id, Model.Prisoner pris)
        {
            LoadPrisonersFromDatabase();
        }

        public void Delete(int id)
        {
            Prisoner prisoner = GetPrisonerByIndex(id);

            using (ISession session = NhibernateService.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(prisoner);
                    transaction.Commit();
                }
            }
            LoadPrisonersFromDatabase();
            Notify();
        }

        public List<Prisoner> GetByName(string fName, string lName)
        {
            LoadPrisonersFromDatabase();
            List<Prisoner> prisoners = new List<Prisoner>();
            foreach (Prisoner p in prisonerList)
            {
                if (fName != "" && lName != "")
                {
                    if (fName == p.FirstName.ToLower() && lName == p.LastName.ToLower())
                        prisoners.Add(p);
                }
                else
                    if (fName == p.FirstName.ToLower() || lName == p.LastName.ToLower())
                        prisoners.Add(p);

            }
            return prisoners;
        }
    }
}
