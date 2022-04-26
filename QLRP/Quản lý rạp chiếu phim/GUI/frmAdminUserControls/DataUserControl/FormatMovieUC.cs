using GUI.DAO;
using GUI.DTO;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GUI.frmAdminUserControls.DataUserControl
{
    public partial class FormatMovieUC : UserControl
    {
        BindingSource formatList = new BindingSource();

        public FormatMovieUC()
        {
            InitializeComponent();
            LoadFormatMovie();
        }

        void LoadFormatMovie()
        {
            dtgvFormat.DataSource = formatList;
            LoadFormatMovieList();
            LoadMovieIDIntoCombobox(cboFormat_MovieID);
            LoadScreenIDIntoCombobox(cboFormat_ScreenID);
            AddFormatBinding();
        }
        void LoadMovieIDIntoCombobox(ComboBox comboBox)
        {
            comboBox.DataSource = MovieDAO.GetListMovie();
            comboBox.DisplayMember = "ID";
            comboBox.ValueMember = "ID";
        }
        private void cboFormat_MovieID_SelectedValueChanged(object sender, EventArgs e)
        //Display the MovieName when MovieID changed
        {
            Movie movieSelected = cboFormat_MovieID.SelectedItem as Movie;
            txtFormat_MovieName.Text = movieSelected.Name;
        }
        void LoadScreenIDIntoCombobox(ComboBox comboBox)
        {
            comboBox.DataSource = ScreenTypeDAO.GetListScreenType();
            comboBox.DisplayMember = "ID";
            comboBox.ValueMember = "ID";
        }
        private void cboFormat_ScreenID_SelectedValueChanged(object sender, EventArgs e)
        {
            ScreenType screenTypeSelected = cboFormat_ScreenID.SelectedItem as ScreenType;
            txtFormat_ScreenName.Text = screenTypeSelected.Name;
        }
        void LoadFormatMovieList()
        {
            formatList.DataSource = FormatMovieDAO.GetListFormatMovie();
        }

        void AddFormatBinding()
        {
            txtFormatID.DataBindings.Add("Text", dtgvFormat.DataSource, "Mã định dạng", true, DataSourceUpdateMode.Never);
        }
        private void txtFormatID_TextChanged(object sender, EventArgs e)
        {
            if (FormatMovieDAO.GetListFormatMovie().Rows.Count == 0)
                return;
            string movieID = (string)dtgvFormat.SelectedCells[0].OwningRow.Cells["Mã phim"].Value;
            Movie movieSelecting = MovieDAO.GetMovieByID(movieID);
            //This is the Movie that we're currently selecting in dtgv

            if (movieSelecting == null)
                return;

            //cboFormat_MovieID.SelectedItem = movieSelecting;

            int indexMovie = -1;
            int iMovie = 0;
            foreach (Movie item in cboFormat_MovieID.Items)
            {
                if (item.Name == movieSelecting.Name)
                {
                    indexMovie = iMovie;
                    break;
                }
                iMovie++;
            }
            cboFormat_MovieID.SelectedIndex = indexMovie;


            string screenName = (string)dtgvFormat.SelectedCells[0].OwningRow.Cells["Tên màn hình"].Value;
            ScreenType screenTypeSelecting = ScreenTypeDAO.GetScreenTypeByName(screenName);
            //This is the ScreenType that we're currently selecting in dtgv

            if (screenTypeSelecting == null)
                return;

            //cboFormat_ScreenID.SelectedItem = screenTypeSelecting;

            int indexScreen = -1;
            int iScreen = 0;
            foreach (ScreenType item in cboFormat_ScreenID.Items)
            {
                if (item.Name == screenTypeSelecting.Name)
                {
                    indexScreen = iScreen;
                    break;
                }
                iScreen++;
            }
            cboFormat_ScreenID.SelectedIndex = indexScreen;
        }

        private void btnShowFormat_Click(object sender, EventArgs e)
        {
            LoadFormatMovieList();
        }

        void InsertFormat(string id, string idMovie, string idScreen)
        {
            if (FormatMovieDAO.InsertFormatMovie(id, idMovie, idScreen))
            {
                MessageBox.Show("Thêm định dạng thành công");
            }
            else
            {
                MessageBox.Show("Thêm định dạng thất bại");
            }
        }
        private void btnInsertFormat_Click(object sender, EventArgs e)
        {
            if (txtFormatID.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("ID định dạng phim không được trống!!!");
                return;
            }
            if (txtFormatID.Text.Trim().Length < 3)
            {
                MessageBox.Show("Phải nhập đúng định dạng mã!!! \nVD: DD01");
                return;
            }
            string idChar = txtFormatID.Text.Trim().ToUpper().Substring(0, 2);
            string idNum = txtFormatID.Text.Trim().ToUpper().Substring(2);
            if ((Regex.IsMatch(idChar, @"DD") == false) || (Regex.IsMatch(idNum, @"\D+") == true))
            {
                MessageBox.Show("Bạn phải nhập đúng định dạng mã!!! \nVD: DD01");
                return;
            }
            if (FormatMovieDAO.CheckMovieAndScreenUsing(cboFormat_MovieID.Text , cboFormat_ScreenID.Text).Rows.Count > 0)
            {
                MessageBox.Show("Cặp phim/loại màn hình đã có!!!");
                return;
            }
            if (DAO.FormatMovieDAO.SearchFMByID(txtFormatID.Text.Trim()).Rows.Count > 0)
            {
                MessageBox.Show("Trùng ID định dạng khác!!!");
                return;
            }
            string formatID = txtFormatID.Text.ToUpper();
            string movieID = cboFormat_MovieID.SelectedValue.ToString();
            string screenID = cboFormat_ScreenID.SelectedValue.ToString();
            InsertFormat(formatID, movieID, screenID);
            LoadFormatMovieList();
        }

        void UpdateFormat(string id, string idMovie, string idScreen)
        {
            if (FormatMovieDAO.UpdateFormatMovie(id, idMovie, idScreen))
            {
                MessageBox.Show("Sửa định dạng thành công");
            }
            else
            {
                MessageBox.Show("Sửa định dạng thất bại");
            }
        }
        private void btnUpdateFormat_Click(object sender, EventArgs e)
        {
            if (txtFormatID.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Bạn phải nhập ID định dạng phim!!!");
                return;
            }
            if (DAO.FormatMovieDAO.SearchFMByID(txtFormatID.Text.Trim()).Rows.Count == 0)
            {
                MessageBox.Show("Định dạng(ID) cần sửa thông tin không có trong danh sách!!!");
                return;
            }
            if ((FormatMovieDAO.CheckMovieAndScreenUsing(cboFormat_MovieID.Text, cboFormat_ScreenID.Text).Rows.Count > 0) && ((FormatMovieDAO.SearchFMByID(txtFormatID.Text.Trim()).Rows[0]["idPhim"].Equals(cboFormat_MovieID.Text.Trim()) == false) || (FormatMovieDAO.SearchFMByID(txtFormatID.Text.Trim()).Rows[0]["idLoaiManHinh"].Equals(cboFormat_ScreenID.Text.Trim()) == false)))
            {
                MessageBox.Show("Cặp phim/loại màn hình đã có!!!");
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn sửa thông tin định dạng này?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            string formatID = txtFormatID.Text;
            string movieID = cboFormat_MovieID.SelectedValue.ToString();
            string screenID = cboFormat_ScreenID.SelectedValue.ToString();
            UpdateFormat(formatID, movieID, screenID);
            LoadFormatMovieList();
        }

        void DeleteFormat(string id)
        {
            if (FormatMovieDAO.DeleteFormatMovie(id))
            {
                MessageBox.Show("Xóa định dạng thành công");
            }
            else
            {
                MessageBox.Show("Xóa định dạng thất bại");
            }
        }
        private void btnDeleteFormat_Click(object sender, EventArgs e)
        {
            if (FormatMovieDAO.SearchFormatMovieUsingInShowTime(txtFormatID.Text.Trim()).Rows.Count > 0)
            {
                MessageBox.Show("Xóa lịch chiếu có chứa định dạng này trước!!!");
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn xóa thông tin định dạng này?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            string formatID = txtFormatID.Text;
            DeleteFormat(formatID);
            LoadFormatMovieList();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFormatID.Text = "";
            cboFormat_MovieID.SelectedIndex = 0;
            cboFormat_ScreenID.SelectedIndex = 0;
        }
    }
}
