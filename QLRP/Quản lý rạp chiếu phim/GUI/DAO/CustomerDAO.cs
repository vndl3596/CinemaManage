using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

namespace GUI.DAO
{
    public class CustomerDAO
    {
        public static DataTable GetCustomerMember(string customerID, string name)
        {
            string query = "Select * from KhachHang where id = '" + customerID + "' and HoTen = N'" + name + "'";
            return DataProvider.ExecuteQuery(query);
        }

        public static DataTable GetListCustomer()
        {
            return DataProvider.ExecuteQuery("EXEC USP_GetCustomer");
        }

        public static DataTable GetListCustomerIDByName(String hoTen)
        {
            return DataProvider.ExecuteQuery("SELECT id AS [Mã khách hàng] , HoTen AS [Họ tên] FROM dbo.KhachHang WHERE HoTen = '" + hoTen + "'");
        }

        public static DataTable GetListCustomerIDAndName()
        {
            return DataProvider.ExecuteQuery("SELECT id AS [Mã khách hàng] , HoTen AS [Họ tên] FROM dbo.KhachHang");
        }

        public static bool InsertCustomer(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, string cmnd)
        {
            hoTen = ChuanHoaHoTen(hoTen);
            int result = DataProvider.ExecuteNonQuery("EXEC USP_InsertCustomer @idCus , @hoTen , @ngaySinh , @diaChi , @sdt , @cmnd ", new object[] { id, hoTen, ngaySinh, diaChi, sdt, cmnd });
            return result > 0;
        }

        public static bool UpdateCustomer(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, string cmnd, int point)
        {
            hoTen = ChuanHoaHoTen(hoTen);
            string birth = ngaySinh.Day + "/" + ngaySinh.Month + "/" + ngaySinh.Year;
            string command = string.Format("UPDATE dbo.KhachHang SET HoTen = N'{0}', NgaySinh = CONVERT(Date, '{1}', 103), DiaChi = N'{2}', SDT = '{3}', CMND = {4}, DiemTichLuy = {5} WHERE id = '{6}'", hoTen, birth, diaChi, sdt, cmnd, point, id);
            int result = DataProvider.ExecuteNonQuery(command);
            return result > 0;
        }

        public static bool UpdatePointCustomer(string id, int point)
        {
            string command = string.Format("UPDATE dbo.KhachHang SET  DiemTichLuy = {0} WHERE id = '{1}'", point, id);
            int result = DataProvider.ExecuteNonQuery(command);
            return result > 0;
        }

        public static bool DeleteCustomer(string id)
        {
            int result = DataProvider.ExecuteNonQuery("DELETE dbo.KhachHang WHERE id = '" + id + "'");
            return result > 0;
        }

        public static DataTable SearchCustomerByName(string name)
        {
            return DataProvider.ExecuteQuery("EXEC USP_SearchCustomer @hoTen", new object[] { name });
        }

        public static DataTable SearchCustomerByID(string id)
        {
            return DataProvider.ExecuteQuery("SELECT * FROM dbo.KhachHang WHERE id = '" + id + "'");
        }
        public static DataTable SearchCustomerByINumber(string cMND)
        {
            return DataProvider.ExecuteQuery("SELECT * FROM dbo.KhachHang WHERE CMND = '" + cMND + "'");
        }
        public static DataTable SearchCustomerIDNumberByID(string id)
        {
            return DataProvider.ExecuteQuery("SELECT CMND FROM dbo.KhachHang WHERE id = '" + id + "'");
        }

        public static string ChuanHoaHoTen(string fullName)
        {
            fullName = fullName.Trim();
            while (fullName.IndexOf("  ") != -1)
            {
                fullName = fullName.Replace("  ", " ");
            }
            string[] SubName = fullName.Split(' ');
            fullName = "";

            for (int i = 0; i < SubName.Length; i++)
            {
                string FirstChar = SubName[i].Substring(0, 1);
                string OtherChar = SubName[i].Substring(1);
                SubName[i] = FirstChar.ToUpper() + OtherChar.ToLower();
                fullName += SubName[i] + " ";
            }
            fullName = fullName.Trim();
            return fullName;
        }
    }
}
