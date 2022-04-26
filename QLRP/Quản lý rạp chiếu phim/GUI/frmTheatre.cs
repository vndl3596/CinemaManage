using GUI.DAO;
using GUI.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;//thư viện thay đổi vùng/quốc gia
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmTheatre : Form
    {
        int SIZE = 30;//Size của ghế
        int GAP = 7;//Khoảng cách giữa các ghế

        List<Ticket> listSeat = new List<Ticket>();

        //dùng lưu vết các Ghế đang chọn
        List<Button> listSeatSelected = new List<Button>();

        float displayPrice = 0;//Hiện thị giá vé
        float ticketPrice = 0;//Lưu giá vé gốc
        float total = 0;//Tổng giá tiền
        float discount = 0;//Tiền được giảm
        float payment = 0;//Tiền phải trả
        int plusPoint = 0;//Số điểm tích lũy khi mua vé

        Customer customer;//lưu lại khách hàng thành viên
        Account staff;//người bán

        ShowTimes Times;
        Movie Movie;

        public frmTheatre(ShowTimes showTimes, Movie movie, Account account)
        {
            InitializeComponent();

            Times = showTimes;
            Movie = movie;
            staff = account;
        }

        private void frmTheatre_Load(object sender, EventArgs e)
        {
            ticketPrice = Times.TicketPrice;

            lblInformation.Text = "Pandora | " + Times.CinemaName + " | " + Times.MovieName;
            lblTime.Text = Times.Time.ToShortDateString() + " | "
                + Times.Time.ToShortTimeString() + " - "
                + Times.Time.AddMinutes(Movie.Time).ToShortTimeString();
            if (Movie.Poster != null)
                picFilm.Image = MovieDAO.byteArrayToImage(Movie.Poster);

            rdoAdult.Checked = true;
            chkCustomer.Enabled = false;
            grpLoaiVe.Enabled = false;
            lblStaff.Text = "Nhân viên: " + StaffDAO.SearchStaffNameByID(staff.StaffID).Rows[0]["HoTen"];

            LoadDataCinema(Times.CinemaName);

            ShowOrHideLablePoint();

            listSeat = TicketDAO.GetListTicketsByShowTimes(Times.ID);

            LoadSeats();
        }

        private void LoadDataCinema(string cinemaName)
        {
            Cinema cinema = CinemaDAO.GetCinemaByName(cinemaName);
            int Row = cinema.Row;
            int Column = cinema.SeatInRow;
            flpSeat.Size = new Size((SIZE + 20 + GAP) * Column, (SIZE + GAP) * Row);
        }

        private void LoadBill()
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            //Đổi culture vùng quốc gia để đổi đơn vị tiền tệ 

            //Thread.CurrentThread.CurrentCulture = culture;
            //dùng thread để chuyển cả luồng đang chạy về vùng quốc gia đó

            lblTicketPrice.Text = displayPrice.ToString("c", culture);
            lblTotal.Text = total.ToString("c", culture);
            lblDiscount.Text = discount.ToString("c", culture);
            lblPayment.Text = payment.ToString("c", culture);

            //Đổi đơn vị tiền tệ
            //gán culture chỗ này thì chỉ có chỗ này sd culture này còn
            //lại sài mặc định
        }

        private void LoadSeats()
        {
            flpSeat.Controls.Clear();
            int result = 0;
            Cinema cinema = CinemaDAO.GetCinemaByName(Times.CinemaName);
            int Row = cinema.Row;
            int Column = cinema.SeatInRow;
            for (int i = 0; i < Row; i++)
            {
                int temp = i + 65;
                char nameRow = (char)(temp);
                for (int j = 1; j <= Column; j++)
                {
                    Button btnSeat = new Button() { Width = SIZE + 20, Height = SIZE };
                    btnSeat.Text = nameRow.ToString() + j;
                    int check = 0;
                    for (int k = 0; k < TicketDAO.GetListTicketsByShowTimeID(Times.ID).Rows.Count; k++)
                    {
                        if (btnSeat.Text.Equals(TicketDAO.GetListTicketsByShowTimeID(Times.ID).Rows[k]["MaGheNgoi"].ToString()) == true)
                        {
                            check = 1;
                            break;
                        }
                    }
                    if (check == 1)
                    {
                        btnSeat.BackColor = Color.Red;
                    }
                    else
                    {
                        btnSeat.BackColor = Color.White;
                    }
                    btnSeat.Click += BtnSeat_Click;
                    result += 1;
                    flpSeat.Controls.Add(btnSeat);
                    Ticket tic = new Ticket();
                    btnSeat.Tag = tic;
                }
            }
            ShowTimesDAO.UpdateStatusShowTimes(Times.ID, 1);
        }

        private void BtnSeat_Click(object sender, EventArgs e)
        {
            Button btnSeat = sender as Button;
            if (btnSeat.BackColor == Color.White)
            {
                grpLoaiVe.Enabled = true;
                rdoAdult.Checked = true;

                btnSeat.BackColor = Color.Yellow;
                Ticket ticket = btnSeat.Tag as Ticket;

                ticket.Price = ticketPrice;
                displayPrice = ticket.Price;
                total += ticketPrice;
                payment = total - discount;
                ticket.Type = 1;

                listSeatSelected.Add(btnSeat);
                plusPoint++;
                lblPlusPoint.Text = plusPoint + "";
            }
            else if (btnSeat.BackColor == Color.Yellow)
            {
                btnSeat.BackColor = Color.White;
                Ticket ticket = btnSeat.Tag as Ticket;

                total -= ticket.Price;
                payment = total - discount;
                ticket.Price = 0;
                displayPrice = ticket.Price;
                ticket.Type = 0;

                listSeatSelected.Remove(btnSeat);
                plusPoint--;
                lblPlusPoint.Text = plusPoint + "";
                grpLoaiVe.Enabled = false;
            }
            else if (btnSeat.BackColor == Color.Red)
            {
                MessageBox.Show("Ghế số [" + btnSeat.Text + "] đã có người mua");
            }
            LoadBill();
            if (listSeatSelected.Count > 0)
            {
                chkCustomer.Enabled = true;
            }
            else
            {
                chkCustomer.Enabled = false;
            }
        }

        //dùng để ẩn hiện lable điểm tích lũy của khách hàng thành viên
        private void ShowOrHideLablePoint()
        {
            if (chkCustomer.Checked == true)
            {
                pnCustomer.Visible = true;
            }
            else
            {
                pnCustomer.Visible = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn hủy tất cả những vé đã chọn ko?",
                "Hủy Mua Vé", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            foreach (Button btn in listSeatSelected)
            {
                btn.BackColor = Color.White;
            }
            RestoreDefault();
        }

        private void RestoreDefault()
        {
            listSeatSelected.Clear();

            rdoAdult.Checked = true;
            grpLoaiVe.Enabled = false;
            chkCustomer.Checked = false;
            chkCustomer.Enabled = false;

            ShowOrHideLablePoint();

            total = 0;
            displayPrice = 0;
            discount = 0;
            payment = 0;
            plusPoint = 0;

            LoadBill();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (listSeatSelected.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn vé trước khi thanh toán!");
                return;
            }
            string message = "Bạn có chắc chắn mua những vé: \n";
            foreach (Button btn in listSeatSelected)
            {
                message += "[" + btn.Text + "] ";
            }
            message += "\nKhông?";
            DialogResult result = MessageBox.Show(message, "Hỏi Mua",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                int ret = 0;
                if (chkCustomer.Checked == true)
                {
                    foreach (Button btn in listSeatSelected)
                    {
                        Ticket ticket = btn.Tag as Ticket;

                        btn.BackColor = Color.Red;
                        //ret += TicketDAO.BuyTicket(ticket.ID, ticket.Type, customer.ID, ticket.Price, staff.StaffID);
                        ret += TicketDAO.InsertTicket(ticket.Type, Times.ID, btn.Text, customer.ID, 1, ticket.Price, staff.StaffID);
                    }
					customer.Point += plusPoint;
					CustomerDAO.UpdatePointCustomer(customer.ID, customer.Point);
                }
                else
                {
                    foreach (Button btn in listSeatSelected)
                    {
                        Ticket ticket = btn.Tag as Ticket;
                        btn.BackColor = Color.Red;

                        //ret += TicketDAO.BuyTicket(ticket.ID, ticket.Type, ticket.Price, staff.StaffID);
                        ret += TicketDAO.InsertTicket(ticket.Type, Times.ID, btn.Text, 1, ticket.Price, staff.StaffID);
                    }
                }
                if (ret == listSeatSelected.Count)
                {
                    MessageBox.Show("Bạn đã mua vé thành công!");
                }
            }
            RestoreDefault();
            //this.OnLoad(new EventArgs());
        }

        private void rdoStudent_Click(object sender, EventArgs e)
        {
            if (rdoStudent.Checked == true)
            {
                if (listSeatSelected.Count == 0) return;
                Ticket ticket = listSeatSelected[listSeatSelected.Count - 1].Tag as Ticket;
                ticket.Type = 2;

                float oldPrice = ticket.Price;
                ticket.Price = 0.8f * ticketPrice;
                displayPrice = ticket.Price;
                total = total + ticket.Price - oldPrice;
                payment = total - discount;

                LoadBill();
            }
        }

        private void rdoAdult_Click(object sender, EventArgs e)
        {
            if (rdoAdult.Checked == true)
            {
                if (listSeatSelected.Count == 0) return;
                Ticket ticket = listSeatSelected[listSeatSelected.Count - 1].Tag as Ticket;
                ticket.Type = 1;

                float oldPrice = ticket.Price;
                ticket.Price = ticketPrice;
                displayPrice = ticket.Price;
                total = total + ticket.Price - oldPrice;
                payment = total - discount;

                LoadBill();
            }
        }

        private void rdoChild_Click(object sender, EventArgs e)
        {
            if (rdoChild.Checked == true)
            {
                if (listSeatSelected.Count == 0) return;
                Ticket ticket = listSeatSelected[listSeatSelected.Count - 1].Tag as Ticket;
                ticket.Type = 3;

                float oldPrice = ticket.Price;
                ticket.Price = 0.7f * ticketPrice;
                displayPrice = ticket.Price;
                total = total + ticket.Price - oldPrice;
                payment = total - discount;

                LoadBill();
            }
        }

        private void chkCustomer_Click(object sender, EventArgs e)
        {
            if (chkCustomer.Checked == true)
            {
                frmCustomer frm = new frmCustomer();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    customer = frm.customer;
                    String[] n = customer.Name.Split(' ');
                    lblCustomerName.Text = n[n.Length -  2] + " " + n[n.Length - 1];
                    lblPoint.Text = customer.Point + "";
                    ShowOrHideLablePoint();
                }
                else
                {
                    chkCustomer.Checked = false;
                }
            }
            else
            {
                ShowOrHideLablePoint();
                customer = null;
            }
        }

        private void btnFreeTicket_Click(object sender, EventArgs e)
        {
            int freeTickets = (int)numericFreeTickets.Value;
            if (freeTickets <= 0) return;

            if (freeTickets > listSeat.Count)
            {
                MessageBox.Show("BẠN CHỈ ĐỔI ĐƯỢC TỐT ĐA [" + listSeatSelected.Count + "] VÉ", "THÔNG BÁO");
                return;
            }
            int pointFreeTicket = freeTickets * 20;
            if (customer.Point < pointFreeTicket)
            {
                MessageBox.Show("BẠN KHÔNG ĐỦ ĐIỂM TÍCH LŨY ĐỂ ĐỔI [" + freeTickets + "] VÉ", "THÔNG BÁO");
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("BẠN CÓ MUỐN DÙNG ĐIỂM TÍCH LŨY ĐỂ ĐỔI [" + freeTickets + "] VÉ MIỄN PHÍ KHÔNG?",
                                        "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    customer.Point -= pointFreeTicket;
                    plusPoint -= freeTickets;

                    if (CustomerDAO.UpdatePointCustomer(customer.ID, customer.Point))
                    {
                        MessageBox.Show("BẠN ĐÃ DỔI ĐƯỢC [" + freeTickets + "] VÉ MIỄN PHÍ THÀNH CÔNG", "THÔNG BÁO");
                        foreach (Button btn in listSeatSelected)
                        {
                            Ticket ticket = btn.Tag as Ticket;

                            //ret += TicketDAO.BuyTicket(ticket.ID, ticket.Type, customer.ID, ticket.Price, staff.StaffID);
                            TicketDAO.InsertTicket(ticket.Type, Times.ID, btn.Text, customer.ID, 1, 0, staff.StaffID);
                        }

                    }
                    lblPoint.Text = "" + customer.Point;
                    lblPlusPoint.Text = "" + plusPoint;

                    for (int i = 0; i < listSeatSelected.Count && freeTickets > 0; i++)
                    {
                        Ticket ticket = listSeatSelected[i].Tag as Ticket;
                        if (ticket.Price != 0)
                        {
                            discount += ticket.Price;
                            ticket.Price = 0;
                            freeTickets--;
                        }
                    }

                    payment = total - discount;
                    LoadBill();
                }
            }
            RestoreDefault();
            this.OnLoad(new EventArgs());
        }
    }
}
