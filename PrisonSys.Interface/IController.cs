using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonSys.Interface
{
    public interface IController
    {
        void ShowAddPrisoner();
        void ShowAssignmentTypeManager();
        void ShowCellblockTypeManager();
        void ShowCellPicker();
        void ShowCellStatus();
        void ShowEmployees();
        void ShowPrisonerHistory();
        void ShowPrisonerManager();
        void ShowSupervisorManager();

    }
}
