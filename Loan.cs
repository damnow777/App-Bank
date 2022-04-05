using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_API
{
    public partial class Loan : Form
    {
        public Loan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
             if(radioButton1.Checked == true)
            {              
                    string info = "Pożyczka dla studentów została zasiągnięta na kwotę " + textBox1.Text + " zł";
                    MessageBox.Show(info, "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);               
            }
            if (radioButton2.Checked == true)
            {
                string info = "Pożyczka dla młodych została zasiągnięta na kwotę " + textBox1.Text + " zł";
                MessageBox.Show(info, "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (radioButton3.Checked == true)
            {
                string info = "Pożyczka dla seniorów została zasiągnięta na kwotę " + textBox1.Text + " zł";
                MessageBox.Show(info, "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (radioButton4.Checked == true)
            {
                string info = "Pożyczka dla klientów została zasiągnięta na kwotę " + textBox1.Text + " zł";
                MessageBox.Show(info, "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
