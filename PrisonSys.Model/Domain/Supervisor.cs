using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonSys.Model
{
    public class Supervisor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Supervisor() { }
        public Supervisor(string fName, string lName)
        {
            this.FirstName = fName;
            this.LastName = lName;
        }
    }
}
