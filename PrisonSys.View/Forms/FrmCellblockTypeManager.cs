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
    public partial class FrmCellblockTypeManager : Form, IObserver
    {
        private IController controller;
        private CellRepository cellRepo;
        public FrmCellblockTypeManager(IController con, CellRepository repo)
        {
            controller = con;
            cellRepo = repo;
            InitializeComponent();
        }
        private void UpdateList()
        {
            listViewCellblocks.Items.Clear();
            foreach (Cellblock cellblock in cellRepo.GetCellBlockList())
            {
                ListViewItem listViewItem = new ListViewItem(cellblock.Id.ToString());
                listViewItem.SubItems.Add(cellblock.Name);
                listViewCellblocks.Items.Add(listViewItem);
            }
        }
        public void UpdateView()
        {
            UpdateList();
        }

        private void FrmCellblockTypeManager_Load(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                string index = listViewCellblocks.SelectedItems[0].Text;
                cellRepo.DeleteCellblock(Int32.Parse(index));
                MessageBox.Show("Successfully deleted the cellblock.");

            }
            catch
            {
                MessageBox.Show("Failed to delete cellblock from database.");
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            controller.ShowAddCellblock();
        }
    }
}
