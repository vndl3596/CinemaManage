using GUI.DAO;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GUI.frmAdminUserControls
{
    public partial class StaffUC : UserControl
    {
        BindingSource staffList = new BindingSource();

        public StaffUC()
        {
            InitializeComponent();
            LoadStaff();
        }
        void LoadStaff()
        {
            dtgvStaff.DataSource = staffList;
            LoadStaffList();
            AddStaffBinding();
        }

        void LoadStaffList()
        {
            staffList.DataSource = StaffDAO.GetListStaff();
            dtStaffBirth.MaxDate = DateTime.Now;
        }

        private void btnShowStaff_Click(object sender, EventArgs e)
        {
            LoadStaffList();
        }
        void AddStaffBinding()
        {
            txtStaffId.DataBindings.Add("Text", dtgvStaff.DataSource, "Mã nhân viên", true, DataSourceUpdateMode.Never);
            txtStaffName.DataBindings.Add("Text", dtgvStaff.DataSource, "Họ tên", true, DataSourceUpdateMode.Never);
            dtStaffBirth.DataBindings.Add("Text", dtgvStaff.DataSource, "Ngày sinh", true, DataSourceUpdateMode.Never);
            txtStaffAddress.DataBindings.Add("Text", dtgvStaff.DataSource, "Địa chỉ", true, DataSourceUpdateMode.Never);
            txtStaffPhone.DataBindings.Add("Text", dtgvStaff.DataSource, "Số điện thoại", true, DataSourceUpdateMode.Never);
            txtStaffINumber.DataBindings.Add("Text", dtgvStaff.DataSource, "CMND", true, DataSourceUpdateMode.Never);

        }

        void AddStaff(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, string cmnd)
        {
            if (StaffDAO.InsertStaff(id, hoTen, ngaySinh, diaChi, sdt, cmnd))
            {
                MessageBox.Show("Thêm nhân viên thành công");
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thất bại");
            }
        }
        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            if(txtStaffId.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("ID nhân viên không được trống!!!");
                return;
            }
            if (txtStaffId.Text.Trim().Length < 3)
            {
                MessageBox.Show("Phải nhập đúng định dạng mã nhân viên!!! \nVD: NV01");
                return;
            }
            string idChar = txtStaffId.Text.Trim().ToUpper().Substring(0, 2);
            string idNum = txtStaffId.Text.Trim().ToUpper().Substring(2);
            if ((Regex.IsMatch(idChar, @"NV") == false) || (Regex.IsMatch(idNum, @"\D+") == true))
            {
                MessageBox.Show("Phải nhập đúng định dạng mã nhân viên!!! \nVD: NV01");
                return;
            }
            if (DAO.StaffDAO.SearchStaffByID(txtStaffId.Text.Trim()).Rows.Count > 0)
            {
                MessageBox.Show("Trùng ID nhân viên khác!!!");
                return;
            }
            if (txtStaffName.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Tên nhân viên không được trống!!!");
                return;
            }
            if (txtStaffINumber.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("CMND nhân viên không được trống!!!");
                return;
            }
            if (Regex.IsMatch(txtStaffINumber.Text.Trim(), @"\D+") == true)
            {
                MessageBox.Show("Sai định dạng CMND!!!");
                return;
            }
            if ((txtStaffINumber.Text.Length != 9) && (txtStaffINumber.Text.Length != 12))
            {
                MessageBox.Show("Sai định dạng CMND!!!");
                return;
            }
            if (DAO.StaffDAO.SearchStaffByINumber(txtStaffINumber.Text.Trim()).Rows.Count > 0)
            {
                MessageBox.Show("Trùng CMND nhân viên khác!!!");
                return;
            }
            if (txtStaffPhone.Text.Trim().Equals("") == false)
            {
                string phoneFirst = txtStaffPhone.Text.Trim().Substring(0, 1);
                string phoneLast = txtStaffPhone.Text.Trim().Substring(1);
                if ((Regex.IsMatch(phoneFirst, @"0") == false) || (Regex.IsMatch(phoneFirst, @"\D+") == true))
                {
                    MessageBox.Show("Sai định dạng số điện thoại!!!");
                    return;
                }
            }
            if ((txtStaffPhone.Text.Trim().Equals("") == false) && (txtStaffPhone.Text.Length != 10))
            {
                MessageBox.Show("Sai định dạng số điện thoại!!!");
                return;
            }
            string staffId = txtStaffId.Text.ToUpper();
            string staffName = txtStaffName.Text;
            DateTime staffBirth = dtStaffBirth.Value;
            string staffAddress = txtStaffAddress.Text;
            string staffPhone = txtStaffPhone.Text;
            string staffINumber = txtStaffINumber.Text;
            AddStaff(staffId, staffName, staffBirth, staffAddress, staffPhone, staffINumber);
            LoadStaffList();
        }

        void UpdateStaff(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, string cmnd)
        {
            if (StaffDAO.UpdateStaff(id, hoTen, ngaySinh, diaChi, sdt, cmnd))
            {
                MessageBox.Show("Sửa nhân viên thành công");
            }
            else
            {
                MessageBox.Show("Sửa nhân viên thất bại");
            }
        }
        private void btnUpdateStaff_Click(object sender, EventArgs e)
        {
            if (txtStaffId.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Bạn phải nhập ID nhân viên!!!");
                return;
            }
            if (DAO.StaffDAO.SearchStaffByID(txtStaffId.Text.Trim()).Rows.Count == 0)
            {
                MessageBox.Show("Nhân viên(ID) cần sửa thông tin không có trong danh sách!!!");
                return;
            }
            if (txtStaffName.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Tên nhân viên không được trống!!!");
                return;
            }
            if (txtStaffINumber.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("CMND nhân viên không được trống!!!");
                return;
            }
            if (Regex.IsMatch(txtStaffINumber.Text.Trim(), @"\D+") == true)
            {
                MessageBox.Show("Sai định dạng CMND!!!");
                return;
            }
            if ((txtStaffINumber.Text.Length != 9) && (txtStaffINumber.Text.Length != 12))
            {
                MessageBox.Show("Sai định dạng CMND!!!");
                return;
            }
            if ((DAO.StaffDAO.SearchStaffIDNumberByID(txtStaffId.Text.Trim()).Rows[0]["CMND"].Equals(txtStaffINumber.Text.Trim()) == false) && (DAO.StaffDAO.SearchStaffByINumber(txtStaffINumber.Text.Trim()).Rows.Count > 0))
            {
                MessageBox.Show("Trùng CMND nhân viên khác!!!");
                return;
            }
            if (txtStaffPhone.Text.Trim().Equals("") == false)
            {
                string phoneFirst = txtStaffPhone.Text.Trim().Substring(0, 1);
                string phoneLast = txtStaffPhone.Text.Trim().Substring(1);
                if ((Regex.IsMatch(phoneFirst, @"0") == false) || (Regex.IsMatch(phoneFirst, @"\D+") == true))
                {
                    MessageBox.Show("Sai định dạng số điện thoại!!!");
                    return;
                }
            }
            if ((txtStaffPhone.Text.Trim().Equals("") == false) && (txtStaffPhone.Text.Length != 10))
            {
                MessageBox.Show("Sai định dạng số điện thoại!!!");
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn sửa thông tin nhân viên này?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            string staffId = txtStaffId.Text;
            string staffName = txtStaffName.Text;
            DateTime staffBirth = dtStaffBirth.Value;
            string staffAddress = txtStaffAddress.Text;
            string staffPhone = txtStaffPhone.Text;
            string staffINumber = txtStaffINumber.Text;
            UpdateStaff(staffId, staffName, staffBirth, staffAddress, staffPhone, staffINumber);
            LoadStaffList();
        }

        void DeleteStaff(string id)
        {
            if (StaffDAO.DeleteStaff(id))
            {
                MessageBox.Show("Xóa nhân viên thành công");
            }
            else
            {
                MessageBox.Show("Xóa nhân viên thất bại");
            }
        }
        private void btnDeleteStaff_Click(object sender, EventArgs e)
        {
            if(AccountDAO.SearchAccountByID(txtStaffId.Text.Trim()).Rows.Count > 0)
            {
                MessageBox.Show("Xóa tài khoản của nhân viên này trước!!!");
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn xóa thông tin nhân viên này?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            string staffId = txtStaffId.Text;
            DeleteStaff(staffId);
            LoadStaffList();
        }

        private void btnSearchStaff_Click(object sender, EventArgs e)
        {
            string staffName = txtSearchStaff.Text;
            DataTable staffSearchList = StaffDAO.SearchStaffByName(staffName);
            staffList.DataSource = staffSearchList;
        }

        private void txtSearchStaff_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchStaff.PerformClick();
                e.SuppressKeyPress = true;//Tắt tiếng *ting của windows
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearchStaff.Text = "";
            txtStaffAddress.Text = "";
            txtStaffId.Text = "";
            txtStaffINumber.Text = "";
            txtStaffName.Text = "";
            txtStaffPhone.Text = "";
        }
    }
}
