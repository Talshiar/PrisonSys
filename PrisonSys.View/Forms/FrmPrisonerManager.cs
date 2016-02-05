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
    public partial class FrmPrisonerManager : Form, IObserver
    {
        private IController controller;
        private PrisonerRepository prisonerRepo;
        public FrmPrisonerManager(IController con, PrisonerRepository repo)
        {
            controller = con;
            prisonerRepo = repo;
            InitializeComponent();
        }
        private void UpdateList()
        {
            listPrisoner.Items.Clear();
            foreach (Prisoner prisoner in prisonerRepo.GetPrisonerList())
            {
                ListViewItem listViewItem = new ListViewItem(prisoner.Id.ToString());
                listViewItem.SubItems.Add(prisoner.FirstName);
                listViewItem.SubItems.Add(prisoner.LastName);
                listViewItem.SubItems.Add(prisoner.Adress);
                listViewItem.SubItems.Add(prisoner.ServeFrom.ToString());
                listViewItem.SubItems.Add(prisoner.ServeTo.ToString());
                listPrisoner.Items.Add(listViewItem);
            }       
        }
        private void UpdateList(List<Prisoner> prisoners)
        {
            listPrisoner.Items.Clear();
            foreach (Prisoner prisoner in prisoners)
            {
                ListViewItem listViewItem = new ListViewItem(prisoner.Id.ToString());
                listViewItem.SubItems.Add(prisoner.FirstName);
                listViewItem.SubItems.Add(prisoner.LastName);
                listViewItem.SubItems.Add(prisoner.Adress);
                listViewItem.SubItems.Add(prisoner.ServeFrom.ToString());
                listViewItem.SubItems.Add(prisoner.ServeTo.ToString());
                listPrisoner.Items.Add(listViewItem);
            }
        }

        private void FrmPrisonerManager_Load(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void listPrisoner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPrisoner.SelectedIndices.Count > 0)
            {
                string index = listPrisoner.SelectedItems[0].Text;
                Prisoner prisoner = prisonerRepo.GetPrisonerByIndex(Int32.Parse(index));
                if (prisoner.ServeReason != null) txtBoxSentence.Text = prisoner.ServeReason;
                if (prisoner.PrisonerAssignment != null) txtBoxAssign.Text = prisoner.PrisonerAssignment.Name;
            }

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string firstName = txtBoxSearchName.Text.ToLower();
            string lastName = txtBoxSearchLastName.Text.ToLower();
            List<Prisoner> prisoners = prisonerRepo.GetByName(firstName, lastName);
            if (prisoners.Count == 0)
            {
                MessageBox.Show("No results were found.");
                UpdateList();
                ClearFormControls();
            }
            else
            {
                UpdateList(prisoners);
                ClearFormControls();
            }
        }

        public void ClearFormControls()
        {
            txtBoxSearchLastName.ResetText();
            txtBoxSearchName.ResetText();
            txtBoxSentence.ResetText();
            txtBoxAssign.ResetText();
        }
        void IObserver.UpdateView()
        {
            UpdateList();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            string index = listPrisoner.SelectedItems[0].Text;
            try
            {
                prisonerRepo.Remove(Int32.Parse(index));
                MessageBox.Show("Prisoner successfully deleted.");
                UpdateList();
            }
            catch
            {
                MessageBox.Show("Failed to delete the prisoner from the database.");
            }
        }
    }
}
