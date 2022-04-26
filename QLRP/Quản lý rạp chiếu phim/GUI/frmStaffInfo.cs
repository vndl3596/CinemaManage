using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.DTO;
using GUI.DAO;

namespace GUI
{
    public partial class frmStaffInfo : Form
    {
        public frmStaffInfo(Account acc)
        {
            InitializeComponent();
            LoadStaff(acc);
        }
        public void LoadStaff(Account acc)
        {
            txtStaffId.Text = StaffDAO.SearchStaffByID(acc.StaffID).Rows[0]["id"].ToString();
            txtStaffName.Text = StaffDAO.SearchStaffByID(acc.StaffID).Rows[0]["HoTen"].ToString();
            txtStaffPhone.Text = StaffDAO.SearchStaffByID(acc.StaffID).Rows[0]["SDT"].ToString();
            txtStaffAddress.Text = StaffDAO.SearchStaffByID(acc.StaffID).Rows[0]["DiaChi"].ToString();
            txtStaffINumber.Text = StaffDAO.SearchStaffByID(acc.StaffID).Rows[0]["CMND"].ToString();
            dtStaffBirth.Value = (DateTime)StaffDAO.SearchStaffByID(acc.StaffID).Rows[0]["NgaySinh"];
        }
    }
}
