using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MdiApplication
{
    public partial class ParentForm : Form

    {
        public ParentForm()
        {
            InitializeComponent();
            spData.Text = Convert.ToString(System.DateTime.Today.ToLongDateString());
        }
        private int openDocuments = 0;
        private void Form1_Load(object sender, EventArgs e)

        {

        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WindowCascadeMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        private void WindowTileMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }

        private void mdiMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ExitMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WindowCascadeMenuItem_Click_1(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        private void WindowTileMenuItem_Click_1(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }

        private void NewMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm newChild = new ChildForm();
            newChild.MdiParent = this; newChild.Show();
            newChild.Text = newChild.Text + " " + ++openDocuments;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void spWin_Click(object sender, EventArgs e)
        {
            spWin.Text = "Windows is cascade";
            spWin.Text = "Windows is horizontal";
        }

        private void spData_Click(object sender, EventArgs e)
        {
            
                
            }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Tag.ToString())
            {
                case "NewDoc": ChildForm newChild = new ChildForm();
                    newChild.MdiParent = this; newChild.Show();
                    newChild.Text = newChild.Text + " " + ++openDocuments;
                    break;
                case "Cascade":
                    this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
                    break;
              case "Title": this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
                    break;
            }
        }
    }
}
