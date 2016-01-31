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
    public partial class FrmPrisonerManager : Form
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

            for (int i = 0; i < prisonerRepo.Count(); i++)
            {
                Prisoner prisoner = prisonerRepo.GetPrisonerByIndex(i);

                ListViewItem listViewItem = new ListViewItem(prisoner.Id.ToString());
                listViewItem.SubItems.Add(prisoner.FirstName);
                listViewItem.SubItems.Add(prisoner.LastName);
                listViewItem.SubItems.Add(prisoner.Adress);
                listViewItem.SubItems.Add(prisoner.LastName);
                listViewItem.SubItems.Add(prisoner.ServeFrom.ToString());
                listViewItem.SubItems.Add(prisoner.ServeTo.ToString());
                listPrisoner.Items.Add(listViewItem);
            }
        }

        private void FrmPrisonerManager_Load(object sender, EventArgs e)
        {
            UpdateList();
        }
    }
}
