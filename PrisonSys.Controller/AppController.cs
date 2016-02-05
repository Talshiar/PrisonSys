using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrisonSys.Interface;
using PrisonSys.View;
using PrisonSys.Forms;
using PrisonSys.DAL;


namespace PrisonSys.Controller
{
    public class AppController : IController
    {
        readonly PrisonerRepository prisonerRepository = PrisonerRepository.GetInstance();
        readonly MedicalRepository medicalRepository = MedicalRepository.GetInstance();
        readonly EvaluationRepository evaluationRepository = EvaluationRepository.GetInstance();
        readonly CellRepository cellRepository = CellRepository.GetInstance();
        readonly AssignmentRepository assignmentRepository = AssignmentRepository.GetInstance();

        public void ShowAddPrisoner()
        {
            FrmAddPrisoner AddPrisoner = new FrmAddPrisoner(this, assignmentRepository, prisonerRepository);
            AddPrisoner.ShowDialog();
        }

        public void ShowAssignmentTypeManager()
        {
            FrmAssignmentTypeManager AssignmentManager = new FrmAssignmentTypeManager(this, assignmentRepository);
            assignmentRepository.Attach(AssignmentManager);
            AssignmentManager.ShowDialog();
            assignmentRepository.Delete(AssignmentManager);
        }

        public void ShowCellblockTypeManager()
        {
            FrmCellblockTypeManager CellblockManager = new FrmCellblockTypeManager(this, cellRepository);
            cellRepository.Attach(CellblockManager);
            CellblockManager.ShowDialog();
            cellRepository.Delete(CellblockManager);
        }

        public void ShowCellPicker(int idPrisoner)
        {
            FrmCellPicker CellPicker = new FrmCellPicker(this, cellRepository, idPrisoner);
            CellPicker.ShowDialog();
        }

        public void ShowCellStatus()
        {
            FrmCellStatus CellStatus = new FrmCellStatus();
            CellStatus.ShowDialog();

        }

        public void ShowEmployees()
        {
            FrmEmployees Employees = new FrmEmployees();
            Employees.ShowDialog();
        }

        public void ShowPrisonerHistory()
        {
            FrmPrisonerHistory PrisonerHistory = new FrmPrisonerHistory();
            PrisonerHistory.ShowDialog();
        }

        public void ShowPrisonerManager()
        {
            FrmPrisonerManager PrisonerManager = new FrmPrisonerManager(this, prisonerRepository);
            prisonerRepository.Attach(PrisonerManager);
            PrisonerManager.ShowDialog();
            prisonerRepository.Delete(PrisonerManager);
        }

        public void ShowSupervisorManager()
        {
            FrmSupervisorManager SupervisorManager = new FrmSupervisorManager();
            SupervisorManager.ShowDialog();
        }


        public void ShowAddCellblock()
        {
            FrmAddCellblock AddCellblock = new FrmAddCellblock(this, cellRepository);
            AddCellblock.ShowDialog();
        }


        public void ShowAddAssignment()
        {
            FrmAddAssignment AddAssignment = new FrmAddAssignment(this, assignmentRepository);
            AddAssignment.ShowDialog();
        }
    }
}
