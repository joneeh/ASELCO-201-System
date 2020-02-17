using System;
using System.Drawing;
using System.Windows.Forms;

namespace ASELCO_201_System
{
    public partial class Aselco201filesystem : Form
    {

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
            showname.Text = UppercaseFirst(Uname) + " " + UppercaseFirst(Lname);
            showpos.Text = UppercaseFirst(Postn) + ", " + UppercaseFirst(Deptn);
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
    }
}
