using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinTimer1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void buttonTimeEnabledDisabled_Click(object sender, EventArgs e)
        {

        }
       

        private void button1_Click_1(object sender, EventArgs e)
        {
           
                if (userControlTimer1.Enabled == true)
                {
                userControlTimer1.TimeEnabled = false;
                }
                else
                {
                userControlTimer1.TimeEnabled = true;
                }
            
        }
    }
}
