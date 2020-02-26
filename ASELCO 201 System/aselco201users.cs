using System;
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
            if (pictureBox2.Image == null)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into login(username, password, profilePicture, fName, lName, position, department) values(@username, @password, @images, @fName, @lName, @position, @department)", con);

                cmd.Parameters.AddWithValue("@username", textBox1.Text.Trim() + "." + textBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@password", textBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@fName", textBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@lName", textBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@position", textBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@department", textBox4.Text.Trim());
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
            else
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
        }

        void clear()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = "";
            pictureBox1.Image = null;
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                int index = e.RowIndex;
                dataGridView1.CurrentRow.Selected = true;
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                textBox6.Text = selectedRow.Cells[1].FormattedValue.ToString();
                textBox10.Text = selectedRow.Cells[3].FormattedValue.ToString();
                textBox9.Text = selectedRow.Cells[4].FormattedValue.ToString();
                textBox8.Text = selectedRow.Cells[6].FormattedValue.ToString();
                textBox7.Text = selectedRow.Cells[5].FormattedValue.ToString();

                var data = (Byte[])(selectedRow.Cells[2].Value);
                var stream = new MemoryStream(data);
                pictureBox2.Image = Image.FromStream(stream);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            byte[] images = null;
            FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(stream);
            images = brs.ReadBytes((int)stream.Length);
            SqlCommand cmd = new SqlCommand("update login set username=@username, password=@password, fName=@fName, lName=@lName, position=@position, department=@department, profilePicture=@images where fName=@fName1 or lName=@lName1;", con);

            DataGridViewRow selectedRow = dataGridView1.CurrentRow;

            cmd.Parameters.AddWithValue("@username", textBox10.Text.Trim() + "." + textBox9.Text.Trim());
            cmd.Parameters.AddWithValue("@password", textBox6.Text.Trim());
            cmd.Parameters.AddWithValue("@fName1", selectedRow.Cells[3].Value.ToString());
            cmd.Parameters.AddWithValue("@lName1", selectedRow.Cells[4].Value.ToString());
            cmd.Parameters.AddWithValue("@fName", textBox10.Text.Trim());
            cmd.Parameters.AddWithValue("@lName", textBox9.Text.Trim());
            cmd.Parameters.AddWithValue("@position", textBox7.Text.Trim());
            cmd.Parameters.AddWithValue("@department", textBox8.Text.Trim());
            cmd.Parameters.AddWithValue("@images", images);
            cmd.ExecuteNonQuery();
            MessageBox.Show("User Updated Successfully!");
            clear();

            SqlCommand cmd1 = new SqlCommand("Select username, password, profilePicture, fName, lName, position, department from login", con);
            DataTable dttbl = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter(cmd1);
            adapt.Fill(dttbl);
            dataGridView1.DataSource = dttbl;
            dataGridView1.AutoGenerateColumns = false;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog diaglog = new OpenFileDialog();
            diaglog.Filter = "image files|*.jpg;*.png;*.gif;*.icon;.*;";
            if (diaglog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = diaglog.FileName.ToString();
                pictureBox2.ImageLocation = imgLocation;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.CurrentRow;
            const string message = "Are you sure you want to delete the selected user?";
            const string caption = "Deleting user";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("delete login where fName=@fName1 or lName=@lName1;", con);

                cmd.Parameters.AddWithValue("@fName1", selectedRow.Cells[3].Value.ToString());
                cmd.Parameters.AddWithValue("@lName1", selectedRow.Cells[4].Value.ToString());
                cmd.ExecuteNonQuery();

                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(rowIndex);

                MessageBox.Show("User Deleted!");
                con.Close();
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }
        }
    }
}
