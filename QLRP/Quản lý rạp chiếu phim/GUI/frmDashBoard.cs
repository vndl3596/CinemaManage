using GUI.DTO;
using GUI.DAO;
using GUI.frmAdminUserControls;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmDashBoard : Form
    {
        public frmDashBoard(Account acc)
        {
            InitializeComponent();

            this.LoginAccount = acc;
        }

        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.Type); }
        }

        void ChangeAccount(int type)
        {
            if (loginAccount.Type == 2)
            {
                btnAdmin.Enabled = false;
                btnAdmin.Visible = false;
            }
            lblAccountInfo.Text += LoginAccount.UserName;   
            lbStaffName.Text += StaffDAO.SearchStaffByAccount(LoginAccount.UserName).Rows[0]["HoTen"];
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmAdminNewDesign frm = new frmAdminNewDesign();
            frm.Text = "Dữ liệu";
            frm.pnAdmin.Controls.Clear();
            DataUC dataUc = new DataUC();
            dataUc.Dock = DockStyle.Fill;
            frm.pnAdmin.Controls.Add(dataUc);
            frm.ShowDialog();
            this.Show();
        }

        private void btnSeller_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSeller frm = new frmSeller(this.loginAccount);
            frm.ShowDialog();
            this.Show();
        }

        private void btnAccountSettings_Click(object sender, EventArgs e)
        {
            frmAccountSettings frm = new frmAccountSettings(loginAccount);
            frm.ShowDialog();
            this.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            frmStaffInfo frm = new frmStaffInfo(loginAccount);
            frm.ShowDialog();
        }
    }
}