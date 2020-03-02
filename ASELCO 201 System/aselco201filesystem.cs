using System;
using System.ComponentModel;
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
            StartTimer();

            pictureBox1.Image = Image;
            showname.Text = UppercaseFirst(Uname) + " " + UppercaseFirst(Lname);
            showpos.Text = UppercaseFirst(Postn) + ", " + UppercaseFirst(Deptn);
            
            var date = DateTime.Now;
            if (date.Hour < 11)
            {
                label42.Text = "Good Morning! " + UppercaseFirst(Uname) + " " + UppercaseFirst(Lname) + ".";
            }
            else if (date.Hour <= 11 && date.Hour < 14)
            {
                label42.Text = "Good Noon! " + UppercaseFirst(Uname) + " " + UppercaseFirst(Lname) + ".";
            }
            else if (date.Hour < 15 && date.Hour < 18)
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
            search.Visible = false;
            label1.Visible = false;
        }


        System.Windows.Forms.Timer tmr = null;

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

        private void search_Click(object sender, EventArgs e)
        {

        }

        private void search_Enter(object sender, EventArgs e)
        {
            if (search.Text == "Search") {
                search.Text = "";
            };

            search.ForeColor = Color.Black;
        }

        private void search_Leave(object sender, EventArgs e)
        {
            if (search.Text == "") {
                search.Text = "Search";

            search.ForeColor = Color.Silver;
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
            search.Visible = true;
            label1.Visible = true;
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            searchemployee.Visible = false;
            addemployee.Visible = true;
            home.Visible = false;
            pictureBox5.Visible = false;
            search.Visible = false;
            label1.Visible = false;
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchemployee.Visible = false;
            addemployee.Visible = false;
            home.Visible = true;
            pictureBox5.Visible = false;
            search.Visible = false;
            label1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            byte[] images = null;
            FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(stream);
            images = brs.ReadBytes((int)stream.Length);
            SqlCommand cmd = new SqlCommand("insert into employeeRec(fname, lname, mname, birthDate, birthplace, educattainment, datehired, sssno, hdmfno, tin, philhealth," +
                "birthcertificate, marriagecertificate, diploma, barangayclearance, neuropsyclearance, judgesclearance, tor, officeorders, notices, medicalcertificateid, drugtestreportid, " +
                "memorandumid, contractsid, performanceevalid, servicerecordsid, meritdemeritid)" +
                " values(@fname, @lname, @mname, @birthDate, @birthplace, @educattainment, @datehired, @sssno, @hdmfno, @tin, @philhealth," +
                "null, null, null, null, null, null, null, null, null, null, null, " +
                "null, null, null, null, null)", con);

            cmd.Parameters.AddWithValue("@fname", textBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@lname", textBox2.Text.Trim());
            cmd.Parameters.AddWithValue("@mname", textBox3.Text.Trim());
            cmd.Parameters.AddWithValue("@birthDate", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@birthplace", textBox5.Text.Trim());
            cmd.Parameters.AddWithValue("@educattainment", textBox4.Text.Trim());
            cmd.Parameters.AddWithValue("@datehired", dateTimePicker2.Value);
            cmd.Parameters.AddWithValue("@sssno", textBox9.Text.Trim());
            cmd.Parameters.AddWithValue("@hdmfno", textBox8.Text.Trim());
            cmd.Parameters.AddWithValue("@tin", textBox7.Text.Trim());
            cmd.Parameters.AddWithValue("@philhealth", textBox11.Text.Trim());
            cmd.Parameters.AddWithValue("@images", images);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Added User Successfully!");

            SqlCommand cmd5 = new SqlCommand("insert into logs(change, datechanged) values(@user, CURRENT_TIMESTAMP);", con);
            cmd5.Parameters.AddWithValue("@user", "User " + textBox1.Text.Trim() + " " + textBox2.Text.Trim() + " has been added by the administrator.");
            cmd5.ExecuteNonQuery();

            con.Close();
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
    }
}
