using System;
using System.Windows.Forms;

namespace ASELCO_201_System
{
    public partial class aselco201filesystem : Form
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

        public aselco201filesystem()
        {
            InitializeComponent();
        }

        private void aselco201filesystem_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CloseCancel() == false)
            {
                e.Cancel = true;
            }
        }

        public static bool CloseCancel()
        {
            const string message = "Are you sure that you would like to close?";
            const string caption = "Exiting ASELCO 201 File System";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                loginForm login = new loginForm();
                login.Close();

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

        private void aselco201filesystem_Load(object sender, EventArgs e)
        {
            showname.Text = "Welcome " + Uname + " " + Lname;
        }
    }
}
