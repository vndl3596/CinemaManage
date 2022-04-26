﻿namespace GUI.frmAdminUserControls.DataUserControl
{
    partial class ScreenTypeUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnShowScreenType = new System.Windows.Forms.Button();
            this.btnUpdateScreenType = new System.Windows.Forms.Button();
            this.btnDeleteScreenType = new System.Windows.Forms.Button();
            this.btnInsertScreenType = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel20 = new System.Windows.Forms.Panel();
            this.txtScreenTypeName = new System.Windows.Forms.TextBox();
            this.lblScreenTypeName = new System.Windows.Forms.Label();
            this.panel21 = new System.Windows.Forms.Panel();
            this.txtScreenTypeID = new System.Windows.Forms.TextBox();
            this.lblScreenTypeID = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtgvScreenType = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel21.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvScreenType)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnShowScreenType);
            this.panel1.Controls.Add(this.btnUpdateScreenType);
            this.panel1.Controls.Add(this.btnDeleteScreenType);
            this.panel1.Controls.Add(this.btnInsertScreenType);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1233, 66);
            this.panel1.TabIndex = 2;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(681, 4);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(98, 57);
            this.btnClear.TabIndex = 26;
            this.btnClear.Text = "Làm Sạch";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnShowScreenType
            // 
            this.btnShowScreenType.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnShowScreenType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnShowScreenType.Location = new System.Drawing.Point(574, 4);
            this.btnShowScreenType.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowScreenType.Name = "btnShowScreenType";
            this.btnShowScreenType.Size = new System.Drawing.Size(100, 57);
            this.btnShowScreenType.TabIndex = 7;
            this.btnShowScreenType.Text = "Xem";
            this.btnShowScreenType.UseVisualStyleBackColor = false;
            this.btnShowScreenType.Click += new System.EventHandler(this.btnShowScreenType_Click);
            // 
            // btnUpdateScreenType
            // 
            this.btnUpdateScreenType.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUpdateScreenType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpdateScreenType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnUpdateScreenType.Location = new System.Drawing.Point(112, 4);
            this.btnUpdateScreenType.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateScreenType.Name = "btnUpdateScreenType";
            this.btnUpdateScreenType.Size = new System.Drawing.Size(100, 57);
            this.btnUpdateScreenType.TabIndex = 6;
            this.btnUpdateScreenType.Text = "Sửa";
            this.btnUpdateScreenType.UseVisualStyleBackColor = false;
            this.btnUpdateScreenType.Click += new System.EventHandler(this.btnUpdateScreenType_Click);
            // 
            // btnDeleteScreenType
            // 
            this.btnDeleteScreenType.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDeleteScreenType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeleteScreenType.ForeColor = System.Drawing.Color.Red;
            this.btnDeleteScreenType.Location = new System.Drawing.Point(220, 5);
            this.btnDeleteScreenType.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteScreenType.Name = "btnDeleteScreenType";
            this.btnDeleteScreenType.Size = new System.Drawing.Size(100, 57);
            this.btnDeleteScreenType.TabIndex = 5;
            this.btnDeleteScreenType.Text = "Xóa";
            this.btnDeleteScreenType.UseVisualStyleBackColor = false;
            this.btnDeleteScreenType.Click += new System.EventHandler(this.btnDeleteScreenType_Click);
            // 
            // btnInsertScreenType
            // 
            this.btnInsertScreenType.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnInsertScreenType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnInsertScreenType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnInsertScreenType.Location = new System.Drawing.Point(4, 5);
            this.btnInsertScreenType.Margin = new System.Windows.Forms.Padding(4);
            this.btnInsertScreenType.Name = "btnInsertScreenType";
            this.btnInsertScreenType.Size = new System.Drawing.Size(100, 57);
            this.btnInsertScreenType.TabIndex = 4;
            this.btnInsertScreenType.Text = "Thêm";
            this.btnInsertScreenType.UseVisualStyleBackColor = false;
            this.btnInsertScreenType.Click += new System.EventHandler(this.btnInsertScreenType_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1233, 572);
            this.panel2.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightCyan;
            this.panel4.Controls.Add(this.panel20);
            this.panel4.Controls.Add(this.panel21);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(779, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(454, 572);
            this.panel4.TabIndex = 1;
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.txtScreenTypeName);
            this.panel20.Controls.Add(this.lblScreenTypeName);
            this.panel20.Location = new System.Drawing.Point(24, 65);
            this.panel20.Margin = new System.Windows.Forms.Padding(4);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(391, 54);
            this.panel20.TabIndex = 4;
            // 
            // txtScreenTypeName
            // 
            this.txtScreenTypeName.Location = new System.Drawing.Point(190, 14);
            this.txtScreenTypeName.Margin = new System.Windows.Forms.Padding(4);
            this.txtScreenTypeName.Name = "txtScreenTypeName";
            this.txtScreenTypeName.Size = new System.Drawing.Size(192, 22);
            this.txtScreenTypeName.TabIndex = 1;
            // 
            // lblScreenTypeName
            // 
            this.lblScreenTypeName.AutoSize = true;
            this.lblScreenTypeName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblScreenTypeName.Location = new System.Drawing.Point(4, 11);
            this.lblScreenTypeName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScreenTypeName.Name = "lblScreenTypeName";
            this.lblScreenTypeName.Size = new System.Drawing.Size(147, 24);
            this.lblScreenTypeName.TabIndex = 0;
            this.lblScreenTypeName.Text = "Tên màn hình:";
            // 
            // panel21
            // 
            this.panel21.Controls.Add(this.txtScreenTypeID);
            this.panel21.Controls.Add(this.lblScreenTypeID);
            this.panel21.Location = new System.Drawing.Point(24, 4);
            this.panel21.Margin = new System.Windows.Forms.Padding(4);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(391, 54);
            this.panel21.TabIndex = 3;
            // 
            // txtScreenTypeID
            // 
            this.txtScreenTypeID.Location = new System.Drawing.Point(190, 14);
            this.txtScreenTypeID.Margin = new System.Windows.Forms.Padding(4);
            this.txtScreenTypeID.Name = "txtScreenTypeID";
            this.txtScreenTypeID.Size = new System.Drawing.Size(192, 22);
            this.txtScreenTypeID.TabIndex = 1;
            // 
            // lblScreenTypeID
            // 
            this.lblScreenTypeID.AutoSize = true;
            this.lblScreenTypeID.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblScreenTypeID.Location = new System.Drawing.Point(4, 11);
            this.lblScreenTypeID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScreenTypeID.Name = "lblScreenTypeID";
            this.lblScreenTypeID.Size = new System.Drawing.Size(178, 24);
            this.lblScreenTypeID.TabIndex = 0;
            this.lblScreenTypeID.Text = "Mã loại màn hình:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtgvScreenType);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(779, 572);
            this.panel3.TabIndex = 0;
            // 
            // dtgvScreenType
            // 
            this.dtgvScreenType.AllowUserToAddRows = false;
            this.dtgvScreenType.AllowUserToDeleteRows = false;
            this.dtgvScreenType.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvScreenType.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dtgvScreenType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvScreenType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvScreenType.Location = new System.Drawing.Point(0, 0);
            this.dtgvScreenType.Margin = new System.Windows.Forms.Padding(4);
            this.dtgvScreenType.Name = "dtgvScreenType";
            this.dtgvScreenType.ReadOnly = true;
            this.dtgvScreenType.RowHeadersWidth = 51;
            this.dtgvScreenType.Size = new System.Drawing.Size(779, 572);
            this.dtgvScreenType.TabIndex = 1;
            // 
            // ScreenTypeUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ScreenTypeUC";
            this.Size = new System.Drawing.Size(1233, 638);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel20.ResumeLayout(false);
            this.panel20.PerformLayout();
            this.panel21.ResumeLayout(false);
            this.panel21.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvScreenType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnShowScreenType;
        private System.Windows.Forms.Button btnUpdateScreenType;
        private System.Windows.Forms.Button btnDeleteScreenType;
        private System.Windows.Forms.Button btnInsertScreenType;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dtgvScreenType;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.TextBox txtScreenTypeName;
        private System.Windows.Forms.Label lblScreenTypeName;
        private System.Windows.Forms.Panel panel21;
        private System.Windows.Forms.TextBox txtScreenTypeID;
        private System.Windows.Forms.Label lblScreenTypeID;
        private System.Windows.Forms.Button btnClear;
    }
}
