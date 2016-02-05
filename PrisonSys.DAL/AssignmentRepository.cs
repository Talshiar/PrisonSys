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
    public class AssignmentRepository : Subject, IAssignmentRepository
    {
        private static AssignmentRepository instance = null;
        private IList<Assignment> assignmentList = new List<Assignment>();
        private IList<Supervisor> supervisorList = new List<Supervisor>();
        public static AssignmentRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new AssignmentRepository();
            }

            return instance;
        }
        #region Assignment methods
        private void LoadAssignmentsFromDatabase()
        {
            using (ISession session = NhibernateService.OpenSession())
            {
                IQuery query = session.CreateQuery(
                    "from PrisonSys.Model.Assignment as a order by a.Id asc");
                assignmentList = query.List<Assignment>();
            }
        }
        public int Count()
        {
            LoadAssignmentsFromDatabase();
            return assignmentList.Count;
        }
        public void Add(string name, Supervisor superv)
        {
            LoadAssignmentsFromDatabase();
            Assignment assignment = new Assignment(name, superv);

            using (ISession session = NhibernateService.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(assignment);
                    transaction.Commit();
                }
            }
            LoadAssignmentsFromDatabase();
            Notify();
        }

        public void Update(int id, Assignment assign)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            Assignment assignment = GetAssignmentByIndex(id);

            using (ISession session = NhibernateService.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(assignment);
                    transaction.Commit();
                }
            }
            LoadAssignmentsFromDatabase();
            Notify();
        }

        public Assignment GetAssignmentByIndex(int index)
        {
            LoadAssignmentsFromDatabase();

            foreach (Assignment a in assignmentList)
            {
                if (a.Id == index) return a;
            }
            throw new Exception();
        }

        public int GetAssignmentIdByName(string name)
        {
            LoadAssignmentsFromDatabase();
            Assignment assignment = new Assignment();
            foreach (Assignment a in assignmentList)
            {
                if (a.Name == name) assignment = a;
            }
            return assignment.Id;
        }

        public List<Assignment> GetAssignmentList()
        {
            LoadAssignmentsFromDatabase();
            List<Assignment> list = assignmentList.ToList();
            return list;
        }
        #endregion
        #region Supervisor methods
        private void LoadSupervisorsFromDatabase()
        {
            using (ISession session = NhibernateService.OpenSession())
            {
                IQuery query = session.CreateQuery(
                    "from PrisonSys.Model.Supervisor as s order by s.Id asc");
                supervisorList = query.List<Supervisor>();
            }
        }
        public int SupervisorCount()
        {
            LoadSupervisorsFromDatabase();
            return supervisorList.Count();
        }

        public Supervisor GetSupervisorByIndex(int index)
        {
            LoadSupervisorsFromDatabase();
            foreach (Supervisor s in supervisorList)
            {
                if (s.Id == index) return s;
            }
            throw new Exception();
        }

        public List<Supervisor> GetSupervisorList()
        {
            LoadSupervisorsFromDatabase();
            List<Supervisor> list = supervisorList.ToList();
            return list;
        }

        public void RemoveSupervisor(int id)
        {
            Supervisor supervisor = GetSupervisorByIndex(id);

            using (ISession session = NhibernateService.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(supervisor);
                    transaction.Commit();
                }
            }
            LoadSupervisorsFromDatabase();
            Notify();
        }

        public void AddSupervisor(string fName, string lName)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
