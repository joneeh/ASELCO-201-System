using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ASELCO_201_System
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@" Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gege\Documents\aselcoTwoZeroOne.mdf;Integrated Security=True;Connect Timeout=30");
        private String fName;
        private String lName;

        private void getTheName(String username)
        {
            String queryuser = "SELECT fName AS a, lName AS b FROM login WHERE username = @username";
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(queryuser, connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.ExecuteScalar();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    fName = rdr["a"].ToString();
                    lName = rdr["b"].ToString();
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from login where username=@username AND password=@password", connection);
            cmd.Parameters.AddWithValue("@username", username.Text);
            cmd.Parameters.AddWithValue("@password", password.Text);
            connection.Open();
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            int count = ds.Tables[0].Rows.Count;
            string str;

            str = "select * from login";
            SqlCommand com = new SqlCommand(str, connection);
            SqlDataReader reader = com.ExecuteReader();

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

            else if (count == 1)
            {
                username.Text = String.Empty;
                password.Text = String.Empty;

                this.getTheName(username.Text);
                MessageBox.Show("Login Successfuly!");
                this.Hide();

                aselco201filesystem main = new aselco201filesystem();
                main.Uname = fName.Trim();
                main.Lname = lName.Trim();
                main.Show();
            }
            else
            {
                labelMessage.ForeColor = Color.Red;
                labelMessage.Text = "Invalid username or password!";

                username.Text = "";
                password.Text = "";
                username.Focus();
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
    }
}
