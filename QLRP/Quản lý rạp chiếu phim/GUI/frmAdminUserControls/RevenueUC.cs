﻿using GUI.DAO;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace GUI.frmAdminUserControls
{
    public partial class RevenueUC : UserControl
    {
        public RevenueUC()
        {
            InitializeComponent();
            LoadRevenue();
        }
        void LoadRevenue()
        {
            LoadMovieIntoCombobox(cboSelectMovie);
            LoadDateTimePickerRevenue();//Set "Từ ngày" & "Đến ngày ngày" về đầu tháng & cuối tháng
            if (ShowTimesDAO.GetListShowtime().Rows.Count > 0)
            {
                LoadRevenue(cboSelectMovie.SelectedValue.ToString(), dtmFromDate.Value, dtmToDate.Value);
            }
        }
        void LoadMovieIntoCombobox(ComboBox comboBox)
        {
            comboBox.DataSource = MovieDAO.GetListMovie();
            comboBox.DisplayMember = "Name";
            comboBox.ValueMember = "ID";
        }
        void LoadDateTimePickerRevenue()
        {
            dtmFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtmToDate.Value = dtmFromDate.Value.AddMonths(1).AddDays(-1);
        }
        void LoadRevenue(string idMovie, DateTime fromDate, DateTime toDate)
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            dtgvRevenue.DataSource = RevenueDAO.GetRevenue(idMovie, fromDate, toDate);
            txtDoanhThu.Text = GetSumRevenue().ToString("c", culture);
        }
        decimal GetSumRevenue()
        {
            decimal sum = 0;
            foreach (DataGridViewRow row in dtgvRevenue.Rows)
            {
                sum += Convert.ToDecimal(row.Cells["Tiền vé"].Value);
            }
            return sum;
        }

        private void btnShowRevenue_Click(object sender, EventArgs e)
        {
            if(dtmFromDate.Value.CompareTo(dtmToDate.Value) > 0)
            {
                MessageBox.Show("Ngày bắt đầu tính doanh thu không thể trễ hơn ngày kết thúc!!!");
                return;
            }
            LoadRevenue(cboSelectMovie.SelectedValue.ToString(), dtmFromDate.Value, dtmToDate.Value);
        }

        private void btnReportRevenue_Click(object sender, EventArgs e)
        {
            if (dtmFromDate.Value.CompareTo(dtmToDate.Value) > 0)
            {
                MessageBox.Show("Ngày bắt đầu báo cáo doanh thu không thể trễ hơn ngày kết thúc!!!");
                return;
            }
            frmReport frm = new frmReport(cboSelectMovie.SelectedValue.ToString(), dtmFromDate.Value, dtmToDate.Value);
            frm.ShowDialog();
        }

        private void dtmToDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtmFromDate.Value.CompareTo(dtmToDate.Value) > 0)
            {
                MessageBox.Show("Ngày bắt đầu báo cáo doanh thu không thể trễ hơn ngày kết thúc!!!");
                return;
            }
        }

        private void cboSelectMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRevenue(cboSelectMovie.SelectedValue.ToString(), dtmFromDate.Value, dtmToDate.Value);
        }
    }
}
