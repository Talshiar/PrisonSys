﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonSys.Model.Repositories
{
    public interface ICellRepository
    {
        void Add(int maxPop, int pop, Cellblock cellblock);
        void Update(int id, Cell c);
        void Delete(int id);
        Cell GetCellByIndex(int index);
    }
}
