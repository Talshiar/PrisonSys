using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonSys.Model
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Supervisor AssignmentSupervisor { get; set; }
        public Assignment() { }
        public Assignment(string name, Supervisor superv)
        {
            this.Name = name;
            this.AssignmentSupervisor = superv;
        }
    }
}
