using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ASELCO_201_System
{
    public partial class Aselco201filesystem : Form
    {
        string imgLocation = "";
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\gege\\Documents\\aselcoTwoZeroOne.mdf;Integrated Security=True;Connect Timeout=30");
        private String constring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\gege\\Documents\\aselcoTwoZeroOne.mdf;Integrated Security=True;Connect Timeout=30";

        private String fnamedisp;
        private String lnamedisp;
        private String mname;
        private String birthDate;
        private String birthplace;
        private String educattainment;
        private String datehired;
        private String sssno;
        private String hdmfno;
        private String tin;
        private String philhealth;
        private String employeeclass;
        private String employeestatus;
        private Image Image2;
        Timer tmr = null;

        private Image image;
        public Image Image
        {
            get { return image; }
            set { image = value; }
        }

        private String uname;
        public String Uname
        {
            get { return uname; }
            set { uname = value; }
        }

        private String lname;
        public String Lname
        {
            get { return lname; }
            set { lname = value; }
        }

        private String position;
        public String Postn
        {
            get { return position; }
            set { position = value; }
        }

        private String department;
        public String Deptn
        {
            get { return department; }
            set { department = value; }
        }

        public Aselco201filesystem()
        {
            InitializeComponent();
            this.maskedTextBox1.Click += new EventHandler(maskedTextBox1_Click);
            this.maskedTextBox2.Click += new EventHandler(maskedTextBox1_Click);
            this.maskedTextBox3.Click += new EventHandler(maskedTextBox1_Click);
            this.maskedTextBox4.Click += new EventHandler(maskedTextBox1_Click);
        }

        private void Aselco201filesystem_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CloseCancel() == false)
            {
                e.Cancel = true;
            }
        }

        //Close Button Function
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void aselco201filesystem_Load(object sender, EventArgs e)
        {
            button5.Visible = false;

            con.Open();

            SqlCommand cmd = new SqlCommand("Select fname, lname, mname from employeeRec", con);
            DataTable dttbl = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            adapt.Fill(dttbl);
            dataGridView1.DataSource = dttbl;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.MultiSelect = false;

            con.Close();
            StartTimer();

            pictureBox1.Image = Image;
            showname.Text = UppercaseFirst(Uname) + " " + UppercaseFirst(Lname);
            showpos.Text = UppercaseFirst(Postn) + ", " + UppercaseFirst(Deptn);

            var date = DateTime.Now;
            if (date.Hour < 11)
            {
                label42.Text = "Good Morning! " + UppercaseFirst(Uname) + " " + UppercaseFirst(Lname) + ".";
            }
            else if (date.Hour >= 11 && date.Hour < 14)
            {
                label42.Text = "Good Noon! " + UppercaseFirst(Uname) + " " + UppercaseFirst(Lname) + ".";
            }
            else if (date.Hour >= 14 && date.Hour < 18)
            {
                label42.Text = "Good Afternon! " + UppercaseFirst(Uname) + " " + UppercaseFirst(Lname) + ".";
            }
            else if (date.Hour >= 18)
            {
                label42.Text = "Good Evening! " + UppercaseFirst(Uname) + " " + UppercaseFirst(Lname) + ".";
            }

            searchemployee.Visible = false;
            addemployee.Visible = false;

            pictureBox5.Visible = false;
            searchtextbox.Visible = false;
            dataGridView1.Visible = false;
        }

        private void StartTimer()
        {
            tmr = new System.Windows.Forms.Timer();
            tmr.Interval = 1000;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Enabled = true;
        }

        void tmr_Tick(object sender, EventArgs e)
        {
            label41.Text = DateTime.Now.ToString("hh:mm:ss tt");

            label44.Text = DateTime.Now.ToString("D");
        }

        private void search_Enter(object sender, EventArgs e)
        {
            if (searchtextbox.Text == "Search")
            {
                searchtextbox.Text = "";
            }

            searchtextbox.ForeColor = Color.Black;
        }

        private void search_Leave(object sender, EventArgs e)
        {
            if (searchtextbox.Text == "")
            {
                searchtextbox.Text = "Search";

                button5.Visible = false;

                clear();

                searchtextbox.ForeColor = Color.Silver;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            const string message = "Are you sure you want to logout?";
            const string caption = "Logging out";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoginForm login = new LoginForm();
                login.Show();
                this.Hide();
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchemployee.Visible = true;
            addemployee.Visible = false;
            home.Visible = false;
            pictureBox5.Visible = true;
            searchtextbox.Visible = true;
            dataGridView1.Visible = false;
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            searchemployee.Visible = false;
            addemployee.Visible = true;
            home.Visible = false;
            pictureBox5.Visible = false;
            searchtextbox.Visible = false;
            dataGridView1.Visible = false;
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchemployee.Visible = false;
            addemployee.Visible = false;
            home.Visible = true;
            pictureBox5.Visible = false;
            searchtextbox.Visible = false;
            dataGridView1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            if (pictureBox6.Image == null)
            {

                byte[] images = null;
                imgLocation = "C:\\Users\\gege\\source\\repos\\joneeh\\ASELCO-201-System\\profile.png";
                FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(stream);

                images = brs.ReadBytes((int)stream.Length);
                SqlCommand cmd = new SqlCommand("insert into employeeRec(fname, lname, mname, birthDate, birthplace, educattainment, datehired, sssno, hdmfno, tin, philhealth, employeeclass, employeestatus, " +
                    "birthcertificate, marriagecertificate, diploma, barangayclearance, neuropsyclearance, judgesclearance, tor, officeorders, notices, medicalcertificateid, drugtestreportid, " +
                    "memorandumid, contractsid, performanceevalid, servicerecordsid, meritdemeritid, dateadded, dateedited, profilepic)" +
                    " values(@fname, @lname, @mname, @birthDate, @birthplace, @educattainment, @datehired, @sssno, @hdmfno, @tin, @philhealth, @employeeclass, @employeestatus, " +
                    "null, null, null, null, null, null, null, null, null, null, null, " +
                    "null, null, null, null, null, @dateadded, null, @profilepic)", con);


                var date = DateTime.Now;
                cmd.Parameters.AddWithValue("@fname", textBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@lname", textBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@mname", textBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@birthDate", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@birthplace", textBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@educattainment", textBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@datehired", dateTimePicker2.Value);
                cmd.Parameters.AddWithValue("@sssno", maskedTextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@hdmfno", maskedTextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@tin", maskedTextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@philhealth", maskedTextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@employeeclass", comboBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@employeestatus", comboBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@dateadded", date.ToShortDateString());
                cmd.Parameters.AddWithValue("@profilepic", images);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added User Successfully!");

                SqlCommand cmd5 = new SqlCommand("insert into logs(change, datechanged) values(@user, CURRENT_TIMESTAMP);", con);
                cmd5.Parameters.AddWithValue("@user", "Employee " + textBox2.Text.Trim() + " " + textBox1.Text.Trim() + " has been added to the database by " + Uname + " " + Lname + ".");
                cmd5.ExecuteNonQuery();

                con.Close();
                clear();
            }
            else
            {
                byte[] images = null;
                FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(stream);

                images = brs.ReadBytes((int)stream.Length);
                SqlCommand cmd = new SqlCommand("insert into employeeRec(fname, lname, mname, birthDate, birthplace, educattainment, datehired, sssno, hdmfno, tin, philhealth, employeeclass, employeestatus, " +
                    "birthcertificate, marriagecertificate, diploma, barangayclearance, neuropsyclearance, judgesclearance, tor, officeorders, notices, medicalcertificateid, drugtestreportid, " +
                    "memorandumid, contractsid, performanceevalid, servicerecordsid, meritdemeritid, dateadded, dateedited, profilepic)" +
                    " values(@fname, @lname, @mname, @birthDate, @birthplace, @educattainment, @datehired, @sssno, @hdmfno, @tin, @philhealth, @employeeclass, @employeestatus, " +
                    "null, null, null, null, null, null, null, null, null, null, null, " +
                    "null, null, null, null, null, @dateadded, null, @profilepic)", con);


                var date = DateTime.Now;
                cmd.Parameters.AddWithValue("@fname", textBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@lname", textBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@mname", textBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@birthDate", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@birthplace", textBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@educattainment", textBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@datehired", dateTimePicker2.Value);
                cmd.Parameters.AddWithValue("@sssno", maskedTextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@hdmfno", maskedTextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@tin", maskedTextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@philhealth", maskedTextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@employeeclass", comboBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@employeestatus", comboBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@dateadded", date.ToShortDateString());
                cmd.Parameters.AddWithValue("@profilepic", images);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added User Successfully!");

                SqlCommand cmd5 = new SqlCommand("insert into logs(change, datechanged) values(@user, CURRENT_TIMESTAMP);", con);
                cmd5.Parameters.AddWithValue("@user", "Employee " + textBox2.Text.Trim() + " " + textBox1.Text.Trim() + " has been added to the database by " + Uname + " " + Lname + ".");
                cmd5.ExecuteNonQuery();

                con.Close();
                clear();
            }
        }

        void clear()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox5.Text = textBox4.Text = maskedTextBox1.Text = maskedTextBox2.Text = maskedTextBox3.Text = maskedTextBox4.Text = "";
            dateTimePicker1 = dateTimePicker2 = null;
            comboBox1.Text = comboBox2.Text = "";
            pictureBox6.Image = pictureBox3.Image = null;

            label1.Text = label14.Text = label47.Text = label48.Text = label49.Text = label50.Text = label51.Text = label52.Text = label53.Text = label55.Text = label54.Text = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog diaglog = new OpenFileDialog();
            diaglog.Filter = "image files|*.jpg;*.png;*.gif;*.icon;.*;";
            if (diaglog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = diaglog.FileName.ToString();
                pictureBox6.ImageLocation = imgLocation;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                int index = e.RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[index];

                SqlConnection con = new SqlConnection();
                con.ConnectionString = constring;
                String query = "SELECT fname, lname, mname, birthDate, birthplace, educattainment, datehired, sssno, hdmfno, tin, philhealth, employeeclass, employeestatus, profilepic FROM employeerec WHERE fname = @fname and lname = @lname";

                label14.Text = fnamedisp + " " + mname + ". " + lnamedisp;
                label1.Text = birthDate;
                label47.Text = birthplace;
                label49.Text = educattainment;
                label48.Text = datehired;
                label53.Text = sssno;
                label52.Text = hdmfno;
                label51.Text = tin;
                label50.Text = philhealth;
                label54.Text = employeeclass;
                label55.Text = employeestatus;
                pictureBox3.Image = Image2;

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@fname", selectedRow.Cells[0].FormattedValue.ToString());
                cmd.Parameters.AddWithValue("@lname", selectedRow.Cells[1].FormattedValue.ToString());
                cmd.ExecuteScalar();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                SqlDataReader rdr = cmd.ExecuteReader();
                int count = ds.Tables[0].Rows.Count;
                if (rdr.Read())
                {

                    MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["profilepic"]);
                    Image2 = new Bitmap(ms);
                    fnamedisp = rdr["fname"].ToString();
                    lnamedisp = rdr["lname"].ToString();
                    mname = rdr["mname"].ToString();
                    birthDate = rdr.GetDateTime(3).ToString(@"dd/MM/yyyy");
                    birthplace = rdr["birthplace"].ToString();
                    educattainment = rdr["educattainment"].ToString();
                    datehired = rdr.GetDateTime(6).ToString(@"dd/MM/yyyy");
                    sssno = rdr["sssno"].ToString();
                    hdmfno = rdr["hdmfno"].ToString();
                    tin = rdr["tin"].ToString();
                    philhealth = rdr["philhealth"].ToString();
                    employeeclass = rdr["employeeclass"].ToString();
                    employeestatus = rdr["employeestatus"].ToString();
                }
                con.Close();
                dataGridView1.CurrentRow.Selected = true;
            }
        }

        private void searchBox(String search)
        {
            con.Open();
            string query = "select * from employeerec where (fname+lname) like '%" + searchtextbox.Text + "%'";
            SqlDataAdapter adapt = new SqlDataAdapter(query, con);
            DataTable dttbl3 = new DataTable();
            adapt.Fill(dttbl3);
            dataGridView1.DataSource = dttbl3;
            con.Close();
        }

        private void searchtextbox_TextChanged(object sender, EventArgs e)
        {
            searchBox(searchtextbox.Text);

            button5.Visible = true;
            dataGridView1.Visible = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
        }

        private void maskedTextBox1_Click(object sender, EventArgs e)
        {
            this.maskedTextBox1.Select(0, 0);
            this.maskedTextBox2.Select(0, 0);
            this.maskedTextBox3.Select(0, 0);
            this.maskedTextBox4.Select(0, 0);
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

                SqlCommand cmd = new SqlCommand("delete employeerec where fName=@fName or lName=@lName;", con);

                cmd.Parameters.AddWithValue("@fName", selectedRow.Cells[0].FormattedValue.ToString());
                cmd.Parameters.AddWithValue("@lName", selectedRow.Cells[1].FormattedValue.ToString());
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("insert into logs(change, datechanged) values(@user, CURRENT_TIMESTAMP);", con);
                cmd2.Parameters.AddWithValue("@user", "User " + selectedRow.Cells[0].Value.ToString() + " " + selectedRow.Cells[1].Value.ToString() + " has been removed by the administrator.");
                cmd2.ExecuteNonQuery();

                SqlCommand cmd3 = new SqlCommand("select change, datechanged from logs;", con);
                DataTable dttbl3 = new DataTable();
                SqlDataAdapter adapt3 = new SqlDataAdapter(cmd3);
                adapt3.Fill(dttbl3);
                dataGridView1.DataSource = dttbl3;

                int rowIndex = dataGridView1.CurrentCell.RowIndex;

                dataGridView1.Rows.RemoveAt(rowIndex); MessageBox.Show("User Deleted!");
                clear();
                con.Close();
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }
        }
    }
}
