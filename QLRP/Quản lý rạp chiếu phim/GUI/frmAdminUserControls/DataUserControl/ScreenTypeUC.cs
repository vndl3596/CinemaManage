using GUI.DAO;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GUI.frmAdminUserControls.DataUserControl
{
    public partial class ScreenTypeUC : UserControl
    {
        BindingSource screenTypeList = new BindingSource();
        public ScreenTypeUC()
        {
            InitializeComponent();
            LoadScreenType();
        }
        void LoadScreenType()
        {
            dtgvScreenType.DataSource = screenTypeList;
            LoadScreenTypeList();
            AddScreenTypeBinding();
        }
        void LoadScreenTypeList()
        {
            screenTypeList.DataSource = ScreenTypeDAO.GetScreenType();
        }
        void AddScreenTypeBinding()
        {
            txtScreenTypeID.DataBindings.Add("Text", dtgvScreenType.DataSource, "Mã loại màn hình", true, DataSourceUpdateMode.Never);
            txtScreenTypeName.DataBindings.Add("Text", dtgvScreenType.DataSource, "Tên màn hình", true, DataSourceUpdateMode.Never);
        }
        private void btnShowScreenType_Click(object sender, EventArgs e)
        {
            LoadScreenTypeList();
        }

        void InsertScreenType(string id, string name)
        {
            if (ScreenTypeDAO.InsertScreenType(id, name))
            {
                MessageBox.Show("Thêm loại màn hình thành công");
            }
            else
            {
                MessageBox.Show("Thêm loại màn hình thất bại");
            }
        }
        private void btnInsertScreenType_Click(object sender, EventArgs e)
        {
            if (txtScreenTypeID.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("ID màn hình không được trống!!!");
                return;
            }
            if (txtScreenTypeID.Text.Trim().Length < 3)
            {
                MessageBox.Show("Phải nhập đúng định dạng mã màn hình!!! \nVD: MH01");
                return;
            }
            string idChar = txtScreenTypeID.Text.Trim().ToUpper().Substring(0, 2);
            string idNum = txtScreenTypeID.Text.Trim().ToUpper().Substring(2);
            if ((Regex.IsMatch(idChar, @"MH") == false) || (Regex.IsMatch(idNum, @"\D+") == true))
            {
                MessageBox.Show("Phải nhập đúng định dạng mã màn hình!!! \nVD: MH01");
                return;
            }
            if (DAO.ScreenTypeDAO.SearchScreenTypeByID(txtScreenTypeID.Text.Trim()).Rows.Count > 0)
            {
                MessageBox.Show("Trùng ID loại màn hình khác!!!");
                return;
            }
            if (txtScreenTypeName.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Tên màn hình không được trống!!!");
                return;
            }
            string screenTypeID = txtScreenTypeID.Text.ToUpper();
            string screenTypeName = txtScreenTypeName.Text;
            InsertScreenType(screenTypeID, screenTypeName);
            LoadScreenTypeList();
        }

        void UpdateScreenType(string id, string name)
        {
            if (ScreenTypeDAO.UpdateScreenType(id, name))
            {
                MessageBox.Show("Sửa loại màn hình thành công");
            }
            else
            {
                MessageBox.Show("Sửa loại màn hình thất bại");
            }
        }
        private void btnUpdateScreenType_Click(object sender, EventArgs e)
        {
            if (txtScreenTypeID.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Bạn phải nhập ID màn hình!!!");
                return;
            }
            if (txtScreenTypeName.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Tên màn hình không được trống!!!");
                return;
            }
            if (DAO.ScreenTypeDAO.SearchScreenTypeByID(txtScreenTypeID.Text.Trim()).Rows.Count == 0)
            {
                MessageBox.Show("Màn hình(ID) cần sửa thông tin không có trong danh sách");
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn sửa thông tin màn hình này?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            string screenTypeID = txtScreenTypeID.Text;
            string screenTypeName = txtScreenTypeName.Text;
            UpdateScreenType(screenTypeID, screenTypeName);
            LoadScreenTypeList();
        }

        void DeleteScreenType(string id)
        {
            if (ScreenTypeDAO.DeleteScreenType(id))
            {
                MessageBox.Show("Xóa loại màn hình thành công");
            }
            else
            {
                MessageBox.Show("Xóa loại màn hình thất bại");
            }
        }
        private void btnDeleteScreenType_Click(object sender, EventArgs e)
        {
            if (ScreenTypeDAO.SearchScreenTypeUsingInCinema(txtScreenTypeID.Text.Trim()).Rows.Count > 0)
            {
                MessageBox.Show("Xóa phòng chiếu có chứa loại màn hình này trước!!!");
                return;
            }
            if (ScreenTypeDAO.SearchScreenTypeUsingInFormatMovie(txtScreenTypeID.Text.Trim()).Rows.Count > 0)
            {
                MessageBox.Show("Xóa định dạng phim có chứa loại màn hình này trước!!!");
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn xóa thông tin màn hình này?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }           
            string screenTypeID = txtScreenTypeID.Text;
            DeleteScreenType(screenTypeID);
            LoadScreenTypeList();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtScreenTypeID.Text = "";
            txtScreenTypeName.Text = "";
        }
    }
}
