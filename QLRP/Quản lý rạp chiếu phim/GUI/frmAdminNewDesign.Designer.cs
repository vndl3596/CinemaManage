namespace GUI
{
    partial class frmAdminNewDesign
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdminNewDesign));
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnAdmin = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grClock = new System.Windows.Forms.GroupBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.Clock = new System.Windows.Forms.Timer(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAccountUC = new System.Windows.Forms.Button();
            this.btnCustomerUC = new System.Windows.Forms.Button();
            this.btnStaffUC = new System.Windows.Forms.Button();
            this.btnDataUC = new System.Windows.Forms.Button();
            this.btnRevenueUC = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.grClock.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pnAdmin);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1832, 777);
            this.panel2.TabIndex = 2;
            // 
            // pnAdmin
            // 
            this.pnAdmin.BackColor = System.Drawing.Color.LightCyan;
            this.pnAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnAdmin.Location = new System.Drawing.Point(0, 117);
            this.pnAdmin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnAdmin.Name = "pnAdmin";
            this.pnAdmin.Size = new System.Drawing.Size(1832, 660);
            this.pnAdmin.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.PapayaWhip;
            this.panel3.Controls.Add(this.grClock);
            this.panel3.Controls.Add(this.btnExit);
            this.panel3.Controls.Add(this.btnAccountUC);
            this.panel3.Controls.Add(this.btnCustomerUC);
            this.panel3.Controls.Add(this.btnStaffUC);
            this.panel3.Controls.Add(this.btnDataUC);
            this.panel3.Controls.Add(this.btnRevenueUC);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1832, 117);
            this.panel3.TabIndex = 1;
            // 
            // grClock
            // 
            this.grClock.Controls.Add(this.lblDate);
            this.grClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grClock.Location = new System.Drawing.Point(1553, 70);
            this.grClock.Name = "grClock";
            this.grClock.Size = new System.Drawing.Size(276, 47);
            this.grClock.TabIndex = 2;
            this.grClock.TabStop = false;
            this.grClock.Text = "Đồng hồ:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(6, 23);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(52, 24);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Date";
            // 
            // Clock
            // 
            this.Clock.Enabled = true;
            this.Clock.Tick += new System.EventHandler(this.Clock_Tick);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnExit.ForeColor = System.Drawing.SystemColors.Control;
            this.btnExit.Image = global::GUI.Properties.Resources.Apps_Dialog_Shutdown_icon;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnExit.Location = new System.Drawing.Point(924, 18);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(155, 79);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Thoát";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btnAccountUC
            // 
            this.btnAccountUC.BackColor = System.Drawing.Color.Goldenrod;
            this.btnAccountUC.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnAccountUC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnAccountUC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnAccountUC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccountUC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnAccountUC.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAccountUC.Image = global::GUI.Properties.Resources.vista_icons_08;
            this.btnAccountUC.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAccountUC.Location = new System.Drawing.Point(751, 18);
            this.btnAccountUC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAccountUC.Name = "btnAccountUC";
            this.btnAccountUC.Size = new System.Drawing.Size(155, 79);
            this.btnAccountUC.TabIndex = 0;
            this.btnAccountUC.Text = "Tài Khoản";
            this.btnAccountUC.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnAccountUC.UseVisualStyleBackColor = false;
            this.btnAccountUC.Click += new System.EventHandler(this.btnAccountUC_Click);
            // 
            // btnCustomerUC
            // 
            this.btnCustomerUC.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCustomerUC.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnCustomerUC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnCustomerUC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnCustomerUC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomerUC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnCustomerUC.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCustomerUC.Image = global::GUI.Properties.Resources.User_Clients_icon;
            this.btnCustomerUC.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCustomerUC.Location = new System.Drawing.Point(579, 18);
            this.btnCustomerUC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCustomerUC.Name = "btnCustomerUC";
            this.btnCustomerUC.Size = new System.Drawing.Size(155, 79);
            this.btnCustomerUC.TabIndex = 0;
            this.btnCustomerUC.Text = "Khách Hàng";
            this.btnCustomerUC.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnCustomerUC.UseVisualStyleBackColor = false;
            this.btnCustomerUC.Click += new System.EventHandler(this.btnCustomerUC_Click);
            // 
            // btnStaffUC
            // 
            this.btnStaffUC.BackColor = System.Drawing.Color.PaleVioletRed;
            this.btnStaffUC.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnStaffUC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnStaffUC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnStaffUC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStaffUC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnStaffUC.ForeColor = System.Drawing.SystemColors.Control;
            this.btnStaffUC.Image = global::GUI.Properties.Resources.engineer_icon;
            this.btnStaffUC.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnStaffUC.Location = new System.Drawing.Point(405, 18);
            this.btnStaffUC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStaffUC.Name = "btnStaffUC";
            this.btnStaffUC.Size = new System.Drawing.Size(155, 79);
            this.btnStaffUC.TabIndex = 0;
            this.btnStaffUC.Text = "Nhân Viên";
            this.btnStaffUC.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnStaffUC.UseVisualStyleBackColor = false;
            this.btnStaffUC.Click += new System.EventHandler(this.btnStaffUC_Click);
            // 
            // btnDataUC
            // 
            this.btnDataUC.BackColor = System.Drawing.Color.ForestGreen;
            this.btnDataUC.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnDataUC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnDataUC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnDataUC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDataUC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnDataUC.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDataUC.Image = global::GUI.Properties.Resources.Documents_icon;
            this.btnDataUC.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnDataUC.Location = new System.Drawing.Point(227, 18);
            this.btnDataUC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDataUC.Name = "btnDataUC";
            this.btnDataUC.Size = new System.Drawing.Size(155, 79);
            this.btnDataUC.TabIndex = 0;
            this.btnDataUC.Text = "Dữ Liệu";
            this.btnDataUC.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnDataUC.UseVisualStyleBackColor = false;
            this.btnDataUC.Click += new System.EventHandler(this.btnDataUC_Click);
            // 
            // btnRevenueUC
            // 
            this.btnRevenueUC.BackColor = System.Drawing.Color.DarkViolet;
            this.btnRevenueUC.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnRevenueUC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnRevenueUC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnRevenueUC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRevenueUC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnRevenueUC.ForeColor = System.Drawing.SystemColors.Control;
            this.btnRevenueUC.Image = global::GUI.Properties.Resources.numbers_black_icon;
            this.btnRevenueUC.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnRevenueUC.Location = new System.Drawing.Point(53, 18);
            this.btnRevenueUC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRevenueUC.Name = "btnRevenueUC";
            this.btnRevenueUC.Size = new System.Drawing.Size(155, 79);
            this.btnRevenueUC.TabIndex = 0;
            this.btnRevenueUC.Text = "Doanh Thu";
            this.btnRevenueUC.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnRevenueUC.UseVisualStyleBackColor = false;
            this.btnRevenueUC.Click += new System.EventHandler(this.btnRevenueUC_Click);
            // 
            // frmAdminNewDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1832, 777);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmAdminNewDesign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý";
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.grClock.ResumeLayout(false);
            this.grClock.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAccountUC;
        private System.Windows.Forms.Button btnCustomerUC;
        private System.Windows.Forms.Button btnStaffUC;
        private System.Windows.Forms.Button btnDataUC;
        private System.Windows.Forms.Button btnRevenueUC;
        public System.Windows.Forms.Panel pnAdmin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Timer Clock;
        private System.Windows.Forms.GroupBox grClock;
        private System.Windows.Forms.Label lblDate;
    }
}