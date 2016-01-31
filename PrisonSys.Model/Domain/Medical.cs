using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonSys.Model
{
    public class Medical
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Prisoner PrisonerExamined { get; set; }

        public Medical() { }
        public Medical(string desc, DateTime date, Prisoner pris)
        {
            this.Description = desc;
            this.Date = date;
            this.PrisonerExamined = pris;
        }
    }
}
