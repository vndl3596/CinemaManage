using GUI.DAO;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GUI.frmAdminUserControls.DataUserControl
{
    public partial class GenreUC : UserControl
    {
        BindingSource genreList = new BindingSource();

        public GenreUC()
        {
            InitializeComponent();
            LoadGenre();
        }

        void LoadGenre()
        {
            dtgvGenre.DataSource = genreList;
            LoadGenreList();
            AddGenreBinding();
        }
        void LoadGenreList()
        {
            genreList.DataSource = GenreDAO.GetGenre();
        }
        void AddGenreBinding()
        {
            txtGenreID.DataBindings.Add("Text", dtgvGenre.DataSource, "Mã thể loại", true, DataSourceUpdateMode.Never);
            txtGenreName.DataBindings.Add("Text", dtgvGenre.DataSource, "Tên thể loại", true, DataSourceUpdateMode.Never);
            txtGenreDesc.DataBindings.Add("Text", dtgvGenre.DataSource, "Mô tả", true, DataSourceUpdateMode.Never);
        }
        private void btnShowGenre_Click(object sender, EventArgs e)
        {
            LoadGenreList();
        }

        void InsertGenre(string id, string name, string desc)
        {
            if (GenreDAO.InsertGenre(id, name, desc))
            {
                MessageBox.Show("Thêm thể loại thành công");
            }
            else
            {
                MessageBox.Show("Thêm thể loại thất bại");
            }
        }
        private void btnInsertGenre_Click(object sender, EventArgs e)
        {
            if (txtGenreID.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("ID thể loại không được trống!!!");
                return;
            }
            if (txtGenreID.Text.Trim().Length < 3)
            {
                MessageBox.Show("Bạn phải nhập đúng định dạng mã thể loại!!! \nVD: TL01");
                return;
            }
            string idChar = txtGenreID.Text.Trim().ToUpper().Substring(0, 2);
            string idNum = txtGenreID.Text.Trim().ToUpper().Substring(2);
            if ((Regex.IsMatch(idChar, @"TL") == false) || (Regex.IsMatch(idNum, @"\D+") == true))
            {
                MessageBox.Show("Bạn phải nhập đúng định dạng mã thể loại!!! \nVD: TL01");
                return;
            }
            if (DAO.GenreDAO.SearchGenreByID(txtGenreID.Text.Trim()).Rows.Count > 0)
            {
                MessageBox.Show("Trùng ID thể loại khác!!!");
                return;
            }
            if (txtGenreName.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Tên thể loại không được trống!!!");
                return;
            }
            string GenreID = txtGenreID.Text.ToUpper();
            string GenreName = CustomerDAO.ChuanHoaHoTen(txtGenreName.Text);
            string GenreDesc = txtGenreDesc.Text;
            InsertGenre(GenreID, GenreName, GenreDesc);
            LoadGenreList();
        }

        void UpdateGenre(string id, string name, string desc)
        {
            if (GenreDAO.UpdateGenre(id, name, desc))
            {
                MessageBox.Show("Sửa thể loại thành công");
            }
            else
            {
                MessageBox.Show("Sửa thể loại thất bại");
            }
        }
        private void btnUpdateGenre_Click(object sender, EventArgs e)
        {
            if (txtGenreID.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Bạn phải nhập ID thể loại phim!!!");
                return;
            }
            if (DAO.GenreDAO.SearchGenreByID(txtGenreID.Text.Trim()).Rows.Count == 0)
            {
                MessageBox.Show("Thể loại(ID) cần sửa thông tin không có trong danh sách!!!");
                return;
            }
            if (txtGenreName.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Tên thể loại không được trống!!!");
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn sửa thông tin thể loại này?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            string GenreID = txtGenreID.Text;
            string GenreName = CustomerDAO.ChuanHoaHoTen(txtGenreName.Text);
            string GenreDesc = txtGenreDesc.Text;
            UpdateGenre(GenreID, GenreName, GenreDesc);
            LoadGenreList();
        }

        void DeleteGenre(string id)
        {
            if (GenreDAO.DeleteGenre(id))
            {
                MessageBox.Show("Xóa thể loại thành công");
            }
            else
            {
                MessageBox.Show("Xóa thể loại thất bại");
            }
        }
        private void btnDeleteGenre_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn xóa thông tin thể loại này?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            string GenreID = txtGenreID.Text;
            DeleteGenre(GenreID);
            LoadGenreList();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtGenreDesc.Text = "";
            txtGenreID.Text = "";
            txtGenreName.Text = "";
        }
    }
}
