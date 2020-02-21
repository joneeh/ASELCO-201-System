namespace ASELCO_201_System
{
    partial class Aselco201filesystem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.showname = new System.Windows.Forms.Label();
            this.search = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.showpos = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.ForestGreen;
            this.panel1.Controls.Add(this.showname);
            this.panel1.Controls.Add(this.search);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.showpos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1080, 82);
            this.panel1.TabIndex = 0;
            // 
            // showname
            // 
            this.showname.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.showname.AutoSize = true;
            this.showname.BackColor = System.Drawing.Color.Transparent;
            this.showname.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showname.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.showname.Location = new System.Drawing.Point(773, 10);
            this.showname.Margin = new System.Windows.Forms.Padding(0);
            this.showname.MinimumSize = new System.Drawing.Size(200, 0);
            this.showname.Name = "showname";
            this.showname.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.showname.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.showname.Size = new System.Drawing.Size(200, 39);
            this.showname.TabIndex = 0;
            this.showname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // search
            // 
            this.search.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.search.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.search.Location = new System.Drawing.Point(282, 30);
            this.search.MinimumSize = new System.Drawing.Size(350, 40);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(350, 30);
            this.search.TabIndex = 3;
            this.search.Text = "Search";
            this.search.Enter += new System.EventHandler(this.search_Enter);
            this.search.Leave += new System.EventHandler(this.search_Leave);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comboBox1.DropDownWidth = 50;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Logout"});
            this.comboBox1.Location = new System.Drawing.Point(1051, 48);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox1.Size = new System.Drawing.Size(17, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(979, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // showpos
            // 
            this.showpos.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.showpos.AutoSize = true;
            this.showpos.BackColor = System.Drawing.Color.Transparent;
            this.showpos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showpos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.showpos.Location = new System.Drawing.Point(773, 46);
            this.showpos.Margin = new System.Windows.Forms.Padding(0);
            this.showpos.MinimumSize = new System.Drawing.Size(200, 0);
            this.showpos.Name = "showpos";
            this.showpos.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.showpos.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.showpos.Size = new System.Drawing.Size(200, 24);
            this.showpos.TabIndex = 1;
            this.showpos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Aselco201filesystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 558);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Aselco201filesystem";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ASELCO 201 File System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Aselco201filesystem_FormClosing);
            this.Load += new System.EventHandler(this.aselco201filesystem_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label showname;
        private System.Windows.Forms.Label showpos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox search;
    }
}