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
    public partial class FrmAddAssignment : Form
    {
        private IController controller;
        private AssignmentRepository assignmentRepo;
        public FrmAddAssignment(IController con, AssignmentRepository repo)
        {
            controller = con;
            assignmentRepo = repo;
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "" && comboBoxSupervisor.SelectedItem == null)
                MessageBox.Show("Enter assignment name and pick a supervisor.");
            else
            {
                try
                {
                    string supervisorId = comboBoxSupervisor.SelectedItem.ToString();
                    supervisorId = supervisorId.Split('.')[0];
                    assignmentRepo.Add(textBoxName.Text, assignmentRepo.
                        GetSupervisorByIndex(Int32.Parse(supervisorId)));
                    MessageBox.Show("Assignment added.");
                    this.Close();

                }
                catch
                {
                    MessageBox.Show("Unable to add assignment.");
                }
            }
        }

        private void FrmAddAssignment_Load(object sender, EventArgs e)
        {
            string fullName;
            foreach(Supervisor s in assignmentRepo.GetSupervisorList())
            {
                fullName = s.Id + ". " + s.FirstName + " " + s.LastName;
                comboBoxSupervisor.Items.Add(fullName);
            }
        }
    }
}
