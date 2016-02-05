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
    public partial class FrmAssignmentTypeManager : Form, IObserver
    {
        private IController controller;
        private AssignmentRepository assignmentRepo;
        public FrmAssignmentTypeManager(IController con, AssignmentRepository repo)
        {
            controller = con;
            assignmentRepo = repo;
            InitializeComponent();
        }
        private void UpdateList()
        {
            listView1.Items.Clear();
            foreach (Assignment assign in assignmentRepo.GetAssignmentList())
            {
                ListViewItem listViewItem = new ListViewItem(assign.Id.ToString());
                listViewItem.SubItems.Add(assign.Name);
                listViewItem.SubItems.Add(assign.AssignmentSupervisor.FirstName);
                listViewItem.SubItems.Add(assign.AssignmentSupervisor.LastName);
                listView1.Items.Add(listViewItem);
            }
        }
        public void UpdateView()
        {
            UpdateList();
        }

        private void FrmAssignmentTypeManager_Load(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                string index = listView1.SelectedItems[0].Text;
                assignmentRepo.Remove(Int32.Parse(index));
                MessageBox.Show("Successfully deleted the cellblock.");

            }
            catch
            {
                MessageBox.Show("Failed to delete cellblock from database.");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            controller.ShowAddAssignment();
        }
    }
}
