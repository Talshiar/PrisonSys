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
        public static AssignmentRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new AssignmentRepository();
            }

            return instance;
        }
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

        public void Delete(int id)
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
            if (0 <= index && index <= assignmentList.Count)
                return assignmentList[index];
            else
                throw new Exception();
        }
    }
}
