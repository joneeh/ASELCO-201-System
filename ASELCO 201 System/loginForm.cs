using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ASELCO_201_System
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private String fname;
        private String lname;
        private String position;
        private String department;

        private void getTheName(String username)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\gege\\Documents\\aselcoTwoZeroOne.mdf;Integrated Security=True;Connect Timeout=30";
            String query = "SELECT fname, lname, position, department, profilePicture FROM login WHERE username = @username";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.ExecuteScalar();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    fname = rdr["fname"].ToString();
                    lname = rdr["lname"].ToString();
                    position = rdr["position"].ToString();
                    department = rdr["department"].ToString();
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
        public static bool CloseCancel()
        {
            const string message = "Are you sure that you would like to close?";
            const string caption = "Closing ASELCO 201 File System";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoginForm login = new LoginForm();
                adminLoginForm adminlogin = new adminLoginForm();
                login.Close();
                adminlogin.Close();

                Environment.Exit(0);

                return true;
            }
            else
            {
                return false;
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

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\gege\\Documents\\aselcoTwoZeroOne.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand("Select * from login where username=@username AND password=@password", con);
            cmd.Parameters.AddWithValue("@username", username.Text);
            cmd.Parameters.AddWithValue("@password", password.Text);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            con.Close();
            int count = ds.Tables[0].Rows.Count;
            string str;

            str = "select * from login";
            SqlCommand com = new SqlCommand(str, con);
            con.Open();
            SqlDataReader reader = com.ExecuteReader();

            if (String.IsNullOrEmpty(username.Text) && String.IsNullOrEmpty(password.Text))
            {
                labelMessage.ForeColor = Color.Red;
                labelMessage.Text = "Please fill the required fields!";
                username.Focus();
            }
            else if (String.IsNullOrEmpty(username.Text))
            {
                labelMessage.ForeColor = Color.Red;
                labelMessage.Text = "Please fill the username field!";
                username.Focus();
            }
            else if (String.IsNullOrEmpty(password.Text))
            {
                labelMessage.ForeColor = Color.Red;
                labelMessage.Text = "Please fill the password field!";
                password.Focus();
            }

            else if (count == 1)
            {
                MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["profilePicture"]);

                this.getTheName(username.Text);
                MessageBox.Show("Welcome, " + UppercaseFirst(fname) + "!");
                this.Hide();
                Aselco201filesystem fm = new Aselco201filesystem();

                fm.Image = new Bitmap(ms);
                fm.Uname = fname.Trim();
                fm.Lname = lname.Trim();
                fm.Postn = position.Trim();
                fm.Deptn = department.Trim();
                fm.Show();
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

        private void admin_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminLoginForm fm = new adminLoginForm();
            fm.Show();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
