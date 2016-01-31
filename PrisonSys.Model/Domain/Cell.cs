using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonSys.Model
{
    public class Cell
    {
        public int Id { get; set; }
        public int MaxPop { get; set; }
        public int Pop { get; set; }
        public Cellblock CellBlock { get; set; }
        public Cell() { }
        public Cell(int maxpop, int pop, Cellblock cellblock)
        {
            this.MaxPop = maxpop;
            this.Pop = pop;
            this.CellBlock = cellblock;
        }
    }
}
