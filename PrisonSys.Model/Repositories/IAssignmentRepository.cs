﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonSys.Model.Repositories
{
    public interface IAssignmentRepository
    {
        void Add(string name, Supervisor superv);
        void Update(int id, Assignment assign);
        void Delete(int id);
        Assignment GetAssignmentByIndex(int index);
    }
}