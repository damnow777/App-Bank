using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_API
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(18, 18, 20);
        }


        //REGEX 
        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (!Regex.Match(textBox5.Text, @"^[A-Z][a-zA-ZżźćńółęąśŻŹĆĄŚĘŁÓŃ]*$").Success)
            {
                MessageBox.Show("Błędne dane");
                textBox5.Focus();
                return;
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (!Regex.Match(textBox6.Text, @"^[A-Z][a-zA-ZżźćńółęąśŻŹĆĄŚĘŁÓŃ]*$").Success)
            {
                MessageBox.Show("Błędne dane");
                textBox6.Focus();
                return;
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (!Regex.Match(textBox7.Text, @"^\d{16}$").Success)
            {
                MessageBox.Show("zły pesel");
                textBox7.Focus();
                return;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (!Regex.Match(textBox4.Text, @"^\d{9}$").Success)
            {
                MessageBox.Show("Niepoprawny numer telefonu");
                textBox4.Focus();
                return;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (!Regex.Match(textBox2.Text, @"^\d{8}$").Success)
            {
                MessageBox.Show("Niepoprawny numer klienta");
                textBox2.Focus();
                return;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (!Regex.Match(textBox3.Text, @"^[a-z][a-z0-9_]*@[a-z0-9]*\.[a-z]{2,3}$").Success)
            {
                MessageBox.Show("Niepoprawny adres e-mail");
                textBox3.Focus();
                return;
            }
        }


        private void textBox9_Leave(object sender, EventArgs e)
        {
            if (!Regex.Match(textBox9.Text, @"^\d{3}$").Success)
            {
                MessageBox.Show("Błędny kod");
                textBox9.Focus();
                return;
            }
        }



        // DataBase

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\e-lekcje\3 rok\Programowanie wizualne\Projekt\Projekt_API\Database1.mdf; Integrated Security = True");

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT Login FROM Login WHERE Login='" + textBox10.Text + "'", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                MessageBox.Show("Nazwa użytkownika już istnieje", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SqlDataAdapter adapter2 = new SqlDataAdapter("SELECT Nr_klienta FROM Login WHERE Nr_klienta='" + textBox2.Text + "'", con);
                DataTable dt2 = new DataTable();
                adapter2.Fill(dt2);
                if (dt2.Rows.Count != 0)
                {
                    MessageBox.Show("Numer klieta został już podany", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SqlDataAdapter adapter3 = new SqlDataAdapter("SELECT Mail FROM Login WHERE Mail='" + textBox3.Text + "'", con);
                    DataTable dt3 = new DataTable();
                    adapter3.Fill(dt3);
                    if (dt3.Rows.Count != 0)
                    {
                        MessageBox.Show("E-mail zastał już użyty", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SqlDataAdapter adapter4 = new SqlDataAdapter("SELECT Nr_tele FROM Login WHERE Nr_tele='" + textBox4.Text + "'", con);
                        DataTable dt4 = new DataTable();
                        adapter4.Fill(dt4);
                        if(dt4.Rows.Count != 0)
                        {
                            MessageBox.Show("Numer telefonu zastał już użyty", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            SqlDataAdapter adapter5 = new SqlDataAdapter("SELECT Nr_karty FROM Login WHERE Nr_karty='" + textBox7.Text + "'", con);
                            DataTable dt5 = new DataTable();
                            adapter5.Fill(dt5);
                            if (dt5.Rows.Count != 0)
                            { 
                                MessageBox.Show("Numer karty został już podany", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                }

            }
            
            else
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Login (Login,Password,Nr_klienta,Mail,Nr_tele,Imie,Nazwisko,Nr_karty,Data_waz,kod_zab) values ('" + textBox10.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text  + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Rejestracja przebiegła pomyślnie", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start_panel form = new Start_panel();
            form.Show();
        }

        //CLEAR

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();

        }
    }
}
