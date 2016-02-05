using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonSys.Model.Repositories
{
    public interface IAssignmentRepository
    {
        void Add(string name, Supervisor superv);
        void Update(int id, Assignment assign);
        void Remove(int id);
        int Count();
        Assignment GetAssignmentByIndex(int index);
        int GetAssignmentIdByName(string name);
        List<Assignment> GetAssignmentList();
        int SupervisorCount();
        Supervisor GetSupervisorByIndex(int index);
        List<Supervisor> GetSupervisorList();
        void RemoveSupervisor(int id);
        void AddSupervisor(string fName, string lName);

    }
}
