using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrisonSys.Model.Repositories;
using PrisonSys.Model;
using NHibernate;
using PrisonSys.Interface;

namespace PrisonSys.DAL
{
    public class CellRepository : Subject, ICellRepository
    {
        private static CellRepository instance = null;
        private IList<Cell> cellList = new List<Cell>();
        private IList<Cellblock> cellblockList = new List<Cellblock>();

        public static CellRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new CellRepository();
            }

            return instance;
        }
        #region Cell Methods
        private void LoadCellsFromDatabase()
        {
            using (ISession session = NhibernateService.OpenSession())
            {
                IQuery query = session.CreateQuery(
                    "from PrisonSys.Model.Cell as c order by c.Id asc");
                cellList = query.List<Cell>();
            }
        }

        public int Count()
        {
            LoadCellsFromDatabase();
            return cellList.Count;
        }
        public void Add(int maxPop, int pop, Cellblock cellblock)
        {
            LoadCellsFromDatabase();
            Cell cell = new Cell(maxPop, pop, cellblock);

            using (ISession session = NhibernateService.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(cell);
                    transaction.Commit();
                }
            }
            LoadCellsFromDatabase();
            Notify();
        }
        public void UpdateCellPop(int id, int change)
        {
            LoadCellsFromDatabase();
            foreach (Cell cell in cellList)
            {
                if (cell.Id == id)
                {
                    cell.Pop += change;
                    using (ISession session = NhibernateService.OpenSession())
                    {
                        using (ITransaction transaction = session.BeginTransaction())
                        {
                            session.Update(cell);
                            transaction.Commit();
                        }
                    }
                    LoadCellsFromDatabase();
                }
            }
            Notify();
        }

        public void Remove(int id)
        {
            Cell cell = GetCellByIndex(id);

            using (ISession session = NhibernateService.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(cell);
                    transaction.Commit();
                }
            }
            LoadCellsFromDatabase();
            Notify();
        }
        public Cell GetCellByIndex(int index)
        {
            LoadCellsFromDatabase();

            foreach (Cell c in cellList)
            {
                if (c.Id == index) return c;
            }
            throw new Exception();
        } 
        #endregion
        #region Cellblock methods
        private void LoadCellblocksFromDatabase()
        {
            using (ISession session = NhibernateService.OpenSession())
            {
                IQuery query = session.CreateQuery(
                    "from PrisonSys.Model.Cellblock as cb order by cb.Id asc");
                cellblockList = query.List<Cellblock>();
            }
        }
        public List<Cellblock> GetCellBlockList()
        {
            LoadCellblocksFromDatabase();
            List<Cellblock> blockList = cellblockList.ToList();
            return blockList;
        }
        public Cellblock GetCellblockByIndex(int index)
        {
            LoadCellblocksFromDatabase();
            foreach (Cellblock cb in cellblockList)
            {
                if (cb.Id == index) return cb;
            }
            throw new Exception();
        }
        public void DeleteCellblock(int id)
        {
            LoadCellsFromDatabase();
            LoadCellblocksFromDatabase();
            Cellblock cellblock = GetCellblockByIndex(id);
            using (ISession session = NhibernateService.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(cellblock);
                    foreach (Cell c in cellList)
                    {
                        if (c.CellBlock.Id == cellblock.Id) session.Delete(c);
                    }
                    transaction.Commit();
                }
            }
            LoadCellblocksFromDatabase();
            Notify();
        }
        public void AddCellblock(string name)
        {
            LoadCellsFromDatabase();
            Cellblock cb = new Cellblock(name);
            using (ISession session = NhibernateService.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(cb);
                    transaction.Commit();
                }
            }
            LoadCellsFromDatabase();
            Notify();
        }
        #endregion
    }
}
