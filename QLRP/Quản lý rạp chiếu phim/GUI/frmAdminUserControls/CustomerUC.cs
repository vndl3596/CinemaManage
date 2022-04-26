using GUI.DAO;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GUI.frmAdminUserControls
{
    public partial class CustomerUC : UserControl
    {
        BindingSource customerList = new BindingSource();
        public CustomerUC()
        {
            InitializeComponent();
            LoadCustomer();
        }

        void LoadCustomer()
        {
            dtgvCustomer.DataSource = customerList;
            LoadCustomerList();
            AddCustomerBinding();
        }

        void LoadCustomerList()
        {
            customerList.DataSource = CustomerDAO.GetListCustomer();
            dTCusBirth.MaxDate = DateTime.Now;
        }
        private void btnShowCustomer_Click(object sender, EventArgs e)
        {
            LoadCustomerList();
        }

        void AddCustomerBinding()
        {
            txtCusID.DataBindings.Add("Text", dtgvCustomer.DataSource, "Mã khách hàng", true, DataSourceUpdateMode.Never);
            txtCusName.DataBindings.Add("Text", dtgvCustomer.DataSource, "Họ tên", true, DataSourceUpdateMode.Never);
            dTCusBirth.DataBindings.Add("Text", dtgvCustomer.DataSource, "Ngày sinh", true, DataSourceUpdateMode.Never);
            txtCusAddress.DataBindings.Add("Text", dtgvCustomer.DataSource, "Địa chỉ", true, DataSourceUpdateMode.Never);
            txtCusPhone.DataBindings.Add("Text", dtgvCustomer.DataSource, "Số điện thoại", true, DataSourceUpdateMode.Never);
            txtCusINumber.DataBindings.Add("Text", dtgvCustomer.DataSource, "CMND", true, DataSourceUpdateMode.Never);
            nudPoint.DataBindings.Add("Value", dtgvCustomer.DataSource, "Điểm tích lũy", true, DataSourceUpdateMode.Never);
        }

        void InsertCustomer(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, string cmnd)
        {
            if (CustomerDAO.InsertCustomer(id, hoTen, ngaySinh, diaChi, sdt, cmnd))
            {
                MessageBox.Show("Thêm khách hàng thành công");
            }
            else
            {
                MessageBox.Show("Thêm khách hàng thất bại");
            }
        }
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if( txtCusID.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("ID khách hàng không được trống!!!");
                return;
            }
            if (txtCusID.Text.Trim().Length < 3)
            {
                MessageBox.Show("Phải nhập đúng định dạng mã khách hàng!!! \nVD: KH01");
                return;
            }
            string idChar = txtCusID.Text.Trim().ToUpper().Substring(0, 2);
            string idNum = txtCusID.Text.Trim().ToUpper().Substring(2);
            if ((Regex.IsMatch(idChar, @"KH") == false) || (Regex.IsMatch(idNum, @"\D+") == true))
            {
                MessageBox.Show("Phải nhập đúng định dạng mã khách hàng!!! \nVD: KH01"); 
                return;
            }
            if (DAO.CustomerDAO.SearchCustomerByID(txtCusID.Text.Trim()).Rows.Count > 0)
            {
                MessageBox.Show("Trùng ID khách hàng khác!!!");
                return;
            }
            if (txtCusName.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Tên khách hàng không được trống!!!");
                return;
            }
            if (txtCusINumber.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("CMND khách hàng không được trống!!!");
                return;
            }
            if (Regex.IsMatch(txtCusINumber.Text.Trim(), @"\D+") == true)
            {
                MessageBox.Show("Sai định dạng CMND!!!");
                return;
            }
            if ((txtCusINumber.Text.Length != 9) && (txtCusINumber.Text.Length != 12))
            {
                MessageBox.Show("Sai định dạng CMND!!!");
                return;
            }
            if (DAO.CustomerDAO.SearchCustomerByINumber(txtCusINumber.Text.Trim()).Rows.Count > 0)
            {
                MessageBox.Show("Trùng CMND khách hàng khác!!!");
                return;
            }
            if (txtCusPhone.Text.Trim().Equals("") == false)
            { 
                string phoneFirst = txtCusPhone.Text.Trim().Substring(0, 1);
                string phoneLast = txtCusPhone.Text.Trim().Substring(1);
                if ((Regex.IsMatch(phoneFirst, @"0") == false) || (Regex.IsMatch(phoneLast, @"\D+") == true))
                {
                    MessageBox.Show("Sai định dạng số điện thoại!!!");
                    return;
                } 
            }
            if ((txtCusPhone.Text.Trim().Equals("") == false) && (txtCusPhone.Text.Length != 10))
            {
                MessageBox.Show("Sai định dạng số điện thoại!!!");
                return;
            }
            string cusID = txtCusID.Text.ToUpper();
            string cusName = txtCusName.Text;
            DateTime cusBirth = dTCusBirth.Value;
            string cusAddress = txtCusAddress.Text;
            string cusPhone = txtCusPhone.Text;
            string cusINumber = txtCusINumber.Text;
            if((DateTime.Now.Year - cusBirth.Year) < frmMinAge.t)
            {
                MessageBox.Show("Chưa đủ tuổi đăng ký!!!");
                return;
            }    
            InsertCustomer(cusID, cusName, cusBirth, cusAddress, cusPhone, cusINumber);
            LoadCustomerList();
        }

        void UpdateCustomer(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, string cmnd, int point)
        {
            if (CustomerDAO.UpdateCustomer(id, hoTen, ngaySinh, diaChi, sdt, cmnd, point))
            {
                MessageBox.Show("Sửa khách hàng thành công");
            }
            else
            {
                MessageBox.Show("Sửa khách hàng thất bại");
            }
        }
        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            if (txtCusID.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Bạn phải nhập ID khách hàng!!!");
                return;
            }
            if (DAO.CustomerDAO.SearchCustomerByID(txtCusID.Text.Trim()).Rows.Count == 0)
            {
                MessageBox.Show("Khách hàng(ID) cần sửa thông tin không có trong danh sách!!!");
                return;
            }
            if (txtCusName.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Tên khách hàng không được trống!!!");
                return;
            }
            if (txtCusINumber.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("CMND khách hàng không được trống!!!");
                return;
            }
            if (Regex.IsMatch(txtCusINumber.Text.Trim(), @"\D+") == true)
            {
                MessageBox.Show("Sai định dạng CMND!!!");
                return;
            }
            if ((txtCusINumber.Text.Length != 9) && (txtCusINumber.Text.Length != 12))
            {
                MessageBox.Show("Sai định dạng CMND!!!");
                return;
            }
            if ((DAO.CustomerDAO.SearchCustomerIDNumberByID(txtCusID.Text.Trim()).Rows[0]["CMND"].Equals(txtCusINumber.Text.Trim()) == false) && (DAO.CustomerDAO.SearchCustomerByINumber(txtCusINumber.Text.Trim()).Rows.Count > 0))
            {
                MessageBox.Show("Trùng CMND khách hàng khác!!!");
                return;
            }
            if (txtCusPhone.Text.Trim().Equals("") == false)
            {
                string phoneFirst = txtCusPhone.Text.Trim().Substring(0, 1);
                string phoneLast = txtCusPhone.Text.Trim().Substring(1);
                if ((Regex.IsMatch(phoneFirst, @"0") == false) || (Regex.IsMatch(phoneLast, @"\D+") == true))
                {
                    MessageBox.Show("Sai định dạng số điện thoại!!!");
                    return;
                }
            }
            if ((txtCusPhone.Text.Trim().Equals("") == false) && (txtCusPhone.Text.Length != 10))
            {
                MessageBox.Show("Sai định dạng số điện thoại!!!");
                return;
            }
            if ((DateTime.Now.Year - dTCusBirth.Value.Year) < frmMinAge.t)
            {
                MessageBox.Show("Chưa đủ tuổi đăng ký!!!");
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn sửa thông tin khách hàng này?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            string cusID = txtCusID.Text;
            string cusName = txtCusName.Text;
            DateTime cusBirth = dTCusBirth.Value;
            string cusAddress = txtCusAddress.Text;
            string cusPhone = txtCusPhone.Text;
            string cusINumber = txtCusINumber.Text;
            int cusPoint = (int)nudPoint.Value;
            UpdateCustomer(cusID, cusName, cusBirth, cusAddress, cusPhone, cusINumber, cusPoint);
            LoadCustomerList();
        }

        void DeleteCustomer(string id)
        {
            if (CustomerDAO.DeleteCustomer(id))
            {
                MessageBox.Show("Xóa khách hàng thành công");
            }
            else
            {
                MessageBox.Show("Xóa khách hàng thất bại");
            }
        }
        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn xóa thông tin khách hàng này?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            string cusID = txtCusID.Text;
            DeleteCustomer(cusID);
            LoadCustomerList();
        }

        private void btnSearchCus_Click(object sender, EventArgs e)
        {
            string cusName = txtSearchCus.Text;
            customerList.DataSource = CustomerDAO.SearchCustomerByName(cusName);
        }

		private void txtSearchCus_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btnSearchCus.PerformClick();
				e.SuppressKeyPress = true;//Tắt tiếng *ting của windows
			}
		}

        private void btnSuaTuoi_Click(object sender, EventArgs e)
        {
            frmMinAge frm3 = new frmMinAge();
            if (frm3.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new frmMinAge());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCusAddress.Text = "";
            txtCusID.Text = "";
            txtCusINumber.Text = "";
            txtCusName.Text = "";
            txtCusPhone.Text = "";
            txtSearchCus.Text = "";
            nudPoint.Value = 0;
        }
    }
}
