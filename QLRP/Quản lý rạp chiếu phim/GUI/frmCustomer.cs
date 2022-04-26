using GUI.DAO;
using GUI.DTO;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmCustomer : Form
    {
        BindingSource customerList = new BindingSource();
        public frmCustomer()
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
            customerList.DataSource = CustomerDAO.GetListCustomerIDAndName();
        }
        void AddCustomerBinding()
        {
            txtCustomerID.DataBindings.Add("Text", dtgvCustomer.DataSource, "Mã khách hàng", true, DataSourceUpdateMode.Never);
            txtCustomerName.DataBindings.Add("Text", dtgvCustomer.DataSource, "Họ tên", true, DataSourceUpdateMode.Never);
        }

        public Customer customer;
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            DataTable data = CustomerDAO.GetCustomerMember(txtCustomerID.Text, txtCustomerName.Text);

            if (data.Rows.Count == 0)
            {
                MessageBox.Show("ID hoặc Họ tên của Khách Hàng không chính xác!\nVui lòng nhập lại thông tin.");
                return;
            }
            customer = new Customer(data.Rows[0]);

            DialogResult = DialogResult.OK;
        }
    }
}
