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


namespace PrisonSys
{
    public partial class FrmAddPrisoner : Form
    {
        private IController controller;
        public FrmAddPrisoner(IController con)
        {
            controller = con;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controller.ShowCellPicker();
            this.Close();

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

    }
}
