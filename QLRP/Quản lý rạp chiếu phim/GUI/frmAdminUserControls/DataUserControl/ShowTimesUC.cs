using GUI.DAO;
using GUI.DTO;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GUI.frmAdminUserControls.DataUserControl
{
    public partial class ShowTimesUC : UserControl
    {
        BindingSource showtimeList = new BindingSource();
        public ShowTimesUC()
        {
            InitializeComponent();
            LoadShowtime();
        }

        void LoadShowtime()
        {
            dtgvShowtime.DataSource = showtimeList;
            LoadShowtimeList();
            LoadFormatMovieIntoComboBox();
            AddShowtimeBinding();
        }
        void LoadShowtimeList()
        {
            showtimeList.DataSource = ShowTimesDAO.GetListShowtime();
        }
        private void btnShowShowtime_Click(object sender, EventArgs e)
        {
            LoadShowtimeList();
        }
        void AddShowtimeBinding()
        {
            txtShowtimeID.DataBindings.Add("Text", dtgvShowtime.DataSource, "Mã lịch chiếu", true, DataSourceUpdateMode.Never);
            dtmShowtimeDate.DataBindings.Add("Value", dtgvShowtime.DataSource, "Thời gian chiếu", true, DataSourceUpdateMode.Never);
            dtmShowtimeTime.DataBindings.Add("Value", dtgvShowtime.DataSource, "Thời gian chiếu", true, DataSourceUpdateMode.Never);
            txtTicketPrice_Showtime.DataBindings.Add("Text", dtgvShowtime.DataSource, "Giá vé", true, DataSourceUpdateMode.Never);
        }
        void LoadFormatMovieIntoComboBox()
        {
            cboFormatID_Showtime.DataSource = FormatMovieDAO.GetFormatMovie();
            cboFormatID_Showtime.DisplayMember = "ID";
        }
        private void cboFormatID_Showtime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFormatID_Showtime.SelectedIndex != -1)
            {
                FormatMovie formatMovieSelecting = (FormatMovie)cboFormatID_Showtime.SelectedItem;
                txtMovieName_Showtime.Text = formatMovieSelecting.MovieName;
                txtScreenTypeName_Showtime.Text = formatMovieSelecting.ScreenTypeName;
                if(dtmShowtimeDate.MinDate.CompareTo((DateTime)MovieDAO.SearchEndDay(formatMovieSelecting.ID).Rows[0]["NgayKetThuc"]) >= 0)
                {
                    dtmShowtimeDate.MinDate = (DateTime)MovieDAO.SearchStartDay(formatMovieSelecting.ID).Rows[0]["NgayKhoiChieu"];
                    dtmShowtimeDate.MaxDate = (DateTime)MovieDAO.SearchEndDay(formatMovieSelecting.ID).Rows[0]["NgayKetThuc"];
                }
                else
                {
                    dtmShowtimeDate.MaxDate = (DateTime)MovieDAO.SearchEndDay(formatMovieSelecting.ID).Rows[0]["NgayKetThuc"];
                    dtmShowtimeDate.MinDate = (DateTime)MovieDAO.SearchStartDay(formatMovieSelecting.ID).Rows[0]["NgayKhoiChieu"];                   
                }
                cboCinemaID_Showtime.DataSource = null;
                ScreenType screenType = ScreenTypeDAO.GetScreenTypeByName(formatMovieSelecting.ScreenTypeName);
                cboCinemaID_Showtime.DataSource = CinemaDAO.GetCinemaByScreenTypeID(screenType.ID);
                cboCinemaID_Showtime.DisplayMember = "Name";
            }
        }
        private void txtShowtimeID_TextChanged(object sender, EventArgs e)
        {
            if (ShowTimesDAO.GetListShowtime().Rows.Count == 0)
            {
                return;
            }    
            #region Change selected index of ComboBox FormatMovie
            string movieName = (string)dtgvShowtime.SelectedCells[0].OwningRow.Cells["Tên phim"].Value;
            string screenTypeName = (string)dtgvShowtime.SelectedCells[0].OwningRow.Cells["Màn hình"].Value;
            if (FormatMovieDAO.GetFormatMovieByMovieName(movieName, screenTypeName).Rows.Count == 0) return;
            FormatMovie formatMovieSelecting = FormatMovieDAO.GetFormatMovieByName(movieName, screenTypeName);
            if (formatMovieSelecting == null)
                return;
            int indexFormatMovie = -1;
            for (int i = 0; i < cboFormatID_Showtime.Items.Count; i++)
            {
                FormatMovie item = cboFormatID_Showtime.Items[i] as FormatMovie;
                if (item.ID == formatMovieSelecting.ID)
                {
                    indexFormatMovie = i;
                    break;
                }
            }
            cboFormatID_Showtime.SelectedIndex = indexFormatMovie;
            #endregion
            #region Change selected index of ComboBox Cinema
            string cinemaID = (string)dtgvShowtime.SelectedCells[0].OwningRow.Cells["Mã phòng"].Value;
            Cinema cinemaSelecting = CinemaDAO.GetCinemaByID(cinemaID);
            //This is the Cinema that we're currently selecting in dtgv

            if (cinemaSelecting == null)
                return;

            int indexCinema = -1;
            int iCinema = 0;
            foreach (Cinema item in cboCinemaID_Showtime.Items)
            {
                if (item.ID == cinemaSelecting.ID)
                {
                    indexCinema = iCinema;
                    break;
                }
                iCinema++;
            }
            cboCinemaID_Showtime.SelectedIndex = indexCinema;
			#endregion
			toolTipCinema.SetToolTip(cboCinemaID_Showtime, "Danh sách phòng chiếu hỗ trợ loại màn hình trên");
        }
        void InsertShowtime(string id, string cinemaID, string formatMovieID, DateTime time, int ticketPrice)
        {
            if (ShowTimesDAO.InsertShowtime(id, cinemaID, formatMovieID, time, ticketPrice))
            {
                MessageBox.Show("Thêm lịch chiếu thành công");
            }
            else
            {
                MessageBox.Show("Thêm lịch chiếu thất bại");
            }
        }
        private void btnInsertShowtime_Click(object sender, EventArgs e)
        {
            if (txtShowtimeID.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("ID lịch chiếu không được trống!!!");
                return;
            }
            if (txtShowtimeID.Text.Trim().Length < 3)
            {
                MessageBox.Show("Phải nhập đúng định dạng mã lịch chiếu!!! \nVD: LC01");
                return;
            }
            string idChar = txtShowtimeID.Text.Trim().ToUpper().Substring(0, 2);
            string idNum = txtShowtimeID.Text.Trim().ToUpper().Substring(2);
            if ((Regex.IsMatch(idChar, @"LC") == false) || (Regex.IsMatch(idNum, @"\D+") == true))
            {
                MessageBox.Show("Phải nhập đúng định dạng mã lịch chiếu!!! \nVD: LC01");
                return;
            }
            if(DAO.ShowTimesDAO.SearchShowTimeByID(txtShowtimeID.Text.Trim()).Rows.Count > 0)
            {
                MessageBox.Show("Trùng ID lịch chiếu khác!!!");
                return;
            }
            if (txtTicketPrice_Showtime.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Giá vé không được trống!!!");
                return;
            }
            if (Regex.IsMatch(txtTicketPrice_Showtime.Text.Trim(), @"\D+") == true)
            {
                MessageBox.Show("Giá vé phải điền bằng số!!!");
                return;
            }
            string showtimeID = txtShowtimeID.Text.ToUpper();
            string cinemaID = ((Cinema)cboCinemaID_Showtime.SelectedItem).ID;
            string formatMovieID = ((FormatMovie)cboFormatID_Showtime.SelectedItem).ID;
            DateTime time = new DateTime(dtmShowtimeDate.Value.Year, dtmShowtimeDate.Value.Month, dtmShowtimeDate.Value.Day, dtmShowtimeTime.Value.Hour, dtmShowtimeTime.Value.Minute, dtmShowtimeTime.Value.Second);
            //Bind dtmShowtimeDate to "time.date" and dtmShowtimeTime to "time.time" ... TODO : Look for a better way to do this
            if (ShowTimesDAO.SearchStartTime(cinemaID).Rows.Count > 0)
            {
                for (int i = 0; i < ShowTimesDAO.SearchStartTime(cinemaID).Rows.Count; i++)
                {
                    DateTime test = (DateTime)ShowTimesDAO.SearchStartTime(cinemaID).Rows[i]["ThoiGianChieu"];
                    DateTime endTime = new DateTime(dtmShowTimeEDate.Value.Year, dtmShowTimeEDate.Value.Month, dtmShowTimeEDate.Value.Day, dtmShowTimeET.Value.Hour, dtmShowTimeET.Value.Minute, dtmShowTimeET.Value.Second);
                    if ((time.CompareTo(test) >= 0) && (time.CompareTo(test.AddMinutes((double)ShowTimesDAO.SearchStartTime(cinemaID).Rows[i]["ThoiLuong"])) < 0))
                    {
                        MessageBox.Show("Trùng thời gian chiếu của phim khác!!!");
                        return;
                    }
                    if ((endTime.CompareTo(test) >= 0) && (endTime.CompareTo(test.AddMinutes((double)ShowTimesDAO.SearchStartTime(cinemaID).Rows[i]["ThoiLuong"])) < 0))
                    {
                        MessageBox.Show("Trùng thời gian chiếu của phim khác!!!");
                        return;
                    }
                }
            }
            if (time.CompareTo(DateTime.Now) < 0)
            {
                MessageBox.Show("Thời gian chiếu phải nằm ở hiện tại hoặc tương lai!!!");
                return;
            }
            if ((time.CompareTo(DateTime.Now) == 0) && (time.Hour < DateTime.Now.Hour))
            {
                MessageBox.Show("Thời gian chiếu phải nằm ở hiện tại hoặc tương lai!!!");
                return;
            }
            int ticketPrice = int.Parse(txtTicketPrice_Showtime.Text);
            InsertShowtime(showtimeID, cinemaID, formatMovieID, time, ticketPrice);
            LoadShowtimeList();
        }
        void UpdateShowtime(string id, string cinemaID, string formatMovieID, DateTime time, int ticketPrice)
        {
            if (ShowTimesDAO.UpdateShowtime(id, cinemaID, formatMovieID, time, ticketPrice))
            {
                MessageBox.Show("Sửa lịch chiếu thành công");
            }
            else
            {
                MessageBox.Show("Sửa lịch chiếu thất bại");
            }
        }
        private void btnUpdateShowtime_Click(object sender, EventArgs e)
        {
            if (txtShowtimeID.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Bạn phải nhập ID lịch chiếu!!!");
                return;
            }
            if (DAO.ShowTimesDAO.SearchShowTimeByID(txtShowtimeID.Text.Trim()).Rows.Count == 0)
            {
                MessageBox.Show("Lịch chiếu(ID) cần sửa thông tin không có trong danh sách!!!");
                return;
            }
            if (txtTicketPrice_Showtime.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Giá vé không được trống!!!");
                return;
            }
            if (Regex.IsMatch(txtTicketPrice_Showtime.Text.Trim(), @"\D+") == true)
            {
                MessageBox.Show("Giá vé phải điền bằng số!!!");
                return;
            }                     
            string showtimeID = txtShowtimeID.Text;
            string cinemaID = ((Cinema)cboCinemaID_Showtime.SelectedItem).ID;
            string formatMovieID = ((FormatMovie)cboFormatID_Showtime.SelectedItem).ID;
            DateTime time = new DateTime(dtmShowtimeDate.Value.Year, dtmShowtimeDate.Value.Month, dtmShowtimeDate.Value.Day, dtmShowtimeTime.Value.Hour, dtmShowtimeTime.Value.Minute, dtmShowtimeTime.Value.Second);
            //Bind dtmShowtimeDate to "time.date" and dtmShowtimeTime to "time.time" ... TODO : Look for a better way to do this
            if (ShowTimesDAO.SearchStartTime(cinemaID).Rows.Count > 0)
            {
                for (int i = 0; i < ShowTimesDAO.SearchStartTime(cinemaID).Rows.Count; i++)
                {
                    DateTime test = (DateTime)ShowTimesDAO.SearchStartTime(cinemaID).Rows[i]["ThoiGianChieu"];
                    DateTime endTime = new DateTime(dtmShowTimeEDate.Value.Year, dtmShowTimeEDate.Value.Month, dtmShowTimeEDate.Value.Day, dtmShowTimeET.Value.Hour, dtmShowTimeET.Value.Minute, dtmShowTimeET.Value.Second);
                    if ((time.CompareTo(test) >= 0) && (time.CompareTo(test.AddMinutes((double)ShowTimesDAO.SearchStartTime(cinemaID).Rows[i]["ThoiLuong"])) < 0) && (time.CompareTo((DateTime)ShowTimesDAO.SearchStartTimeByID(txtShowtimeID.Text.Trim()).Rows[0]["ThoiGianChieu"]) != 0))
                    {
                        MessageBox.Show("Trùng thời gian chiếu của phim khác!!!");
                        return;
                    }
                    if ((endTime.CompareTo(test) >= 0) && (endTime.CompareTo(test.AddMinutes((double)ShowTimesDAO.SearchStartTime(cinemaID).Rows[i]["ThoiLuong"])) < 0) && (time.CompareTo((DateTime)ShowTimesDAO.SearchStartTimeByID(txtShowtimeID.Text.Trim()).Rows[0]["ThoiGianChieu"]) != 0))
                    {
                        MessageBox.Show("Trùng thời gian chiếu của phim khác!!!");
                        return;
                    }
                    if ((time.CompareTo(test) >= 0) && (time.CompareTo(test.AddMinutes((double)ShowTimesDAO.SearchStartTime(cinemaID).Rows[i]["ThoiLuong"])) < 0) && (cinemaID.Equals(ShowTimesDAO.SearchShowTimeByID(txtShowtimeID.Text.Trim()).Rows[0]["idPhong"].ToString()) == false))
                    {
                        MessageBox.Show("Trùng thời gian chiếu của phim khác!!!");
                        return;
                    }
                    if ((endTime.CompareTo(test) >= 0) && (endTime.CompareTo(test.AddMinutes((double)ShowTimesDAO.SearchStartTime(cinemaID).Rows[i]["ThoiLuong"])) < 0) && (cinemaID.Equals(ShowTimesDAO.SearchShowTimeByID(txtShowtimeID.Text.Trim()).Rows[0]["idPhong"].ToString()) == false))
                    {
                        MessageBox.Show("Trùng thời gian chiếu của phim khác!!!");
                        return;
                    }
                }
            }
            if ((time.CompareTo(DateTime.Now) < 0) && (time.CompareTo((DateTime)ShowTimesDAO.SearchStartTimeByID(txtShowtimeID.Text.Trim()).Rows[0]["ThoiGianChieu"]) != 0))
            {
                MessageBox.Show("Thời gian chiếu phải nằm ở hiện tại hoặc tương lai!!!");
                return;

            }
            if (((time.CompareTo(DateTime.Now) == 0) && (time.Hour < DateTime.Now.Hour)) && (time.CompareTo((DateTime)ShowTimesDAO.SearchStartTimeByID(txtShowtimeID.Text.Trim()).Rows[0]["ThoiGianChieu"]) != 0))
            {
                MessageBox.Show("Thời gian chiếu phải nằm ở hiện tại hoặc tương lai!!!");
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn sửa thông tin lịch chiếu này?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            int ticketPrice = int.Parse(txtTicketPrice_Showtime.Text);
            UpdateShowtime(showtimeID, cinemaID, formatMovieID, time, ticketPrice);
            LoadShowtimeList();
        }
        void DeleteShowtime(string id)
        {
            if (ShowTimesDAO.DeleteShowtime(id))
            {
                MessageBox.Show("Xóa lịch chiếu thành công");
            }
            else
            {
                MessageBox.Show("Xóa lịch chiếu thất bại");
            }
        }
        private void btnDeleteShowtime_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn xóa thông tin lịch chiếu này?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            string showtimeID = txtShowtimeID.Text;
            DeleteShowtime(showtimeID);
            LoadShowtimeList();
        }
        private void btnSearchShowtime_Click(object sender, EventArgs e)
        {
            string movieName = txtSearchShowtime.Text;
            showtimeList.DataSource = ShowTimesDAO.SearchShowtimeByMovieName(movieName);
        }

		private void txtSearchShowtime_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btnSearchShowtime.PerformClick();
				e.SuppressKeyPress = true;//Tắt tiếng *ting của windows
			}
		}

        private void dtmShowtimeDate_ValueChanged(object sender, EventArgs e)
        {
            if (ShowTimesDAO.GetListShowtime().Rows.Count == 0)
                return;
            FormatMovie formatMovieSelecting = (FormatMovie)cboFormatID_Showtime.SelectedItem;
            DateTime time = new DateTime(dtmShowtimeDate.Value.Year, dtmShowtimeDate.Value.Month, dtmShowtimeDate.Value.Day, dtmShowtimeTime.Value.Hour, dtmShowtimeTime.Value.Minute, dtmShowtimeTime.Value.Second);
            dtmShowTimeEDate.Value = time.AddMinutes((double)FormatMovieDAO.SearchMovieLengthByFormatID(formatMovieSelecting.ID).Rows[0]["ThoiLuong"]);
            dtmShowTimeET.Value = time.AddMinutes((double)FormatMovieDAO.SearchMovieLengthByFormatID(formatMovieSelecting.ID).Rows[0]["ThoiLuong"]);
        }

        private void dtmShowtimeTime_ValueChanged(object sender, EventArgs e)
        {
            if (ShowTimesDAO.GetListShowtime().Rows.Count == 0)
                return;
            FormatMovie formatMovieSelecting = (FormatMovie)cboFormatID_Showtime.SelectedItem;
            DateTime time = new DateTime(dtmShowtimeDate.Value.Year, dtmShowtimeDate.Value.Month, dtmShowtimeDate.Value.Day, dtmShowtimeTime.Value.Hour, dtmShowtimeTime.Value.Minute, dtmShowtimeTime.Value.Second);
            dtmShowTimeEDate.Value = time.AddMinutes((double)FormatMovieDAO.SearchMovieLengthByFormatID(formatMovieSelecting.ID).Rows[0]["ThoiLuong"]);
            dtmShowTimeET.Value = time.AddMinutes((double)FormatMovieDAO.SearchMovieLengthByFormatID(formatMovieSelecting.ID).Rows[0]["ThoiLuong"]);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtShowtimeID.Text = "";
            txtTicketPrice_Showtime.Text = "";
            cboCinemaID_Showtime.SelectedIndex = 0;
            cboFormatID_Showtime.SelectedIndex = 0;
        }

        private void txtSearchShowtime_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearchShowtime.Text = "";
        }
    }
}
