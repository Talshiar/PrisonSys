﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonSys.Model.Repositories
{
    public interface IMedicalRepository
    {
        void Add(Medical med);
        void Delete(int id);
        Medical Get(int id);
    }
}