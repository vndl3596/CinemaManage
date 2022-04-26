
namespace GUI
{
    partial class frmStaffInfo
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
            this.grStaff = new System.Windows.Forms.GroupBox();
            this.dtStaffBirth = new System.Windows.Forms.DateTimePicker();
            this.lblStaffID = new System.Windows.Forms.Label();
            this.txtStaffId = new System.Windows.Forms.TextBox();
            this.txtStaffAddress = new System.Windows.Forms.TextBox();
            this.lblStaffINumber = new System.Windows.Forms.Label();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.lblStaffBirth = new System.Windows.Forms.Label();
            this.txtStaffPhone = new System.Windows.Forms.TextBox();
            this.lblStaffPhone = new System.Windows.Forms.Label();
            this.lblStaffAddress = new System.Windows.Forms.Label();
            this.txtStaffINumber = new System.Windows.Forms.TextBox();
            this.lblStaffName = new System.Windows.Forms.Label();
            this.grStaff.SuspendLayout();
            this.SuspendLayout();
            // 
            // grStaff
            // 
            this.grStaff.BackColor = System.Drawing.Color.Transparent;
            this.grStaff.Controls.Add(this.dtStaffBirth);
            this.grStaff.Controls.Add(this.lblStaffID);
            this.grStaff.Controls.Add(this.txtStaffId);
            this.grStaff.Controls.Add(this.txtStaffAddress);
            this.grStaff.Controls.Add(this.lblStaffINumber);
            this.grStaff.Controls.Add(this.txtStaffName);
            this.grStaff.Controls.Add(this.lblStaffBirth);
            this.grStaff.Controls.Add(this.txtStaffPhone);
            this.grStaff.Controls.Add(this.lblStaffPhone);
            this.grStaff.Controls.Add(this.lblStaffAddress);
            this.grStaff.Controls.Add(this.txtStaffINumber);
            this.grStaff.Controls.Add(this.lblStaffName);
            this.grStaff.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grStaff.Location = new System.Drawing.Point(5, 11);
            this.grStaff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grStaff.Name = "grStaff";
            this.grStaff.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grStaff.Size = new System.Drawing.Size(720, 145);
            this.grStaff.TabIndex = 24;
            this.grStaff.TabStop = false;
            this.grStaff.Text = "Thông tin nhân viên";
            // 
            // dtStaffBirth
            // 
            this.dtStaffBirth.CustomFormat = "dd/MM/yyyy";
            this.dtStaffBirth.Enabled = false;
            this.dtStaffBirth.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStaffBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStaffBirth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtStaffBirth.Location = new System.Drawing.Point(149, 108);
            this.dtStaffBirth.MaxDate = new System.DateTime(4000, 4, 22, 0, 0, 0, 0);
            this.dtStaffBirth.MinDate = new System.DateTime(1950, 12, 25, 0, 0, 0, 0);
            this.dtStaffBirth.Name = "dtStaffBirth";
            this.dtStaffBirth.Size = new System.Drawing.Size(191, 30);
            this.dtStaffBirth.TabIndex = 5;
            this.dtStaffBirth.Value = new System.DateTime(2021, 4, 22, 0, 0, 0, 0);
            // 
            // lblStaffID
            // 
            this.lblStaffID.AutoSize = true;
            this.lblStaffID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffID.Location = new System.Drawing.Point(24, 39);
            this.lblStaffID.Name = "lblStaffID";
            this.lblStaffID.Size = new System.Drawing.Size(76, 23);
            this.lblStaffID.TabIndex = 4;
            this.lblStaffID.Text = "Mã NV:";
            // 
            // txtStaffId
            // 
            this.txtStaffId.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffId.Location = new System.Drawing.Point(149, 32);
            this.txtStaffId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStaffId.Name = "txtStaffId";
            this.txtStaffId.ReadOnly = true;
            this.txtStaffId.Size = new System.Drawing.Size(191, 30);
            this.txtStaffId.TabIndex = 2;
            // 
            // txtStaffAddress
            // 
            this.txtStaffAddress.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffAddress.Location = new System.Drawing.Point(503, 36);
            this.txtStaffAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStaffAddress.Name = "txtStaffAddress";
            this.txtStaffAddress.ReadOnly = true;
            this.txtStaffAddress.Size = new System.Drawing.Size(191, 30);
            this.txtStaffAddress.TabIndex = 2;
            // 
            // lblStaffINumber
            // 
            this.lblStaffINumber.AutoSize = true;
            this.lblStaffINumber.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffINumber.Location = new System.Drawing.Point(408, 108);
            this.lblStaffINumber.Name = "lblStaffINumber";
            this.lblStaffINumber.Size = new System.Drawing.Size(77, 23);
            this.lblStaffINumber.TabIndex = 4;
            this.lblStaffINumber.Text = "CMND:";
            // 
            // txtStaffName
            // 
            this.txtStaffName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffName.Location = new System.Drawing.Point(149, 71);
            this.txtStaffName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.ReadOnly = true;
            this.txtStaffName.Size = new System.Drawing.Size(191, 30);
            this.txtStaffName.TabIndex = 2;
            // 
            // lblStaffBirth
            // 
            this.lblStaffBirth.AutoSize = true;
            this.lblStaffBirth.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffBirth.Location = new System.Drawing.Point(24, 108);
            this.lblStaffBirth.Name = "lblStaffBirth";
            this.lblStaffBirth.Size = new System.Drawing.Size(99, 23);
            this.lblStaffBirth.TabIndex = 4;
            this.lblStaffBirth.Text = "Ngày sinh:";
            // 
            // txtStaffPhone
            // 
            this.txtStaffPhone.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffPhone.Location = new System.Drawing.Point(503, 71);
            this.txtStaffPhone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStaffPhone.Name = "txtStaffPhone";
            this.txtStaffPhone.ReadOnly = true;
            this.txtStaffPhone.Size = new System.Drawing.Size(191, 30);
            this.txtStaffPhone.TabIndex = 2;
            // 
            // lblStaffPhone
            // 
            this.lblStaffPhone.AutoSize = true;
            this.lblStaffPhone.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffPhone.Location = new System.Drawing.Point(408, 75);
            this.lblStaffPhone.Name = "lblStaffPhone";
            this.lblStaffPhone.Size = new System.Drawing.Size(69, 23);
            this.lblStaffPhone.TabIndex = 4;
            this.lblStaffPhone.Text = "Số ĐT:";
            // 
            // lblStaffAddress
            // 
            this.lblStaffAddress.AutoSize = true;
            this.lblStaffAddress.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffAddress.Location = new System.Drawing.Point(408, 39);
            this.lblStaffAddress.Name = "lblStaffAddress";
            this.lblStaffAddress.Size = new System.Drawing.Size(75, 23);
            this.lblStaffAddress.TabIndex = 4;
            this.lblStaffAddress.Text = "Địa chỉ:";
            // 
            // txtStaffINumber
            // 
            this.txtStaffINumber.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffINumber.Location = new System.Drawing.Point(503, 108);
            this.txtStaffINumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStaffINumber.Name = "txtStaffINumber";
            this.txtStaffINumber.ReadOnly = true;
            this.txtStaffINumber.Size = new System.Drawing.Size(191, 30);
            this.txtStaffINumber.TabIndex = 2;
            // 
            // lblStaffName
            // 
            this.lblStaffName.AutoSize = true;
            this.lblStaffName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffName.Location = new System.Drawing.Point(24, 75);
            this.lblStaffName.Name = "lblStaffName";
            this.lblStaffName.Size = new System.Drawing.Size(73, 23);
            this.lblStaffName.TabIndex = 4;
            this.lblStaffName.Text = "Họ tên:";
            // 
            // frmStaffInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(723, 158);
            this.Controls.Add(this.grStaff);
            this.Name = "frmStaffInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông Tin Nhân Viên";
            this.grStaff.ResumeLayout(false);
            this.grStaff.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grStaff;
        private System.Windows.Forms.DateTimePicker dtStaffBirth;
        private System.Windows.Forms.Label lblStaffID;
        private System.Windows.Forms.TextBox txtStaffId;
        private System.Windows.Forms.TextBox txtStaffAddress;
        private System.Windows.Forms.Label lblStaffINumber;
        private System.Windows.Forms.TextBox txtStaffName;
        private System.Windows.Forms.Label lblStaffBirth;
        private System.Windows.Forms.TextBox txtStaffPhone;
        private System.Windows.Forms.Label lblStaffPhone;
        private System.Windows.Forms.Label lblStaffAddress;
        private System.Windows.Forms.TextBox txtStaffINumber;
        private System.Windows.Forms.Label lblStaffName;
    }
}