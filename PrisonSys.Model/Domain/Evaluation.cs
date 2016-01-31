using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonSys.Model
{
    public class Evaluation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Prisoner PrisonerEvaluated { get; set; }
        public Evaluation() { }
        public Evaluation(string desc, DateTime date, Prisoner pris)
        {
            this.Description = desc;
            this.Date = date;
            this.PrisonerEvaluated = pris;
        }
    }
}
