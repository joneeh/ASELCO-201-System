using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ASELCO_201_System
{
    public partial class aselco201filesystem : Form
    {
        public aselco201filesystem()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void aselco201filesystem_FormClosing(object sender, FormClosingEventArgs e)
        {

            CloseCancel();

        }

        public static void CloseCancel()
        {
            const string message = "Are you sure that you would like to close?";
            const string caption = "Exiting ASELCO 201 File System";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                loginForm login = new loginForm();
                login.Show();
            }
        }
    }
}
