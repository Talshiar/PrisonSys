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
        void Remove(int id);
        Evaluation Get(int id);
        int Count();

    }
}
