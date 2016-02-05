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

        public void Add(string fName, string lName, string adr, DateTime from,
            DateTime to, string reason, int idAssign, int idCell)
        {
            LoadPrisonersFromDatabase();
            Prisoner prisoner = new Prisoner(fName, lName, adr, from, to, reason);

            AssignmentRepository assignRepo = new AssignmentRepository();
            Assignment assignment;
            if (idAssign != 0)
            {
                assignment = assignRepo.GetAssignmentByIndex(idAssign - 1);
                prisoner.PrisonerAssignment = assignment;
            }
            CellRepository cellRepo = new CellRepository();
            Cell cell;
            if (idCell != 0)
            {
                cell = cellRepo.GetCellByIndex(idCell);
                prisoner.PrisonerCell = cell;
            }


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

            foreach (Prisoner p in prisonerList)
            {
                if (p.Id == index) return p;
            }
            throw new Exception();
        }
        public List<Prisoner> GetPrisonerList()
        {
            LoadPrisonersFromDatabase();
            List<Prisoner> prisoners = new List<Prisoner>();
            foreach (Prisoner p in prisonerList)
            {
                prisoners.Add(p);
            }
            return prisoners;
        }

        public void Update(int id, Model.Prisoner newPris)
        {
            LoadPrisonersFromDatabase();

            foreach (Prisoner prisoner in prisonerList)
            {
                if (prisoner.Id == id)
                {
                    prisoner.FirstName = newPris.FirstName;
                    prisoner.LastName = newPris.LastName;
                    prisoner.Adress = newPris.Adress;
                    prisoner.ServeFrom = newPris.ServeFrom;
                    prisoner.ServeTo = newPris.ServeTo;
                    prisoner.ServeReason = newPris.ServeReason;
                    prisoner.PrisonerAssignment = newPris.PrisonerAssignment;
                    prisoner.PrisonerCell = newPris.PrisonerCell;
                    using (ISession session = NhibernateService.OpenSession())
                    {
                        using (ITransaction transaction = session.BeginTransaction())
                        {
                            session.Update(prisoner);
                            transaction.Commit();
                        }
                    }

                    LoadPrisonersFromDatabase();
                }
            }
            Notify();
        }

        public void Remove(int id)
        {
            LoadPrisonersFromDatabase();
            Prisoner prisoner = GetPrisonerByIndex(id);
            CellRepository cellRepo = new CellRepository();
            using (ISession session = NhibernateService.OpenSession())
            {
                cellRepo.UpdateCellPop(prisoner.PrisonerCell.Id, -1);
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
        public int GetPrisonerId(string fName, string lName)
        {
            Prisoner prisoner = new Prisoner();
            foreach (Prisoner p in prisonerList)
            {
                if (p.FirstName == fName && p.LastName == lName) prisoner = p;
            }
            return prisoner.Id;
        }
    }
}
