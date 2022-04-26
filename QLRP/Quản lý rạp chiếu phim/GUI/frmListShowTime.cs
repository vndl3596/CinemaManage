using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.DAO;
using GUI.DTO;

namespace GUI
{
    public partial class frmListShowTime : Form
    {
        BindingSource showtimeList = new BindingSource();
        public frmListShowTime()
        {
            InitializeComponent();
            LoadShowTime();
        }
        void LoadShowTime()
        {
            dtgvShowTime.DataSource = showtimeList;
            LoadShowTimeList();
        }

        void LoadShowTimeList()
        {
            showtimeList.DataSource = ShowTimesDAO.GetListShowTimeAndLength();
        }
    }
}
