using GUI.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GUI.DAO
{
    public class StaffDAO
    {
		public static Staff GetStaffByID(string id)
		{
			Staff staff = null;
			DataTable data = DataProvider.ExecuteQuery("SELECT * FROM dbo.NhanVien WHERE id = '" + id + "'");
			foreach (DataRow item in data.Rows)
			{
				staff = new Staff(item);
				return staff;
			}
			return staff;
		}

		public static List<Staff> GetStaff()
		{
			List<Staff> staffList = new List<Staff>();
			DataTable data = DataProvider.ExecuteQuery("SELECT * FROM dbo.NhanVien");
			foreach (DataRow item in data.Rows)
			{
				Staff staff = new Staff(item);
				staffList.Add(staff);
			}
			return staffList;
		}

        public static DataTable GetListStaff()
        {
            return DataProvider.ExecuteQuery("EXEC USP_GetStaff");
        }

        public static bool InsertStaff(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, string cmnd)
        {
            hoTen = DAO.CustomerDAO.ChuanHoaHoTen(hoTen);
            int result = DataProvider.ExecuteNonQuery("EXEC USP_InsertStaff @idStaff , @hoTen , @ngaySinh , @diaChi , @sdt , @cmnd ", new object[] { id, hoTen, ngaySinh, diaChi, sdt, cmnd });
            return result > 0;
        }

        public static bool UpdateStaff(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, string cmnd)
        {
            hoTen = DAO.CustomerDAO.ChuanHoaHoTen(hoTen);
            string birth = ngaySinh.Day + "/" + ngaySinh.Month + "/" + ngaySinh.Year;
            string command = string.Format("UPDATE dbo.NhanVien SET HoTen = N'{0}', NgaySinh = CONVERT(Date, '{1}', 103), DiaChi = N'{2}', SDT = '{3}', CMND = N'{4}' WHERE id = '{5}'", hoTen, birth, diaChi, sdt, cmnd, id);
            int result = DataProvider.ExecuteNonQuery(command);
            return result > 0;
        }

        public static bool DeleteStaff(string id)
        {
            AccountDAO.DeleteAccountByIdStaff(id);
            int result = DataProvider.ExecuteNonQuery("DELETE dbo.NhanVien WHERE id = '" + id + "'");
            return result > 0;
        }

        public static DataTable SearchStaffByID(string id)
        {
            return DataProvider.ExecuteQuery("SELECT * FROM dbo.NhanVien WHERE id = '" + id + "'");
        }

        public static DataTable SearchStaffByINumber(string cMND)
        {
            return DataProvider.ExecuteQuery("SELECT * FROM dbo.NhanVien WHERE CMND = '" + cMND + "'");
        }

        public static DataTable SearchStaffByAccount(string account)
        {
            return DataProvider.ExecuteQuery("SELECT NhanVien.HoTen FROM dbo.NhanVien, dbo.TaiKhoan WHERE TaiKhoan.Username = '" + account + "' AND TaiKhoan.idNV = NhanVien.id");
        }

        public static DataTable SearchStaffIDNumberByID(string id)
        {
            return DataProvider.ExecuteQuery("SELECT CMND FROM dbo.NhanVien WHERE id = '" + id + "'");
        }

        public static DataTable SearchStaffByName(string name)
        {
            //List<Staff> searchList = new List<Staff>();
            //DataTable data = DataProvider.ExecuteQuery("SELECT * FROM dbo.NhanVien WHERE HoTen = N'" + name + "'");
            DataTable data = DataProvider.ExecuteQuery("EXEC USP_SearchStaff @hoTen", new object[] { name });
            //foreach (DataRow item in data.Rows)
            //{
            //	Staff staff = new Staff(item);
            //	searchList.Add(staff);
            //}
            return data;
            //TODO : Giải quyết trường hợp đang được comment
        }
        public static DataTable SearchStaffNameByID(string id)
        {
            return DataProvider.ExecuteQuery("SELECT HoTen FROM dbo.NhanVien WHERE id = '" + id + "'");
        }
    }
}