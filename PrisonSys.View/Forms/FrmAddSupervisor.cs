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
    public partial class FrmAddSupervisor : Form
    {
        private IController controller;
        private AssignmentRepository assignmentRepo;
        public FrmAddSupervisor(IController con, AssignmentRepository repo)
        {
            controller = con;
            assignmentRepo = repo;
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (textBoxFname.Text == "" && textBoxLname.Text == "")
                MessageBox.Show("Enter supervisors first and last name.");
            else
            {
                try
                {
                    assignmentRepo.AddSupervisor(textBoxFname.Text, textBoxLname.Text);
                    MessageBox.Show("Supervisor added.");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Unable to add the supervisor.");
                }
            }
        }
    }
}
