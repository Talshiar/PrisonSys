using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrisonSys.Model.Repositories;
using PrisonSys.Model;
using NHibernate;

namespace PrisonSys.DAL
{
    public class EvaluationRepository : IEvaluationRepository
    {
        private static EvaluationRepository instance = null;
        private IList<Evaluation> evaluationList = new List<Evaluation>();

        public static EvaluationRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new EvaluationRepository();
            }

            return instance;
        }

        private void LoadEvaluationsFromDatabase()
        {
            using (ISession nhSession = NhibernateService.OpenSession())
            {

            }
        }
        public void Add(Model.Evaluation eval)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Model.Evaluation Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
