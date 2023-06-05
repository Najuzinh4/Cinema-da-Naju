using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
       
        private void inclusãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 nf = new Form1();
            nf.MdiParent = this;
            nf.Show();
        }

        private void alterarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 nf = new Form3();
            nf.MdiParent = this;
            nf.Show();
        }

       
    }

    }

