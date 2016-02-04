using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonSys.Model.Repositories
{
    public interface IPrisonerRepository
    {
        void Add(string fName, string lName, string adr, DateTime from, DateTime to, string reason);
        void Update(int id, Prisoner pris);
        void Delete(int id);
        Prisoner GetPrisonerByIndex(int index);
        List<Prisoner> GetByName(string fName, string lName);

    }
}
