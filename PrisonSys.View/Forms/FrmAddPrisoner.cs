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

namespace PrisonSys
{
    public partial class FrmAddPrisoner : Form
    {
        private IController controller;
        private AssignmentRepository assignRepo;
        private PrisonerRepository prisonerRepo;
        public FrmAddPrisoner(IController con, AssignmentRepository repo1, PrisonerRepository repo2)
        {
            controller = con;
            assignRepo = repo1;
            prisonerRepo = repo2;
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (txtBoxAdress.Text != "" && txtBoxFName.Text != "" && txtBoxLName.Text != ""
                && txtBoxSentenced.Text != "" && comboBoxAssign.SelectedItem != null
                && dateTimeServeTo.Value > dateTimeServeFrom.Value)
            {
                prisonerRepo.Add(txtBoxFName.Text, txtBoxLName.Text, txtBoxAdress.Text,
                    dateTimeServeFrom.Value.Date, dateTimeServeTo.Value.Date, txtBoxSentenced.Text,
                    assignRepo.GetAssignmentIdByName(comboBoxAssign.SelectedItem.ToString()), 0);
                controller.ShowCellPicker(prisonerRepo.GetPrisonerId(txtBoxFName.Text, txtBoxLName.Text));
                this.Close();
            } else
            {
                MessageBox.Show("Not all information is fulfilled.\nPlease verify your input.");
            }
            
        }

        private void FrmAddPrisoner_Load(object sender, EventArgs e)
        {
            foreach(Assignment a in assignRepo.GetAssignmentList())
            {
                comboBoxAssign.Items.Add(a.Name);
            }
        }
    }
}
