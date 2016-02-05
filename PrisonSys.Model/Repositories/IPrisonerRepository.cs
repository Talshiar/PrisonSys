using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonSys.Model.Repositories
{
    public interface IPrisonerRepository
    {
        void Add(string fName, string lName, string adr, DateTime from,
            DateTime to, string reason, int idAssign, int idCell);
        void Update(int id, Prisoner newPris);
        void Remove(int id);
        int Count();

        Prisoner GetPrisonerByIndex(int index);
        List<Prisoner> GetByName(string fName, string lName);
        List<Prisoner> GetPrisonerList();

    }
}
