using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonSys.Model
{
    public class Cellblock
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Cellblock() { }
        public Cellblock(string name)
        {
            this.Name = name;
        }
    }
}
