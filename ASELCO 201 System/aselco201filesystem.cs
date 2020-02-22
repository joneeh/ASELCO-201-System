using System;
using System.Drawing;
using System.Windows.Forms;

namespace ASELCO_201_System
{
    public partial class Aselco201filesystem : Form
    {

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

        public void hidePanels()
        {
            searchemployee.Visible = false;
            addemployee.Visible = false;
        }

        public Aselco201filesystem()
        {
            InitializeComponent();
            Load += new EventHandler(aselco201filesystem_Load);
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
            pictureBox1.Image = Image;
            showname.Text = UppercaseFirst(Uname) + " " + UppercaseFirst(Lname);
            showpos.Text = UppercaseFirst(Postn) + ", " + UppercaseFirst(Deptn);
            hidePanels();
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

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hidePanels();
            searchemployee.Visible = true;
        }
    }
}
