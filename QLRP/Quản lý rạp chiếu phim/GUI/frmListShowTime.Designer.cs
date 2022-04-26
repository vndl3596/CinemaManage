
namespace GUI
{
    partial class frmListShowTime
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListShowTime));
            this.dtgvShowTime = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvShowTime)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvShowTime
            // 
            this.dtgvShowTime.AllowUserToAddRows = false;
            this.dtgvShowTime.AllowUserToDeleteRows = false;
            this.dtgvShowTime.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvShowTime.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtgvShowTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvShowTime.Location = new System.Drawing.Point(1, 1);
            this.dtgvShowTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtgvShowTime.Name = "dtgvShowTime";
            this.dtgvShowTime.RowHeadersWidth = 51;
            this.dtgvShowTime.RowTemplate.Height = 24;
            this.dtgvShowTime.Size = new System.Drawing.Size(805, 188);
            this.dtgvShowTime.TabIndex = 14;
            // 
            // frmListShowTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(809, 189);
            this.Controls.Add(this.dtgvShowTime);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmListShowTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh Sách Lịch Chiếu";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvShowTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvShowTime;
    }
}