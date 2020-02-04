using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ASELCO_201_System
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;Initial Catalog='aselco201file';username=root;password=password");
        MySqlDataAdapter query;
        DataTable table = new DataTable();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            query = new MySqlDataAdapter("SELECT username, password FROM `login` WHERE `username` = '" + username.Text + "' AND `password` = '" + password.Text + "'", connection);
            query.Fill(table);


            if (String.IsNullOrEmpty(username.Text) && String.IsNullOrEmpty(password.Text))
            {
                labelMessage.ForeColor = Color.Red;
                labelMessage.Text = "Please fill the required fields!";
            }
            else if (String.IsNullOrEmpty(username.Text))
            {
                labelMessage.ForeColor = Color.Red;
                labelMessage.Text = "Please fill the username field!";
            }
            else if (String.IsNullOrEmpty(password.Text))
            {
                labelMessage.ForeColor = Color.Red;
                labelMessage.Text = "Please fill the password field!";
            }

            else if (table.Rows.Count <= 0)
            {
                labelMessage.ForeColor = Color.Red;
                labelMessage.Text = "Invalid username or password!";
            }
            else
            {
                username.Text = String.Empty;
                password.Text = String.Empty;

                aselco201filesystem main = new aselco201filesystem();
                main.Show();

                this.Hide();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {            
            this.AcceptButton = button1;
        }
        
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = button1;
        }

        private void loginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
