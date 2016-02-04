﻿using System;
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
        public void Update(int id, Model.Cell c)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
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
            if (0 <= index && index <= cellList.Count)
                return cellList[index];
            else
                throw new Exception();
        }
    }
}