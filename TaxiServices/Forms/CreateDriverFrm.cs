using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaxiServices
{
    public partial class CreateDriverFrm : Form
    {
        public CreateDriverFrm()
        {
            InitializeComponent();
            comboBox1.Items.Add("Да");
            comboBox1.Items.Add("Нет");
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
