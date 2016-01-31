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
    public class CellRepository : ICellRepository
    {
        private static CellRepository instance = null;
        private IList<Cell> cellList = new List<Cell>();

        public static CellRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new CellRepository();
            }

            return instance;
        }
        private void LoadCellsFromDatabase()
        {
            using (ISession nhSession = NhibernateSession.OpenSession())
            {

            }
        }
        public void Add(Model.Cell c)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Model.Cell c)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Model.Cell Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
