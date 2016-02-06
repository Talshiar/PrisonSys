using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonSys.Model.Repositories
{
    public interface ICellRepository
    {
        #region Cell methods
        void Add(int maxPop, int pop, Cellblock cellblock);
        void UpdateCellPop(int id, int change);
        void Remove(int id);
        int Count();
        Cell GetCellByIndex(int index);
        List<Cell> GetCellList();
        #endregion

        #region Cellblock methods
        Cellblock GetCellblockByIndex(int index);
        List<Cellblock> GetCellBlockList();
        void DeleteCellblock(int id);
        void AddCellblock(string name); 
        #endregion
    }
}
