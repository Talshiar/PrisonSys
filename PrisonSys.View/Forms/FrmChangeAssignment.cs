using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrisonSys.Interface;
using PrisonSys.DAL;
using PrisonSys.Model;

namespace PrisonSys.Forms
{
    public partial class FrmChangeAssignment : Form
    {
        private IController controller;
        private PrisonerRepository prisonerRepo;
        private AssignmentRepository assignmentRepo;
        private int idPrisoner;
        public FrmChangeAssignment(IController con, PrisonerRepository repo1, AssignmentRepository repo2, int idPris)
        {
            idPrisoner = idPris;
            controller = con;
            prisonerRepo = repo1;
            assignmentRepo = repo2;
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Assignment a in assignmentRepo.GetAssignmentList())
                {
                    if (comboBoxAssignment.SelectedItem.ToString() == a.Name)
                    {
                        prisonerRepo.UpdateAssignment(idPrisoner, a);
                        this.Close();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Unable to change assignment.");
            }
        }

        private void FrmChangeAssignment_Load(object sender, EventArgs e)
        {
            foreach (Assignment a in assignmentRepo.GetAssignmentList())
            {
                comboBoxAssignment.Items.Add(a.Name);
            }
        }
    }
}
