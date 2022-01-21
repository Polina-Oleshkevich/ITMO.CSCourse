using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinButNum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void clickButton1_Click(object sender, EventArgs e)
        {

        }
        private void cmdTest_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=AdventureWorks2017;Data Source=.\\SQLEXPRESS"))
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT DatabaseLogID, PostTime, DatabaseUser, Event, Object FROM dbo.DatabaseLog", cn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lbResultData.Items.Add(reader[0] + " " + reader[1]);
                        }
                    }

                }

            }
        }
    }
}
