using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonSys.Model
{
    public class Prisoner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public DateTime ServeFrom { get; set; }
        public DateTime ServeTo { get; set; }
        public string ServeReason { get; set; }
        public Assignment PrisonerAssignment { get; set; }
        public Cell PrisonerCell { get; set; }

        public Prisoner() { }
        public Prisoner(string fName, string lName, string adr, DateTime from, DateTime to, string reason)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.Adress = adr;
            this.ServeFrom = from;
            this.ServeTo = to;
            this.ServeReason = reason;
            this.PrisonerAssignment = null;
            this.PrisonerCell = null;
        }
    }
}
