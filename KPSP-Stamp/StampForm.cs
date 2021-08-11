using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPSP_Stamp
{
    public partial class StampForm : Form
    {
        public StampForm()
        {
            InitializeComponent();
        }

        private void CancelStampButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveStampButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
