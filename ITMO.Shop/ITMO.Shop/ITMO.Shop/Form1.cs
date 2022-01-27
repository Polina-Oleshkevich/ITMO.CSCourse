using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITMO.Shop
{
    public partial class Shop : Form
    {

        SqlConnection sqlConnection;

        public Shop()
        {
            InitializeComponent();
        }

        private async void Shop_Load(object sender, EventArgs e)
        {
            {
                string connectionString = ("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=test_block;Data Source=.\\SQLEXPRESS");
                sqlConnection = new SqlConnection(connectionString);

                await sqlConnection.OpenAsync();

                SqlDataReader reader = null;

                SqlCommand command = new SqlCommand("SELECT ID, Name, Number, Price, Discount FROM dbo.t1", sqlConnection);
                try
                {
                    reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        listBox1.Items.Add(reader[0] + " " + reader[1] + reader[2] + reader[3] + reader[4]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                }
            }
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }
        private void Shop_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }
        private async void button1_Click_1(object sender, EventArgs e)
        {
            if (label7.Visible)
                label7.Visible = false;
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO dbo.t1 (Name, Number, Price, Discount)VALUES(@Name, @Number, @Price, @Discount)", sqlConnection);
                    command.Parameters.AddWithValue("Name", textBox1.Text);
                    command.Parameters.AddWithValue("Number", textBox2.Text);
                    command.Parameters.AddWithValue("Price", textBox3.Text);
                    command.Parameters.AddWithValue("Discount", textBox4.Text);

                await command.ExecuteNonQueryAsync();
            }


            else
            {
                label7.Visible = true;
                label7.Text = "Поля 'Name', 'Number', 'Price', 'Discount'  должны быть заполнены!";
            }

        }

        private async void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SqlDataReader reader = null;

            SqlCommand command = new SqlCommand("SELECT ID, Name, Number, Price, Discount FROM dbo.t1", sqlConnection);
            try
            {
                reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    listBox1.Items.Add(reader[0] + " " + reader[1] + reader[2] + reader[3] + reader[4]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (label5.Visible)
                label5.Visible = false;
            if (!string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM dbo.t1 WHERE ID=@ID ", sqlConnection);

                command.Parameters.AddWithValue("ID", textBox6.Text);

                await command.ExecuteNonQueryAsync();
            }

            else
            {
                label5.Visible = true;
                label5.Text = "ID должен быть заполнен!";
            }
        }
    }

       
}
    

