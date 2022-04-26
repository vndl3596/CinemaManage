using GUI.DAO;
using GUI.DTO;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GUI.frmAdminUserControls.DataUserControl
{
    public partial class CinemaUC : UserControl
    {
        BindingSource cinemaList = new BindingSource();
        public CinemaUC()
        {
            InitializeComponent();
            LoadCinema();
        }

        void LoadCinema()
        {
            dtgvCinema.DataSource = cinemaList;
            LoadCinemaList();
            AddCinemaBinding();
        }
        void LoadCinemaList()
        {
            cinemaList.DataSource = CinemaDAO.GetListCinema();
        }
        void AddCinemaBinding()
        {
            txtCinemaID.DataBindings.Add("Text", dtgvCinema.DataSource, "Mã phòng", true, DataSourceUpdateMode.Never);
            txtCinemaName.DataBindings.Add("Text", dtgvCinema.DataSource, "Tên phòng", true, DataSourceUpdateMode.Never);
            txtCinemaSeats.DataBindings.Add("Text", dtgvCinema.DataSource, "Số chỗ ngồi", true, DataSourceUpdateMode.Never);
            txtNumberOfRows.DataBindings.Add("Text", dtgvCinema.DataSource, "Số hàng ghế", true, DataSourceUpdateMode.Never);
            txtSeatsPerRow.DataBindings.Add("Text", dtgvCinema.DataSource, "Ghế mỗi hàng", true, DataSourceUpdateMode.Never);
            LoadScreenTypeIntoComboBox(cboCinemaScreenType);
        }
        void LoadScreenTypeIntoComboBox(ComboBox cbo)
        {
            cbo.DataSource = ScreenTypeDAO.GetListScreenType();
            cbo.DisplayMember = "Name";
            cbo.ValueMember = "ID";
        }
        private void txtCinemaID_TextChanged(object sender, EventArgs e)
        //Use this to bind data between dtgv and cbo because cbo can't be applied DataBindings normally
        {
            if (CinemaDAO.GetListCinema().Rows.Count == 0)
                return;
            string screenName = (string)dtgvCinema.SelectedCells[0].OwningRow.Cells["Tên màn hình"].Value;
            DTO.ScreenType screenType = ScreenTypeDAO.GetScreenTypeByName(screenName);
            //This is the ScreenType that we're currently selecting in dtgv

            cboCinemaScreenType.SelectedItem = screenType;

            int index = -1;
            int i = 0;
            foreach (ScreenType item in cboCinemaScreenType.Items)
            {
                if (item.Name == screenType.Name)
                {
                    index = i;
                    break;
                }
                i++;
            }
            cboCinemaScreenType.SelectedIndex = index;

            if (CinemaDAO.SearchCinemaStatusByID(txtCinemaID.Text.Trim()).Rows.Count == 0)
            {
                return;
            }
            if ((int)CinemaDAO.SearchCinemaStatusByID(txtCinemaID.Text.Trim()).Rows[0]["TinhTrang"] == 1)
            {
                cboCinemaStatus.SelectedIndex = 0;
            }
            if ((int)CinemaDAO.SearchCinemaStatusByID(txtCinemaID.Text.Trim()).Rows[0]["TinhTrang"] == 0)
            {
                cboCinemaStatus.SelectedIndex = 1;
            }
        }

        void InsertCinema(string id, string name, string idMH, int seats, int status, int numberOfRows, int seatsPerRow)
        {
            if (CinemaDAO.InsertCinema(id, name, idMH, seats, status, numberOfRows, seatsPerRow))
            {
                MessageBox.Show("Thêm phòng chiếu thành công");
            }
            else
            {
                MessageBox.Show("Thêm phòng chiếu thất bại");
            }
        }
        private void btnInsertCinema_Click(object sender, EventArgs e)
        {
            if(txtCinemaID.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("ID phòng chiếu không được trống!!!");
                return;
            }
            if (txtCinemaID.Text.Trim().Length < 3)
            {
                MessageBox.Show("Phải nhập đúng định dạng mã phòng chiếu!!! \nVD: PC01");
                return;
            }
            string idChar = txtCinemaID.Text.Trim().ToUpper().Substring(0, 2);
            string idNum = txtCinemaID.Text.Trim().ToUpper().Substring(2);
            if ((Regex.IsMatch(idChar, @"PC") == false) || (Regex.IsMatch(idNum, @"\D+") == true))
            {
                MessageBox.Show("Phải nhập đúng định dạng mã phòng chiếu!!! \nVD: PC01");
                return;
            }
            if (DAO.CinemaDAO.SearchCinemaByID(txtCinemaID.Text.Trim()).Rows.Count > 0)
            {
                MessageBox.Show("Trùng ID phòng khác!!!");
                return;
            }
            if (txtCinemaName.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Tên phòng chiếu không được trống!!!");
                return;
            }
            if (txtCinemaSeats.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Số ghế không được trống!!!");
                return;
            }
            if (Regex.IsMatch(txtCinemaSeats.Text.Trim(), @"\D+") == true)
            {
                MessageBox.Show("Số ghế phải điền bằng số!!!");
                return;
            }
            if (txtNumberOfRows.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Số hàng ghế không được trống!!!");
                return;
            }
            if (Regex.IsMatch(txtNumberOfRows.Text.Trim(), @"\D+") == true)
            {
                MessageBox.Show("Số hàng ghế phải điền bằng số!!!");
                return;
            }
            if (txtSeatsPerRow.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Số ghế mỗi hàng không được trống!!!");
                return;
            }
            if (Regex.IsMatch(txtSeatsPerRow.Text.Trim(), @"\D+") == true)
            {
                MessageBox.Show("Số ghế mỗi hàng phải điền bằng số!!!");
                return;
            }
            string cinemaID = txtCinemaID.Text.ToUpper();
            string cinemaName = txtCinemaName.Text;
            string screenTypeID = cboCinemaScreenType.SelectedValue.ToString();
            int cinemaSeats = int.Parse(txtCinemaSeats.Text);
            int cinemaStatus;
            if (cboCinemaStatus.Text.Equals("Hoạt động") == true)
            {
                cinemaStatus = 1;
            }
            else
            {
                cinemaStatus = 0;
            }
            int numberOfRows = int.Parse(txtNumberOfRows.Text);
            int seatsPerRows = int.Parse(txtSeatsPerRow.Text);
            InsertCinema(cinemaID, cinemaName, screenTypeID, cinemaSeats, cinemaStatus, numberOfRows, seatsPerRows);
            LoadCinemaList();
        }

        void UpdateCinema(string id, string name, string idMH, int seats, int status, int numberOfRows, int seatsPerRow)
        {
            if (CinemaDAO.UpdateCinema(id, name, idMH, seats, status, numberOfRows, seatsPerRow))
            {
                MessageBox.Show("Sửa phòng chiếu thành công");
            }
            else
            {
                MessageBox.Show("Sửa phòng chiếu thất bại");
            }
        }
        private void btnUpdateCinema_Click(object sender, EventArgs e)
        {
            if (txtCinemaID.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Bạn phải nhập ID phòng chiếu!!!");
                return;
            }
            if (DAO.CinemaDAO.SearchCinemaByID(txtCinemaID.Text.Trim()).Rows.Count == 0)
            {
                MessageBox.Show("Phòng(ID) cần sửa thông tin không có trong danh sách!!!");
                return;
            }
            if (txtCinemaName.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Tên phòng chiếu không được trống!!!");
                return;
            }
            if (txtCinemaSeats.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Số ghế không được trống!!!");
                return;
            }
            if (Regex.IsMatch(txtCinemaSeats.Text.Trim(), @"\D+") == true)
            {
                MessageBox.Show("Số ghế phải điền bằng số!!!");
                return;
            }
            if (txtNumberOfRows.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Số hàng ghế không được trống!!!");
                return;
            }
            if (Regex.IsMatch(txtNumberOfRows.Text.Trim(), @"\D+") == true)
            {
                MessageBox.Show("Số hàng ghế phải điền bằng số!!!");
                return;
            }
            if (txtSeatsPerRow.Text.Trim().Equals("") == true)
            {
                MessageBox.Show("Số ghế mỗi hàng không được trống!!!");
                return;
            }
            if (Regex.IsMatch(txtSeatsPerRow.Text.Trim(), @"\D+") == true)
            {
                MessageBox.Show("Số ghế mỗi hàng phải điền bằng số!!!");
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn sửa thông tin phòng này?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            string cinemaID = txtCinemaID.Text;
            string cinemaName = txtCinemaName.Text;
            string screenTypeID = cboCinemaScreenType.SelectedValue.ToString();
            int cinemaSeats = int.Parse(txtCinemaSeats.Text);
            int cinemaStatus;
            if (cboCinemaStatus.Text.Equals("Hoạt động") == true)
            {
                cinemaStatus = 1;
            }
            else
            {
                cinemaStatus = 0;
            }
            int numberOfRows = int.Parse(txtNumberOfRows.Text);
            int seatsPerRows = int.Parse(txtSeatsPerRow.Text);
            UpdateCinema(cinemaID, cinemaName, screenTypeID, cinemaSeats, cinemaStatus, numberOfRows, seatsPerRows);
            LoadCinemaList();
        }

        void DeleteCinema(string id)
        {
            if (CinemaDAO.DeleteCinema(id))
            {
                MessageBox.Show("Xóa phòng chiếu thành công");
            }
            else
            {
                MessageBox.Show("Xóa phòng chiếu thất bại");
            }
        }
        private void btnDeleteCinema_Click(object sender, EventArgs e)
        {
            if (CinemaDAO.SearchCinemaUsingInShowTime(txtCinemaID.Text.Trim()).Rows.Count > 0)
            {
                MessageBox.Show("Xóa lịch chiếu có chứa phòng chiếu này trước!!!");
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn xóa thông tin phòng này?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            string cinemaID = txtCinemaID.Text;
            DeleteCinema(cinemaID);
            LoadCinemaList();
        }

        private void btnShowCinema_Click(object sender, EventArgs e)
        {
            LoadCinemaList();
        }

        private void txtNumberOfRows_TextChanged(object sender, EventArgs e)
        {
            if ((txtSeatsPerRow.Text.Equals("") == true) || (txtNumberOfRows.Text.Equals("") == true))
                return;
            if ((Regex.IsMatch(txtNumberOfRows.Text.Trim(), @"\D+") == false) && (Regex.IsMatch(txtSeatsPerRow.Text.Trim(), @"\D+") == false))
            {
                int numberOfRows = int.Parse(txtNumberOfRows.Text.Trim());
                int seatsPerRows = int.Parse(txtSeatsPerRow.Text.Trim());
                txtCinemaSeats.Text = (numberOfRows * seatsPerRows).ToString();
                return;
            }
            else
            {
                return;
            }
        }

        private void txtSeatsPerRow_TextChanged(object sender, EventArgs e)
        {
            if ((txtSeatsPerRow.Text.Equals("") == true) || (txtNumberOfRows.Text.Equals("") == true))
                return;
            if ((Regex.IsMatch(txtSeatsPerRow.Text.Trim(), @"\D+") == false) && (Regex.IsMatch(txtNumberOfRows.Text.Trim(), @"\D+") == false))
            {
                int seatsPerRows = int.Parse(txtSeatsPerRow.Text.Trim());
                int numberOfRows = int.Parse(txtNumberOfRows.Text.Trim());
                txtCinemaSeats.Text = (numberOfRows * seatsPerRows).ToString();
                return;
            }
            else
            {
                return;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCinemaID.Text = "";
            txtCinemaName.Text = "";
            cboCinemaStatus.SelectedIndex = 0;
            txtNumberOfRows.Text = "0";
            txtSeatsPerRow.Text = "0";
            cboCinemaScreenType.SelectedIndex = 0;
        }
    }
}
