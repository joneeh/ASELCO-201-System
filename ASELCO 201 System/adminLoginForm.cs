﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ASELCO_201_System
{
    public partial class adminLoginForm : Form
    {
        public adminLoginForm()
        {
            InitializeComponent();
        }

        //readonly SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\gege\\Documents\\aselcoTwoZeroOne.mdf;Integrated Security=True;Connect Timeout=30");
        readonly SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\NEWERA10\\Documents\\aselcoTwoZeroOne.mdf;Integrated Security=True;Connect Timeout=30");
        private string adminusername;

        private void getTheName(string username)
        {
            SqlConnection con = new SqlConnection();
            //con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\gege\\Documents\\aselcoTwoZeroOne.mdf;Integrated Security=True;Connect Timeout=30";
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\NEWERA10\\Documents\\aselcoTwoZeroOne.mdf;Integrated Security=True;Connect Timeout=30";
            string query = "SELECT username FROM adminlogin WHERE username = @username";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.ExecuteScalar();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    adminusername = rdr["username"].ToString();
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                con.Close();
            }
        }

        //Uppercase First Letter Converter
        static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from adminlogin where username=@username AND password=@password", con);
            cmd.Parameters.AddWithValue("@username", username.Text);
            cmd.Parameters.AddWithValue("@password", password.Text);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            con.Close();
            int count = ds.Tables[0].Rows.Count;
            string str;

            str = "select * from adminlogin";
            SqlCommand com = new SqlCommand(str, con);
            con.Open();
            SqlDataReader reader = com.ExecuteReader();

            if (string.IsNullOrEmpty(username.Text) && string.IsNullOrEmpty(password.Text))
            {
                labelMessage.ForeColor = Color.Red;
                labelMessage.Text = "Please fill the required fields!";
                username.Focus();
            }
            else if (string.IsNullOrEmpty(username.Text))
            {
                labelMessage.ForeColor = Color.Red;
                labelMessage.Text = "Please fill the username field!";
                username.Focus();
            }
            else if (string.IsNullOrEmpty(password.Text))
            {
                labelMessage.ForeColor = Color.Red;
                labelMessage.Text = "Please fill the password field!";
                password.Focus();
            }

            else if (count == 1)
            {
                getTheName(username.Text);
                MessageBox.Show("Welcome, " + UppercaseFirst(adminusername) + "!");
                Hide();
                aselco201users fm = new aselco201users();
                fm.Show();
            }
            else
            {
                labelMessage.ForeColor = Color.Red;
                labelMessage.Text = "Invalid username or password!";

                password.Text = "";
                password.Focus();
            }
            con.Close();
        }

        private void username_TextChanged(object sender, EventArgs e)
        {
            AcceptButton = button2;
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            AcceptButton = button2;
        }

        private void hr_Click(object sender, EventArgs e)
        {
            Hide();
            LoginForm fm = new LoginForm();
            fm.Show();
        }

        private void adminLoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void adminLoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
