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
    public partial class FrmAddCellblock : Form
    {
        private IController controller;
        private CellRepository cellRepository;
        public FrmAddCellblock(IController con, CellRepository repo)
        {
            controller = con;
            cellRepository = repo;
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "")
                MessageBox.Show("Enter a cellblock name.");
            else
            {
                try
                {
                    cellRepository.AddCellblock(textBoxName.Text);
                    MessageBox.Show("Cellblock added.");                    
                    this.Close();

                }
                catch
                {
                    MessageBox.Show("Unable to add cellblock.");
                }
            }
        }
    }
}
