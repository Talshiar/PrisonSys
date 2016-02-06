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
    public partial class FrmSupervisorManager : Form, IObserver
    {
        private IController controller;
        private AssignmentRepository assignmentRepo;
        public FrmSupervisorManager(IController con, AssignmentRepository repo)
        {
            controller = con;
            assignmentRepo = repo;
            InitializeComponent();
        }
        private void UpdateList()
        {
            listView1.Items.Clear();
            foreach (Supervisor sup in assignmentRepo.GetSupervisorList())
            {
                ListViewItem listViewItem = new ListViewItem(sup.Id.ToString());
                listViewItem.SubItems.Add(sup.FirstName);
                listViewItem.SubItems.Add(sup.LastName);
                listView1.Items.Add(listViewItem);
            }
        }
        public void UpdateView()
        {
            UpdateList();
        }

        private void FrmSupervisorManager_Load(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            controller.ShowAddSupervisor();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                string index = listView1.SelectedItems[0].Text;
                assignmentRepo.RemoveSupervisor(Int32.Parse(index));
                MessageBox.Show("Successfully deleted the supervisor.");

            }
            catch
            {
                MessageBox.Show("Failed to delete the supervisor from database.");
            }
        }
    }
}
