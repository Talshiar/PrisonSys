using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonSys.Interface
{
    public interface IController
    {
        #region Form calling methods
        void ShowAddPrisoner();
        void ShowAssignmentTypeManager();
        void ShowCellblockTypeManager();
        void ShowCellPicker(int idPrisoner);
        void ShowCellStatus();
        void ShowEmployees();
        void ShowPrisonerHistory();
        void ShowPrisonerManager();
        void ShowSupervisorManager();
        void ShowAddCellblock();
        void ShowAddAssignment();
        #endregion

    }
}
