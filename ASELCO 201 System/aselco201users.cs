using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace ASELCO_201_System
{
    public partial class aselco201users : Form
    {
        string imgLocation = "";
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\gege\\Documents\\aselcoTwoZeroOne.mdf;Integrated Security=True;Connect Timeout=30");

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
            con.Open();
            SqlCommand cmd = new SqlCommand("Select username, password, profilePicture, fName, lName, position, department from login", con);
            DataTable dttbl = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            adapt.Fill(dttbl);
            dataGridView1.DataSource = dttbl;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.RowHeadersVisible = false;
            con.Close();
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
            con.Open();
            byte[] images = null;
            FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(stream);
            images = brs.ReadBytes((int)stream.Length);
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

            SqlCommand cmd1 = new SqlCommand("Select username, password, profilePicture, fName, lName, position, department from login", con);
            DataTable dttbl = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter(cmd1);
            adapt.Fill(dttbl);
            dataGridView1.DataSource = dttbl;
            dataGridView1.AutoGenerateColumns = false;
            con.Close();
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

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            searchBox(textBox11.Text);
        }

        private void searchBox(String search)
        {
            con.Open();
            string query = "select * from login where (fname+lname) like '%" + textBox11.Text + "%'";
            SqlDataAdapter adapt = new SqlDataAdapter(query, con);
            DataTable dttbl3 = new DataTable();
            adapt.Fill(dttbl3);
            dataGridView1.DataSource = dttbl3;
            con.Close();
        }
    }
}
