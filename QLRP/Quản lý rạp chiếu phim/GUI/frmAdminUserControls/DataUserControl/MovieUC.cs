using GUI.DAO;
using GUI.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GUI.frmAdminUserControls.DataUserControl
{
    public partial class MovieUC : UserControl
    {
        BindingSource movieList = new BindingSource();

        public MovieUC()
        {
            InitializeComponent();
            LoadMovie();
        }

        void LoadMovie()
        {
            dtgvMovie.DataSource = movieList;
            LoadMovieList();
            AddMovieBinding();
        }
        void LoadMovieList()
        {
            movieList.DataSource = MovieDAO.GetMovie();
            dtmMovieEnd.MinDate = DateTime.Now;
        }
        private void btnShowMovie_Click(object sender, EventArgs e)
        {
            LoadMovieList();
        }
        void AddMovieBinding()
        {
            txtMovieID.DataBindings.Add("Text", dtgvMovie.DataSource, "Mã phim", true,  DataSourceUpdateMode.Never);
            txtMovieName.DataBindings.Add("Text", dtgvMovie.DataSource, "Tên phim", true, DataSourceUpdateMode.Never);
            txtMovieDesc.DataBindings.Add("Text", dtgvMovie.DataSource, "Mô tả", true, DataSourceUpdateMode.Never);
            txtMovieLength.DataBindings.Add("Text", dtgvMovie.DataSource, "Thời lượng", true, DataSourceUpdateMode.Never);
            dtmMovieStart.DataBindings.Add("Value", dtgvMovie.DataSource, "Ngày khởi chiếu", true, DataSourceUpdateMode.Never);
            dtmMovieEnd.DataBindings.Add("Value", dtgvMovie.DataSource, "Ngày kết thúc", true, DataSourceUpdateMode.Never);
            txtMovieProductor.DataBindings.Add("Text", dtgvMovie.DataSource, "Sản xuất", true, DataSourceUpdateMode.Never);
            txtMovieDirector.DataBindings.Add("Text", dtgvMovie.DataSource, "Đạo diễn", true, DataSourceUpdateMode.Never);
            txtMovieYear.DataBindings.Add("Text", dtgvMovie.DataSource, "Năm SX", true, DataSourceUpdateMode.Never);
            LoadGenreIntoCheckedList(clbMovieGenre);
        }
        void LoadGenreIntoCheckedList(CheckedListBox checkedList)
        {
            List<Genre> genreList = GenreDAO.GetListGenre();
            checkedList.DataSource = genreList;
            checkedList.DisplayMember = "Name";
        }
        private void txtMovieID_TextChanged(object sender, EventArgs e)
        {
            picFilm.Image = null;
            for (int i = 0; i < clbMovieGenre.Items.Count; i++)
            {
                clbMovieGenre.SetItemChecked(i, false);
                //Uncheck all CheckBox first
            }

            List<Genre> listGenreOfMovie = MovieByGenreDAO.GetListGenreByMovieID(txtMovieID.Text);
            for (int i = 0; i < clbMovieGenre.Items.Count; i++)
            {
                Genre genre = (Genre)clbMovieGenre.Items[i];
                foreach (Genre item in listGenreOfMovie)
                {
                    if (genre.ID == item.ID)
                    {
                        clbMovieGenre.SetItemChecked(i, true);
                        break;
                    }
                }
            }

            Movie movie = MovieDAO.GetMovieByID(txtMovieID.Text);

            if (movie == null)
                return;

            if (movie.Poster != null)
                picFilm.Image = MovieDAO.byteArrayToImage(movie.Poster);
        }

        void InsertMovie(string id, string name, string desc, float length, DateTime startDate, DateTime endDate, string productor, string director, int year, byte[] image)
        {
            if (MovieDAO.InsertMovie(id, name, desc, length, startDate, endDate, productor, director, year, image))
            {
                MessageBox.Show("Thêm phim thành công");
            }
            else
            {
                MessageBox.Show("Thêm phim thất bại");
            }
        }
        void InsertMovie_Genre(string movieID, CheckedListBox checkedListBox)

        {
            List<Genre> checkedGenreList = new List<Genre>();
            foreach (Genre checkedItem in checkedListBox.CheckedItems)
            {
                checkedGenreList.Add(checkedItem);
            }
            MovieByGenreDAO.InsertMovie_Genre(movieID, checkedGenreList);
        }

        private void btnUpLoadPictureFilm_Click(object sender, EventArgs e)
        {
            try
            {
                string filePathImage = null;
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
                openFile.FilterIndex = 1;
                openFile.RestoreDirectory = true;
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    filePathImage = openFile.FileName;
                    picFilm.Image = Image.FromFile(filePathImage.ToString());
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            if (txtMovieID.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("ID phim không được trống!!!");
                return;
            }
            if (txtMovieID.Text.Trim().Length < 2)
            {
                MessageBox.Show("Phải nhập đúng định dạng mã phim!!! \nVD: P01");
                return;
            }
            string idChar = txtMovieID.Text.Trim().ToUpper().Substring(0, 1);
            string idNum = txtMovieID.Text.Trim().ToUpper().Substring(1);
            if ((Regex.IsMatch(idChar, @"P") == false) || (Regex.IsMatch(idNum, @"\D+") == true))
            {
                MessageBox.Show("Phải nhập đúng định dạng mã phim!!! \nVD: P01");
                return;
            }
            if (DAO.MovieDAO.SearchMovieByID(txtMovieID.Text.Trim()).Rows.Count > 0)
            {
                MessageBox.Show("Trùng ID phim khác!!!");
                return;
            }
            if (txtMovieName.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Tên phim không được trống!!!");
                return;
            }
            if (txtMovieYear.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Năm sản xuất không được trống!!!");
                return;
            }
            if (Regex.IsMatch(txtMovieYear.Text.Trim(), @"\D+") == true)
            {
                MessageBox.Show("Năm sản xuất phải điền bằng số!!!");
                return;
            }
            if (txtMovieLength.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Thời lượng phim không được trống!!!");
                return;
            }
            if (Regex.IsMatch(txtMovieLength.Text.Trim(), @"\D+") == true)
            {
                MessageBox.Show("Thời lượng phải điền bằng số!!!\nĐơn vị: phút");
                return;
            }
            if (dtmMovieStart.Value.CompareTo(dtmMovieEnd.Value) > 0)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày khởi chiếu!!!");
                return;
            }
            if (dtmMovieEnd.Value.CompareTo(DateTime.Now) < 0)
            {
                MessageBox.Show("Ngày kết thúc phải là hiện tại hoặc tương lai!!!");
                return;
            }
            string movieID = txtMovieID.Text.ToUpper();
            string movieName = txtMovieName.Text;
            string movieDesc = txtMovieDesc.Text;
            float movieLength = float.Parse(txtMovieLength.Text);
            DateTime startDate = dtmMovieStart.Value;
            DateTime endDate = dtmMovieEnd.Value;
            string productor = txtMovieProductor.Text;
            string director = txtMovieDirector.Text;
            int year = int.Parse(txtMovieYear.Text);
            if (picFilm.Image == null)
            {
                MessageBox.Show("Mời bạn thêm hình ảnh cho phim trước");
                return;
            }
            InsertMovie(movieID, movieName, movieDesc, movieLength, startDate, endDate, productor, director, year, MovieDAO.imageToByteArray(picFilm.Image));
            InsertMovie_Genre(movieID, clbMovieGenre);
            LoadMovieList();
        }

        void UpdateMovie(string id, string name, string desc, float length, DateTime startDate, DateTime endDate, string productor, string director, int year, byte[] image)
        {
            if (MovieDAO.UpdateMovie(id, name, desc, length, startDate, endDate, productor, director, year, image))
            {
                MessageBox.Show("Sửa phim thành công");
            }
            else
            {
                MessageBox.Show("Sửa phim thất bại");
            }
        }
        void UpdateMovie_Genre(string movieID, CheckedListBox checkedListBox)
        {
            List<Genre> checkedGenreList = new List<Genre>();
            foreach (Genre checkedItem in checkedListBox.CheckedItems)
            {
                checkedGenreList.Add(checkedItem);
            }
            MovieByGenreDAO.UpdateMovie_Genre(movieID, checkedGenreList);
        }
        private void btnUpdateMovie_Click(object sender, EventArgs e)
        {
            if (txtMovieID.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Bạn phải nhập ID của phim");
                return;
            }
            if (DAO.MovieDAO.SearchMovieByID(txtMovieID.Text.Trim()).Rows.Count == 0)
            {
                MessageBox.Show("Phim(ID) cần sửa thông tin không có trong danh sách");
                return;
            }
            if (txtMovieName.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Tên phim không được trống!!!");
                return;
            }
            if (txtMovieYear.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Năm sản xuất không được trống!!!");
                return;
            }
            if (Regex.IsMatch(txtMovieYear.Text.Trim(), @"\D+") == true)
            {
                MessageBox.Show("Năm sản xuất phải điền bằng số!!!");
                return;
            }
            if (txtMovieLength.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Thời lượng phim không được trống!!!");
                return;
            }
            if (Regex.IsMatch(txtMovieLength.Text.Trim(), @"\D+") == true)
            {
                MessageBox.Show("Thời lượng phải điền bằng số!!! \nĐơn vị: phút");
                return;
            }
            if (dtmMovieStart.Value.CompareTo(dtmMovieEnd.Value) > 0)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày khởi chiếu!!!");
                return;
            }
            if (dtmMovieEnd.Value.CompareTo(DateTime.Now) < 0)
            {
                MessageBox.Show("Ngày kết thúc phải là hiện tại hoặc tương lai!!!");
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn sửa thông tin phim này?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            string movieID = txtMovieID.Text;
            string movieName = txtMovieName.Text;
            string movieDesc = txtMovieDesc.Text;
            float movieLength = float.Parse(txtMovieLength.Text);
            DateTime startDate = dtmMovieStart.Value;
            DateTime endDate = dtmMovieEnd.Value;
            string productor = txtMovieProductor.Text;
            string director = txtMovieDirector.Text;
            int year = int.Parse(txtMovieYear.Text);
            if (picFilm.Image == null)
            {
                MessageBox.Show("Mời bạn thêm hình ảnh cho phim trước");
                return;
            }
            UpdateMovie(movieID, movieName, movieDesc, movieLength, startDate, endDate, productor, director, year, MovieDAO.imageToByteArray(picFilm.Image));
            UpdateMovie_Genre(movieID, clbMovieGenre);
            LoadMovieList();
        }

        void DeleteMovie(string id)
        {
            if (MovieDAO.DeleteMovie(id))
            {
                MessageBox.Show("Xóa phim thành công");
            }
            else
            {
                MessageBox.Show("Xóa phim thất bại");
            }
        }
        private void btnDeleteMovie_Click(object sender, EventArgs e)
        {
            if (MovieDAO.SearchMovieUsingInFormatMovie(txtMovieID.Text.Trim()).Rows.Count > 0)
            {
                MessageBox.Show("Xóa định dạng phim có chứa phim này trước!!!");
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn xóa thông tin phim này?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }         
            string movieID = txtMovieID.Text;
            DeleteMovie(movieID);
            LoadMovieList();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMovieDesc.Text = "";
            txtMovieDirector.Text = "";
            txtMovieID.Text = "";
            txtMovieLength.Text = "";
            txtMovieName.Text = "";
            txtMovieProductor.Text = "";
            txtMovieYear.Text = "";
            picFilm.Image = null;
            clbMovieGenre.SelectedItem = null;
        }
    }
}
