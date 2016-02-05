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
    public partial class FrmCellPicker : Form
    {
        private IController controller;
        private CellRepository cellRepo;
        private Cell cell;
        private int idPrisoner;
        public FrmCellPicker(IController con, CellRepository repo, int idPris)
        {
            idPrisoner = idPris;
            controller = con;
            cellRepo = repo;
            InitializeComponent();
        }


        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (comboBoxAvaCells.SelectedItem == null)
            {
                MessageBox.Show("You didn't select a cell.");
            } else
            {
                PrisonerRepository prisonerRepo = new PrisonerRepository();
                Prisoner prisoner = prisonerRepo.GetPrisonerByIndex(idPrisoner);
                prisoner.PrisonerCell = cell;

                cellRepo.UpdateCellPop(cell.Id, 1);
                try
                {
                    prisonerRepo.Update(idPrisoner, prisoner);
                    MessageBox.Show("Prisoner successfully added.");
                }
                catch
                {
                    MessageBox.Show("Error while adding prisoner to database.");
                }
                this.Close();
            }
        }

        private void FrmCellPicker_Load(object sender, EventArgs e)
        {
            foreach (Cellblock block in cellRepo.GetCellBlockList())
            {
                comboBoxCellBlock.Items.Add(block.Name);
            }
        }

        private void comboBoxCellBlock_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxAvaCells.Items.Clear();
            groupBox1.Visible = false;
            string cellBlockName = comboBoxCellBlock.SelectedItem.ToString();
            for (int i = 0; i < cellRepo.Count(); i++)
            {
                cell = cellRepo.GetCellByIndex(i);
                if (cell.CellBlock.Name == cellBlockName && cell.Pop < cell.MaxPop)
                {
                    comboBoxAvaCells.Items.Add(cell.Id);
                }
            }
        }

        private void comboBoxAvaCells_SelectionChangeCommitted(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            cell = cellRepo.GetCellByIndex(Int32.Parse(comboBoxAvaCells.SelectedItem.ToString()) - 1);
            txtBoxMaxPop.Text = cell.MaxPop.ToString();
            txtBoxPopulation.Text = cell.Pop.ToString();
        }

    }
}
