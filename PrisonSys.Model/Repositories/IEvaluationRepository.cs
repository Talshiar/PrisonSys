using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonSys.Model.Repositories
{
    public interface IEvaluationRepository
    {
        void Add(Evaluation eval);
        void Delete(int id);
        Evaluation Get(int id);
    }
}
