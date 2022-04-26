using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmReport : Form
    {
        DataSet dataSet;
        SqlDataAdapter adapter = null;
        SqlConnection connection = null;
        string connectionSTR = Properties.Settings.Default.connectionSTR;

        string movieID;
        DateTime FromDate;
        DateTime ToDate;
        public frmReport(string idMovie, DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            movieID = idMovie;
            FromDate = fromDate;
            ToDate = toDate;
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            LoadRevenue(movieID, FromDate, ToDate);
            this.rpViewer.RefreshReport();
        }

        void LoadRevenue(string idMovie, DateTime fromDate, DateTime toDate)
        {
            if (connection == null)
                connection = new SqlConnection(connectionSTR);
            adapter = new SqlDataAdapter("USP_GetReportRevenueByMovieAndDate @idMovie, @fromDate, @toDate", connection);
            adapter.SelectCommand.Parameters.Add("@idMovie", SqlDbType.VarChar).Value = idMovie;
            adapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.Date).Value = fromDate;
            adapter.SelectCommand.Parameters.Add("@toDate", SqlDbType.Date).Value = toDate;


            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

            dataSet = new DataSet();
            adapter.Fill(dataSet, "DOANHTHU");

            this.rpViewer.LocalReport.ReportEmbeddedResource = "GUI.Report.rdlc";
            this.rpViewer.RefreshReport();

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSetRevenue";
            rds.Value = dataSet.Tables[0];
            this.rpViewer.LocalReport.DataSources.Add(rds);

            //set parameter cho report
            ReportParameter[] reportParameter = new ReportParameter[2];
            reportParameter[0] = new ReportParameter("FromDate");
            reportParameter[0].Values.Add(FromDate.ToShortDateString());
            reportParameter[1] = new ReportParameter("ToDate");
            reportParameter[1].Values.Add(ToDate.ToShortDateString());

            this.rpViewer.LocalReport.SetParameters(reportParameter);
        }
    }
}
