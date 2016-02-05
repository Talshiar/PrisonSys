using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonSys.Model.Repositories
{
    public interface ICellRepository
    {
        void Add(int maxPop, int pop, Cellblock cellblock);
        void UpdateCellPop(int id, int change);
        void Remove(int id);
        int Count();

        Cell GetCellByIndex(int index);
        Cellblock GetCellblockByIndex(int index);
        List<Cellblock> GetCellBlockList();
        void DeleteCellblock(int id);
        void AddCellblock(string name);
    }
}
