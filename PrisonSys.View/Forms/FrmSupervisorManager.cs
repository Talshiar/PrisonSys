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
        public FrmSupervisorManager()
        {
            InitializeComponent();
        }

        public void UpdateView()
        {
            throw new NotImplementedException();
        }
    }
}
