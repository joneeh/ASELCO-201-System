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
        //readonly SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\gege\\Documents\\aselcoTwoZeroOne.mdf;Integrated Security=True;Connect Timeout=30");
        readonly SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\NEWERA10\\Documents\\aselcoTwoZeroOne.mdf;Integrated Security=True;Connect Timeout=30");
        //private readonly string constring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\gege\\Documents\\aselcoTwoZeroOne.mdf;Integrated Security=True;Connect Timeout=30";
        private readonly string constring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\NEWERA10\\Documents\\aselcoTwoZeroOne.mdf;Integrated Security=True;Connect Timeout=30";

        private string fnamedisp;
        private string lnamedisp;
        private string mname;
        private string birthDate;
        private string birthplace;
        private string educattainment;
        private string datehired;
        private string sssno;
        private string hdmfno;
        private string tin;
        private string philhealth;
        private string employeeclass;
        private string employeestatus;
        private int id;
        private string dateresigned;
        private string datedied;
        private Image Image2;
        Timer tmr = null;

        private Image image;
        public Image Image
        {
            get { return image; }
            set { image = value; }
        }

        private string uname;
        public string Uname
        {
            get { return uname; }
            set { uname = value; }
        }

        private string lname;
        public string Lname
        {
            get { return lname; }
            set { lname = value; }
        }

        private string position;
        public string Postn
        {
            get { return position; }
            set { position = value; }
        }

        private string department;
        public string Deptn
        {
            get { return department; }
            set { department = value; }
        }

        public Aselco201filesystem()
        {
            InitializeComponent();
            maskedTextBox1.Click += new EventHandler(maskedTextBox1_Click);
            maskedTextBox2.Click += new EventHandler(maskedTextBox1_Click);
            maskedTextBox3.Click += new EventHandler(maskedTextBox1_Click);
            maskedTextBox4.Click += new EventHandler(maskedTextBox1_Click);
        }

        private void Aselco201filesystem_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CloseCancel() == false)
            {
                e.Cancel = true;
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
            pictureBox1.Image = Image;
            showname.Text = UppercaseFirst(Uname) + " " + UppercaseFirst(Lname);
            showpos.Text = UppercaseFirst(Postn) + ", " + UppercaseFirst(Deptn);

            StartTimer();

            greetings();

            listviewloadd();

            hidepanels();

        }

        void listviewloadd()
        {

            con.Open();

            counter();

            SqlCommand cmd = new SqlCommand("Select fname, lname, mname from employeeRec", con);
            DataTable dttbl = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            adapt.Fill(dttbl);

            dataGridView1.DataSource = dttbl;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.MultiSelect = false;

            SqlCommand cmd1 = new SqlCommand("Select fname, lname, mname, datehired, profilepic from employeeRec", con);
            DataTable dttbl1 = new DataTable();
            SqlDataAdapter adapt1 = new SqlDataAdapter(cmd1);
            adapt1.Fill(dttbl1);

            dataGridView4.DataSource = dttbl1;
            dataGridView4.AutoGenerateColumns = false;
            dataGridView4.MultiSelect = false;

            SqlCommand cmd2 = new SqlCommand("Select fname, lname, mname from employeeRec where employeestatus=@employeestatus", con);
            cmd2.Parameters.AddWithValue("@employeestatus", comboBox4.Text.Trim());
            DataTable dttbl2 = new DataTable();
            SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
            adapt2.Fill(dttbl2);

            dataGridView6.DataSource = dttbl2;
            dataGridView6.AutoGenerateColumns = false;
            dataGridView6.MultiSelect = false;

            con.Close();
        }

        void counter()
        {
            SqlCommand concnt = new SqlCommand("SELECT COUNT(*) FROM employeerec where employeestatus = 'active'", con);
            int count = Convert.ToInt32(concnt.ExecuteScalar());
            if (count > 0)
            {
                label21.Text = "Active Employees: " + Convert.ToString(count.ToString());
            }
            else
            {
                label21.Text = "Active Employees: 0";
            }
        }

        void greetings()
        {
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
        }

        void hidepanels()
        {
            searchemployee.Visible = false;
            addemployee.Visible = false;
            employeesort.Visible = false;
            pictureBox5.Visible = false;
            searchtextbox.Visible = false;
            dataGridView1.Visible = false;
            button5.Visible = false;
            dateTimePicker6.Visible = false;
            dateTimePicker7.Visible = false;
            label43.Visible = false;
            comboBox1.Visible = false;
            label26.Visible = false;
            groupBox4.Visible = false;
            label60.Visible = false;
            label58.Visible = false;
            label59.Visible = false;
        }

        private void StartTimer()
        {
            tmr = new Timer();
            tmr.Interval = 1;
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
                searchtextbox.ForeColor = Color.Silver;
                label58.Visible = false;
                clear();
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
                Hide();
            }
            else
            {
                DialogResult = DialogResult.No;
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchemployee.Visible = true;
            addemployee.Visible = false;
            home.Visible = false;
            pictureBox5.Visible = true;
            searchtextbox.Visible = true;
            dataGridView1.Visible = true;
            employeesort.Visible = false;
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            searchemployee.Visible = false;
            addemployee.Visible = true;
            home.Visible = false;
            pictureBox5.Visible = false;
            searchtextbox.Visible = false;
            dataGridView1.Visible = false;
            employeesort.Visible = false;
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchemployee.Visible = false;
            addemployee.Visible = false;
            home.Visible = true;
            pictureBox5.Visible = false;
            searchtextbox.Visible = false;
            dataGridView1.Visible = false;
            employeesort.Visible = false;
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchemployee.Visible = false;
            addemployee.Visible = false;
            employeesort.Visible = true;
            pictureBox5.Visible = false;
            searchtextbox.Visible = false;
            dataGridView1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            if (pictureBox6.Image == null)
            {
                if (comboBox2.Text == "Resigned")
                {
                    byte[] images = null;
                    //imgLocation = "C:\\Users\\gege\\source\\repos\\joneeh\\ASELCO-201-System\\profile.png";
                    imgLocation = "C:\\Users\\newera10\\source\\repos\\joneeh\\ASELCO-201-System\\profile.png";
                    FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader brs = new BinaryReader(stream);

                    images = brs.ReadBytes((int)stream.Length);
                    SqlCommand cmd = new SqlCommand("insert into employeeRec(id, fname, lname, mname, birthDate, birthplace, educattainment, datehired, sssno, hdmfno, tin, philhealth, employeeclass, employeestatus, " +
                        "birthcertificate, marriagecertificate, diploma, barangayclearance, neuropsyclearance, judgesclearance, tor, officeorders, notices, medicalcertificateid, drugtestreportid, " +
                        "memorandumid, contractsid, performanceevalid, servicerecordsid, meritdemeritid, dateadded, dateedited, profilepic, dateresigned, datedied)" +
                        " values(@id, @fname, @lname, @mname, @birthDate, @birthplace, @educattainment, @datehired, @sssno, @hdmfno, @tin, @philhealth, null, @employeestatus, " +
                        "null, null, null, null, null, null, null, null, null, null, null, " +
                        "null, null, null, null, null, @dateadded, null, @profilepic, @dateresigned, null)", con);

                    var date = DateTime.Now;
                    cmd.Parameters.AddWithValue("@id", textBox11.Text.Trim());
                    cmd.Parameters.AddWithValue("@fname", textBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@lname", textBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@mname", textBox3.Text.Trim() + ".");
                    cmd.Parameters.AddWithValue("@birthDate", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@birthplace", textBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@educattainment", textBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@datehired", dateTimePicker2.Value);
                    cmd.Parameters.AddWithValue("@sssno", maskedTextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@hdmfno", maskedTextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@tin", maskedTextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@philhealth", maskedTextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@employeestatus", comboBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@dateadded", date);
                    cmd.Parameters.AddWithValue("@profilepic", images);
                    cmd.Parameters.AddWithValue("@dateresigned", dateTimePicker7.Value);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added User Successfully!");

                    SqlCommand cmd5 = new SqlCommand("insert into logs(change, datechanged) values(@user, CURRENT_TIMESTAMP);", con);
                    cmd5.Parameters.AddWithValue("@user", "Employee " + textBox2.Text.Trim() + " " + textBox1.Text.Trim() + " has been added to the database by " + Uname + " " + Lname + ".");
                    cmd5.ExecuteNonQuery();

                    con.Close();
                    listviewloadd();
                    clear();
                }
                else if (comboBox2.Text == "Deceased")
                {
                    byte[] images = null;
                    //imgLocation = "C:\\Users\\gege\\source\\repos\\joneeh\\ASELCO-201-System\\profile.png";
                    imgLocation = "C:\\Users\\newera10\\source\\repos\\joneeh\\ASELCO-201-System\\profile.png";
                    FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader brs = new BinaryReader(stream);

                    images = brs.ReadBytes((int)stream.Length);
                    SqlCommand cmd = new SqlCommand("insert into employeeRec(id, fname, lname, mname, birthDate, birthplace, educattainment, datehired, sssno, hdmfno, tin, philhealth, employeeclass, employeestatus, " +
                        "birthcertificate, marriagecertificate, diploma, barangayclearance, neuropsyclearance, judgesclearance, tor, officeorders, notices, medicalcertificateid, drugtestreportid, " +
                        "memorandumid, contractsid, performanceevalid, servicerecordsid, meritdemeritid, dateadded, dateedited, profilepic, dateresigned, datedied)" +
                        " values(@id, @fname, @lname, @mname, @birthDate, @birthplace, @educattainment, @datehired, @sssno, @hdmfno, @tin, @philhealth, null, @employeestatus, " +
                        "null, null, null, null, null, null, null, null, null, null, null, " +
                        "null, null, null, null, null, @dateadded, null, @profilepic, null, @datedied)", con);

                    var date = DateTime.Now;
                    cmd.Parameters.AddWithValue("@id", textBox11.Text.Trim());
                    cmd.Parameters.AddWithValue("@fname", textBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@lname", textBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@mname", textBox3.Text.Trim() + ".");
                    cmd.Parameters.AddWithValue("@birthDate", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@birthplace", textBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@educattainment", textBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@datehired", dateTimePicker2.Value);
                    cmd.Parameters.AddWithValue("@sssno", maskedTextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@hdmfno", maskedTextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@tin", maskedTextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@philhealth", maskedTextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@employeestatus", comboBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@dateadded", date);
                    cmd.Parameters.AddWithValue("@profilepic", images);
                    cmd.Parameters.AddWithValue("@datedied", dateTimePicker6.Value);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added User Successfully!");

                    SqlCommand cmd5 = new SqlCommand("insert into logs(change, datechanged) values(@user, CURRENT_TIMESTAMP);", con);
                    cmd5.Parameters.AddWithValue("@user", "Employee " + textBox2.Text.Trim() + " " + textBox1.Text.Trim() + " has been added to the database by " + Uname + " " + Lname + ".");
                    cmd5.ExecuteNonQuery();

                    con.Close();
                    listviewloadd();
                    clear();
                }
                else
                {
                    byte[] images = null;
                    //imgLocation = "C:\\Users\\gege\\source\\repos\\joneeh\\ASELCO-201-System\\profile.png";
                    imgLocation = "C:\\Users\\newera10\\source\\repos\\joneeh\\ASELCO-201-System\\profile.png";
                    FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader brs = new BinaryReader(stream);

                    images = brs.ReadBytes((int)stream.Length);
                    SqlCommand cmd = new SqlCommand("insert into employeeRec(id, fname, lname, mname, birthDate, birthplace, educattainment, datehired, sssno, hdmfno, tin, philhealth, employeeclass, employeestatus, " +
                        "birthcertificate, marriagecertificate, diploma, barangayclearance, neuropsyclearance, judgesclearance, tor, officeorders, notices, medicalcertificateid, drugtestreportid, " +
                        "memorandumid, contractsid, performanceevalid, servicerecordsid, meritdemeritid, dateadded, dateedited, profilepic, dateresigned, datedied)" +
                        " values(@id, @fname, @lname, @mname, @birthDate, @birthplace, @educattainment, @datehired, @sssno, @hdmfno, @tin, @philhealth, @employeeclass, @employeestatus, " +
                        "null, null, null, null, null, null, null, null, null, null, null, " +
                        "null, null, null, null, null, @dateadded, null, @profilepic, null, null)", con);

                    var date = DateTime.Now;
                    cmd.Parameters.AddWithValue("@id", textBox11.Text.Trim());
                    cmd.Parameters.AddWithValue("@fname", textBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@lname", textBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@mname", textBox3.Text.Trim() + ".");
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
                    cmd.Parameters.AddWithValue("@dateadded", date);
                    cmd.Parameters.AddWithValue("@profilepic", images);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added User Successfully!");

                    SqlCommand cmd5 = new SqlCommand("insert into logs(change, datechanged) values(@user, CURRENT_TIMESTAMP);", con);
                    cmd5.Parameters.AddWithValue("@user", "Employee " + textBox2.Text.Trim() + " " + textBox1.Text.Trim() + " has been added to the database by " + Uname + " " + Lname + ".");
                    cmd5.ExecuteNonQuery();

                    con.Close();
                    listviewloadd();
                    clear();
                }                
            }
            else
            {
                if (comboBox2.Text == "Resigned")
                {
                    byte[] images = null;
                    FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader brs = new BinaryReader(stream);

                    images = brs.ReadBytes((int)stream.Length);
                    SqlCommand cmd = new SqlCommand("insert into employeeRec(id, fname, lname, mname, birthDate, birthplace, educattainment, datehired, sssno, hdmfno, tin, philhealth, employeeclass, employeestatus, " +
                        "birthcertificate, marriagecertificate, diploma, barangayclearance, neuropsyclearance, judgesclearance, tor, officeorders, notices, medicalcertificateid, drugtestreportid, " +
                        "memorandumid, contractsid, performanceevalid, servicerecordsid, meritdemeritid, dateadded, dateedited, profilepic, dateresigned, datedied)" +
                        " values(@id, @fname, @lname, @mname, @birthDate, @birthplace, @educattainment, @datehired, @sssno, @hdmfno, @tin, @philhealth, null, @employeestatus, " +
                        "null, null, null, null, null, null, null, null, null, null, null, " +
                        "null, null, null, null, null, @dateadded, null, @profilepic, @dateresigned, @employeeclass)", con);

                    var date = DateTime.Now;
                    cmd.Parameters.AddWithValue("@id", textBox11.Text.Trim());
                    cmd.Parameters.AddWithValue("@fname", textBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@lname", textBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@mname", textBox3.Text.Trim() + ".");
                    cmd.Parameters.AddWithValue("@birthDate", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@birthplace", textBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@educattainment", textBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@datehired", dateTimePicker2.Value);
                    cmd.Parameters.AddWithValue("@sssno", maskedTextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@hdmfno", maskedTextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@tin", maskedTextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@philhealth", maskedTextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@employeeclass", null);
                    cmd.Parameters.AddWithValue("@employeestatus", comboBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@dateadded", date);
                    cmd.Parameters.AddWithValue("@dateresigned", dateTimePicker7.Value);
                    cmd.Parameters.AddWithValue("@profilepic", images);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added User Successfully!");

                    SqlCommand cmd5 = new SqlCommand("insert into logs(change, datechanged) values(@user, CURRENT_TIMESTAMP);", con);
                    cmd5.Parameters.AddWithValue("@user", "Employee " + textBox2.Text.Trim() + " " + textBox1.Text.Trim() + " has been added to the database by " + Uname + " " + Lname + ".");
                    cmd5.ExecuteNonQuery();

                    con.Close();
                    listviewloadd();
                    clear();
                }
                else if (comboBox2.Text == "Deceased")
                {
                    byte[] images = null;
                    FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader brs = new BinaryReader(stream);

                    images = brs.ReadBytes((int)stream.Length);
                    SqlCommand cmd = new SqlCommand("insert into employeeRec(id, fname, lname, mname, birthDate, birthplace, educattainment, datehired, sssno, hdmfno, tin, philhealth, employeeclass, employeestatus, " +
                        "birthcertificate, marriagecertificate, diploma, barangayclearance, neuropsyclearance, judgesclearance, tor, officeorders, notices, medicalcertificateid, drugtestreportid, " +
                        "memorandumid, contractsid, performanceevalid, servicerecordsid, meritdemeritid, dateadded, dateedited, profilepic, dateresigned, datedied)" +
                        " values(@id, @fname, @lname, @mname, @birthDate, @birthplace, @educattainment, @datehired, @sssno, @hdmfno, @tin, @philhealth, null, @employeestatus, " +
                        "null, null, null, null, null, null, null, null, null, null, null, " +
                        "null, null, null, null, null, @dateadded, null, @profilepic, null, @datedied)", con);

                    var date = DateTime.Now;
                    cmd.Parameters.AddWithValue("@id", textBox11.Text.Trim());
                    cmd.Parameters.AddWithValue("@fname", textBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@lname", textBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@mname", textBox3.Text.Trim() + ".");
                    cmd.Parameters.AddWithValue("@birthDate", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@birthplace", textBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@educattainment", textBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@datehired", dateTimePicker2.Value);
                    cmd.Parameters.AddWithValue("@sssno", maskedTextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@hdmfno", maskedTextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@tin", maskedTextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@philhealth", maskedTextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@employeestatus", comboBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@dateadded", date);
                    cmd.Parameters.AddWithValue("@datedied", dateTimePicker6.Value);
                    cmd.Parameters.AddWithValue("@profilepic", images);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added User Successfully!");

                    SqlCommand cmd5 = new SqlCommand("insert into logs(change, datechanged) values(@user, CURRENT_TIMESTAMP);", con);
                    cmd5.Parameters.AddWithValue("@user", "Employee " + textBox2.Text.Trim() + " " + textBox1.Text.Trim() + " has been added to the database by " + Uname + " " + Lname + ".");
                    cmd5.ExecuteNonQuery();

                    con.Close();
                    listviewloadd();
                    clear();
                }
                else
                {
                    byte[] images = null;
                    FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader brs = new BinaryReader(stream);

                    images = brs.ReadBytes((int)stream.Length);
                    SqlCommand cmd = new SqlCommand("insert into employeeRec(id, fname, lname, mname, birthDate, birthplace, educattainment, datehired, sssno, hdmfno, tin, philhealth, employeeclass, employeestatus, " +
                        "birthcertificate, marriagecertificate, diploma, barangayclearance, neuropsyclearance, judgesclearance, tor, officeorders, notices, medicalcertificateid, drugtestreportid, " +
                        "memorandumid, contractsid, performanceevalid, servicerecordsid, meritdemeritid, dateadded, dateedited, profilepic, dateresigned, datedied)" +
                        " values(@id, @fname, @lname, @mname, @birthDate, @birthplace, @educattainment, @datehired, @sssno, @hdmfno, @tin, @philhealth, @employeeclass, @employeestatus, " +
                        "null, null, null, null, null, null, null, null, null, null, null, " +
                        "null, null, null, null, null, @dateadded, null, @profilepic, null, null)", con);

                    var date = DateTime.Now;
                    cmd.Parameters.AddWithValue("@id", textBox11.Text.Trim());
                    cmd.Parameters.AddWithValue("@fname", textBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@lname", textBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@mname", textBox3.Text.Trim() + ".");
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
                    cmd.Parameters.AddWithValue("@dateadded", date);
                    cmd.Parameters.AddWithValue("@profilepic", images);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added User Successfully!");

                    SqlCommand cmd5 = new SqlCommand("insert into logs(change, datechanged) values(@user, CURRENT_TIMESTAMP);", con);
                    cmd5.Parameters.AddWithValue("@user", "Employee " + textBox2.Text.Trim() + " " + textBox1.Text.Trim() + " has been added to the database by " + Uname + " " + Lname + ".");
                    cmd5.ExecuteNonQuery();

                    con.Close();
                    listviewloadd();
                    clear();
                }
            }
        }

        void clear()
        {
            textBox11.Text = textBox1.Text = textBox2.Text = textBox3.Text = textBox5.Text = textBox4.Text = maskedTextBox1.Text = maskedTextBox2.Text = maskedTextBox3.Text = maskedTextBox4.Text = "";            
            comboBox1.Text = comboBox2.Text = "";
            pictureBox6.Image = pictureBox3.Image = null;            

            label1.Text = label14.Text = label47.Text = label48.Text = label57.Text = label49.Text = label50.Text = label51.Text = label52.Text = label53.Text = label55.Text = label54.Text = label59.Text = label60.Text = null;
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
            dataGridView1.CurrentRow.Selected = true;
            button5.Visible = true;
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                int index = e.RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[index];

                SqlConnection con = new SqlConnection();
                con.ConnectionString = constring;
                string query = "SELECT id, fname, lname, mname, birthDate, birthplace, educattainment, datehired, sssno, hdmfno, tin, philhealth, employeeclass, employeestatus, profilepic, dateresigned, datedied FROM employeerec WHERE fname = @fname and lname = @lname";

                label14.Text = fnamedisp + " " + mname + " " + lnamedisp;
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
                label59.Text = dateresigned;
                label60.Text = datedied;
                label57.Text = string.Format("{0:0000}", id);
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
                if (rdr.Read())
                {
                    id = int.Parse(rdr["id"].ToString());
                    MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["profilepic"]);
                    Image2 = new Bitmap(ms);
                    fnamedisp = rdr["fname"].ToString();
                    lnamedisp = rdr["lname"].ToString();
                    mname = rdr["mname"].ToString();
                    birthDate = rdr.GetDateTime(4).ToString(@"dd/MM/yyyy");
                    birthplace = rdr["birthplace"].ToString();
                    educattainment = rdr["educattainment"].ToString();
                    datehired = rdr.GetDateTime(7).ToString(@"dd/MM/yyyy");
                    sssno = rdr["sssno"].ToString();
                    hdmfno = rdr["hdmfno"].ToString();
                    tin = rdr["tin"].ToString();
                    philhealth = rdr["philhealth"].ToString();
                    employeeclass = rdr["employeeclass"].ToString();

                    dateresigned = rdr["dateresigned"].ToString();
                    if (String.IsNullOrEmpty(dateresigned) == true)
                    {
                        dateresigned = null;
                    }
                    else
                    {
                        dateresigned = rdr.GetDateTime(15).ToString(@"dd/MM/yyyy");
                        label60.Visible = false;
                        label59.Visible = true;
                        label54.Visible = false;
                        label12.Visible = false;
                        label58.Visible = true;
                    }
                    datedied = rdr["datedied"].ToString();
                    if (String.IsNullOrEmpty(datedied) == true)
                    {
                        datedied = null;
                    }
                    else
                    {
                        datedied = rdr.GetDateTime(16).ToString(@"dd/MM/yyyy");
                        label59.Visible = false;
                        label60.Visible = true;
                        label54.Visible = false;
                        label12.Visible = false;
                        label58.Visible = true;
                    }
                    employeestatus = rdr["employeestatus"].ToString();
                }
                con.Close();
            }
        }

        private void searchBox(string search)
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
            maskedTextBox1.Select(0, 0);
            maskedTextBox2.Select(0, 0);
            maskedTextBox3.Select(0, 0);
            maskedTextBox4.Select(0, 0);
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
                listviewloadd();
            }
            else
            {
                DialogResult = DialogResult.No;
            }
        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd1 = new SqlCommand("Select fname, lname, mname from employeeRec where employeeclass=@employeeclass", con);

            cmd1.Parameters.AddWithValue("@employeeclass", comboBox3.Text.Trim());
            DataTable dttbl1 = new DataTable();
            SqlDataAdapter adapt1 = new SqlDataAdapter(cmd1);
            adapt1.Fill(dttbl1);
            dataGridView5.DataSource = dttbl1;
            dataGridView5.AutoGenerateColumns = false;
            dataGridView5.MultiSelect = false;
            cmd1.ExecuteNonQuery();

            con.Close();
        }

        private void comboBox4_SelectedValueChanged(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd2 = new SqlCommand("Select fname, lname, mname from employeeRec where employeestatus=@employeestatus", con);

            cmd2.Parameters.AddWithValue("@employeestatus", comboBox4.Text.Trim());
            DataTable dttbl2 = new DataTable();
            SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
            adapt2.Fill(dttbl2);
            dataGridView6.DataSource = dttbl2;
            dataGridView6.AutoGenerateColumns = false;
            dataGridView6.MultiSelect = false;
            cmd2.ExecuteNonQuery();

            con.Close();
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {

            if (comboBox2.Text == "Deceased")
            {
                comboBox1.Visible = false;
                label26.Visible = false;
                dateTimePicker6.Visible = true;
                dateTimePicker7.Visible = false;
                label43.Visible = true;
            }
            else if (comboBox2.Text == "Resigned")
            {
                comboBox1.Visible = false;
                label26.Visible = false;
                dateTimePicker7.Visible = true;
                dateTimePicker6.Visible = false;
                label43.Visible = true;
            }
            else
            {
                comboBox1.Visible = true;
                label26.Visible = true;
                dateTimePicker6.Visible = false;
                dateTimePicker7.Visible = false;
                label43.Visible = false;
            }
        }

        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text == "Active")
            {
                groupBox4.Visible = true;
            }
            else
            {
                groupBox4.Visible = false;
            }
        }
    }
}
