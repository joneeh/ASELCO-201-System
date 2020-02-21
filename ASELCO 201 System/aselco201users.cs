using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ASELCO_201_System
{
    public partial class aselco201users : Form
    {
        string imgLocation = "";

        public aselco201users()
        {
            InitializeComponent();
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
                aselco201users adminlogin = new aselco201users();
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

        private void aselco201users_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\gege\\Documents\\aselcoTwoZeroOne.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand("Select profilePicture as 'Profile Picture', fName as 'First Name', lName as 'Last Name', department as 'Department', position as 'Position', username as 'Username', password as 'Password' from login", con);
            DataTable dttbl = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            adapt.Fill(dttbl);
            dataGridView1.DataSource = dttbl;
        }

        private void aselco201users_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CloseCancel() == false)
            {
                e.Cancel = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] images = null;
            FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(stream);
            images = brs.ReadBytes((int)stream.Length);

            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\gege\\Documents\\aselcoTwoZeroOne.mdf; Integrated Security = True; Connect Timeout = 30");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into login(username, password, profilePicture, fName, lName, position, department) values(@username, @password, @images, @fName, @lName, @position, @department)", con);

            cmd.Parameters.AddWithValue("@username", textBox1.Text.Trim() + "." + textBox2.Text.Trim());
            cmd.Parameters.AddWithValue("@password", textBox5.Text.Trim());
            cmd.Parameters.AddWithValue("@fName", textBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@lName", textBox2.Text.Trim());
            cmd.Parameters.AddWithValue("@position", textBox3.Text.Trim());
            cmd.Parameters.AddWithValue("@department", textBox4.Text.Trim());
            cmd.Parameters.AddWithValue("@images", images);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Added User Successfully!");
            clear();

            SqlConnection con1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\gege\\Documents\\aselcoTwoZeroOne.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd1 = new SqlCommand("Select profilePicture as 'Profile Picture', fName as 'First Name', lName as 'Last Name', department as 'Department', position as 'Position', username as 'Username', password as 'Password' from login", con1);
            DataTable dttbl = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter(cmd1);
            adapt.Fill(dttbl);
            dataGridView1.DataSource = dttbl;
        }

        void clear()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog diaglog = new OpenFileDialog();
            diaglog.Filter = "image files|*.jpg;*.png;*.gif;*.icon;.*;";
            if (diaglog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = diaglog.FileName.ToString();
                pictureBox1.ImageLocation = imgLocation;
            }

        }
    }
}
