using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASELCO_201_System
{
    public partial class aselco201users : Form
    {
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
            bg_dtg();
            dataGridView1.DataSource = dttbl;
        }

        private void aselco201users_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CloseCancel() == false)
            {
                e.Cancel = true;
            }
        }

        public void bg_dtg()
        {
            try
            {

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (IsOdd(i))
                    {

                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }
    }
}
