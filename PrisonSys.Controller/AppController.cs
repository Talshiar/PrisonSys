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

        public void ShowPrisonerManager()
        {
            FrmPrisonerManager PrisonerManager = new FrmPrisonerManager(this, prisonerRepository);
            prisonerRepository.Attach(PrisonerManager);
            PrisonerManager.ShowDialog();
            prisonerRepository.Delete(PrisonerManager);
        }

        public void ShowSupervisorManager()
        {
            FrmSupervisorManager SupervisorManager = new FrmSupervisorManager(this, assignmentRepository);
            assignmentRepository.Attach(SupervisorManager);
            SupervisorManager.ShowDialog();
            assignmentRepository.Delete(SupervisorManager);
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

        public void ShowAddSupervisor()
        {
            FrmAddSupervisor AddSupervisor = new FrmAddSupervisor(this, assignmentRepository);
            AddSupervisor.ShowDialog();
        }

        public void ShowMedicals(int idPrisoner)
        {
            FrmMedicals Medicals = new FrmMedicals(this, prisonerRepository, idPrisoner);
            prisonerRepository.Attach(Medicals);
            Medicals.ShowDialog();
            prisonerRepository.Delete(Medicals);
        }

        public void ShowEvaluations(int idPrisoner)
        {
            FrmEvaluations Evaluations = new FrmEvaluations(this, prisonerRepository, idPrisoner);
            prisonerRepository.Attach(Evaluations);
            Evaluations.ShowDialog();
            prisonerRepository.Delete(Evaluations);
        }

        public void ShowChangeAssignment(int idPrisoner)
        {
            FrmChangeAssignment ChangeAssignment = new FrmChangeAssignment(this, prisonerRepository, assignmentRepository, idPrisoner);
            ChangeAssignment.ShowDialog();
        }
    }
}
