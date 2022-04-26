using GUI.DAO;
using GUI.DTO;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GUI.frmAdminUserControls
{
    public partial class AccountUC : UserControl
    {
        BindingSource accountList = new BindingSource();

        public AccountUC()
        {
            InitializeComponent();
            LoadAccount();
        }

        void LoadAccount()
        {
            dtgvAccount.DataSource = accountList;
            LoadAccountList();
            AddAccountBinding();
        }
        void LoadAccountList()
        {
            accountList.DataSource = AccountDAO.GetAccountList();
        }
        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            LoadAccountList();
        }

        void AddAccountBinding()
        {
            txtUsername.DataBindings.Add("Text", dtgvAccount.DataSource, "Username", true, DataSourceUpdateMode.Never);
            //nudAccountType.DataBindings.Add("Value", dtgvAccount.DataSource, "Loại tài khoản", true, DataSourceUpdateMode.Never);
            LoadStaffIntoComboBox(cboStaffID_Account);
        }
        void LoadStaffIntoComboBox(ComboBox cbo)
        {
            cbo.DataSource = StaffDAO.GetStaff();
            cbo.DisplayMember = "ID";
            cbo.ValueMember = "ID";
        }
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (AccountDAO.GetAccountList().Rows.Count == 0)
                return;
            string staffID = (string)dtgvAccount.SelectedCells[0].OwningRow.Cells["Mã nhân viên"].Value;
            Staff staff = StaffDAO.GetStaffByID(staffID);//The staff that we're currently selecting

            if (staff == null)
                //The case that nothing on dtgv - no result after searched
                return;

            cboStaffID_Account.SelectedItem = staff;

            int index = -1;
            int i = 0;
            foreach (Staff item in cboStaffID_Account.Items)
            {
                if (item.ID == staff.ID)
                {
                    index = i;
                    break;
                }
                i++;
            }
            cboStaffID_Account.SelectedIndex = index;

            if (AccountDAO.SearchAccountByUserName(txtUsername.Text.Trim()).Rows.Count == 0)
            {
                return;
            }    
            if ((int)AccountDAO.SearchAccountByUserName(txtUsername.Text.Trim()).Rows[0]["LoaiTK"] == 1)
            {
                cboAccountType.SelectedIndex = 0;
            }
            if ((int)AccountDAO.SearchAccountByUserName(txtUsername.Text.Trim()).Rows[0]["LoaiTK"] == 2)
            {
                cboAccountType.SelectedIndex = 1;
            }
        }
        private void cboStaffID_Account_SelectedIndexChanged(object sender, EventArgs e)
        {
            Staff staff = cboStaffID_Account.SelectedItem as Staff;
            if (staff == null)
                return;
            txtStaffName_Account.Text = staff.Name;
        }

        void InsertAccount(string username, int accountType, string idStaff)
        {
            if (AccountDAO.InsertAccount(username, accountType, idStaff))
            {
                MessageBox.Show("Thêm tài khoản thành công, mật khẩu mặc định : 1");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }
        }
        private void btnInsertAccount_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Username không được trống!!!");
                return;
            }
            if (Regex.IsMatch(txtUsername.Text.ToLower(), @"\W+") == true)
            {
                MessageBox.Show("UserName không được chứa kí tự đặc biệt!!!");
                return;
            }
            if (DAO.AccountDAO.SearchAccountByUserName(txtUsername.Text.Trim()).Rows.Count > 0)
            {
                MessageBox.Show("Trùng Username của nhân viên khác!!!");
                return;
            }
            for (int i = 0; i < AccountDAO.SearchAccountByID(cboStaffID_Account.Text).Rows.Count; i++)
            {
                int checkAccountType = 0;
                if (cboAccountType.Text.Equals("Quản lý") == true)
                {
                    checkAccountType = 1;
                }
                if (cboAccountType.Text.Equals("Bán vé") == true)
                {
                    checkAccountType = 2;
                }
                if (checkAccountType == (int)AccountDAO.SearchAccountByID(cboStaffID_Account.Text).Rows[i]["LoaiTK"])
                {
                    MessageBox.Show("Nhân viên đã có tài khoản với chức năng này!!!");
                    return;
                }    
            }
            string username = txtUsername.Text;
            int accountType;
            if (cboAccountType.Text.Equals("Quản lý") == true)
            {
                accountType = 1;
            }
            else
            {
                accountType = 2;
            }
            string staffID = cboStaffID_Account.SelectedValue.ToString();
            InsertAccount(username, accountType, staffID);
            LoadAccountList();
        }
        void DeleteAccount(string username)
        {
            if (AccountDAO.DeleteAccount(username))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }
        }
        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn xóa tài khoản này?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            if (txtUsername.Text.Trim().Equals("admin") == true)
            {
                MessageBox.Show("Không thể xóa tài khoản quản trị gốc!!!");
                return;
            }
            string username = txtUsername.Text;
            DeleteAccount(username);
            LoadAccountList();
        }

        void ResetPassword(string username)
        {
            if (AccountDAO.ResetPassword(username))
            {
                MessageBox.Show("Reset mật khẩu thành công, mật khẩu mặc định : 1");
            }
            else
            {
                MessageBox.Show("Reset mật khẩu thất bại");
            }
        }
        private void btnResetPass_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            ResetPassword(username);
            LoadAccountList();
        }

        private void btnSearchAccount_Click(object sender, EventArgs e)
        {
            string staffName = txtSearchAccount.Text;
            if(AccountDAO.SearchAccountByStaffName(staffName).Rows.Count != 0)
            accountList.DataSource = AccountDAO.SearchAccountByStaffName(staffName);
        }

		private void txtSearchAccount_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btnSearchAccount.PerformClick();
				e.SuppressKeyPress = true;//Tắt tiếng *ting của windows
			}
		}

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearchAccount.Text = "";
            txtUsername.Text = "";
            cboStaffID_Account.SelectedIndex = 0;
            //nudAccountType.Value = 1;
            cboAccountType.SelectedIndex = 0;
        }
    }
}
