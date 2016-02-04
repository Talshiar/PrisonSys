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
        public FrmCellPicker(IController con, CellRepository repo)
        {
            controller = con;
            cellRepo = repo;
            InitializeComponent();
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCellPicker_Load(object sender, EventArgs e)
        {

        }

    }
}
