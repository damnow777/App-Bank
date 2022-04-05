using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_API
{
    public partial class Blik : Form
    {
        public Blik()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnLoad(EventArgs e)
        {
            Random Ran = new Random();
            for (int i = 0; i < 6; i++)
            {
                int wylosowana = Ran.Next(1, 9);
                label1.Text += wylosowana.ToString();
            }
            GraphicsPath gp = new GraphicsPath();

            gp.AddEllipse(1, 1, label1.Width, label1.Height);

            label1.Region = new Region(gp);

            label1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random Ran = new Random();
            for (int i = 0; i < 6; i++)
            {
                int wylosowana = Ran.Next(1, 9);
                label1.Text += wylosowana.ToString();
            }
            if (label1.Text.Length > 6)
            {
                label1.Text = "";
            }

        }
    }
}
