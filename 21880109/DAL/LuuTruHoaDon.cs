using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using _21880109.Entities;
using Newtonsoft.Json;

namespace _21880109.DAL
{
    public class LuuTruHoaDon
    {
        #region Hóa đơn nhập hàng
        public static bool LuuHoaDonNhapHang(HoaDon h)
        {
            List<HoaDon> danhSachHoaDon = DocDanhSachHoaDonNhapHang();
            danhSachHoaDon.Add(h);
            LuuDanhSachHoaDonNhapHang(danhSachHoaDon);
            return true;
        }
        public static List<HoaDon> DocDanhSachHoaDonNhapHang()
        {
            string myDir = Environment.CurrentDirectory;
            StreamReader reader = new StreamReader($"{myDir}\\DS_HoaDonNhapHang.json");
            string jsonString = reader.ReadToEnd();
            reader.Close();

            List<HoaDon> danhSachHoaDon = JsonConvert.DeserializeObject<List<HoaDon>>(jsonString);
            return danhSachHoaDon;
        }
        public static bool LuuDanhSachHoaDonNhapHang(List<HoaDon> dsHoaDon)
        {
            string myDir = Environment.CurrentDirectory;
            StreamWriter writer = new StreamWriter($"{myDir}\\DS_HoaDonNhapHang.json");

            string jsonString = JsonConvert.SerializeObject(dsHoaDon);
            writer.Write(jsonString);
            writer.Close();
            return true;
        }
        public static bool SuaHoaDonNhap(HoaDon h)
        {
            List<HoaDon> dshdn = DocDanhSachHoaDonNhapHang();
            for(int i = 0; i < dshdn.Count; i++)
            {
                if(dshdn[i].MaHoaDon == h.MaHoaDon)
                {
                    dshdn[i] = h;
                    LuuDanhSachHoaDonNhapHang(dshdn);
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Hóa đơn bán hàng
        public static bool LuuHoaDonBanHang(HoaDon h)
        {
            List<HoaDon> danhSachHoaDon = DocDanhSachHoaDonBanHang();
            danhSachHoaDon.Add(h);
            LuuDanhSachHoaDonBanHang(danhSachHoaDon);
            return true;
        }
        public static List<HoaDon> DocDanhSachHoaDonBanHang()
        {
            string myDir = Environment.CurrentDirectory;
            StreamReader reader = new StreamReader($"{myDir}\\DS_HoaDonBanHang.json");
            string jsonString = reader.ReadToEnd();
            reader.Close();

            List<HoaDon> danhSachHoaDon = JsonConvert.DeserializeObject<List<HoaDon>>(jsonString);
            return danhSachHoaDon;
        }
        public static bool LuuDanhSachHoaDonBanHang(List<HoaDon> dsHoaDon)
        {
            string myDir = Environment.CurrentDirectory;
            StreamWriter writer = new StreamWriter($"{myDir}\\DS_HoaDonBanHang.json");

            string jsonString = JsonConvert.SerializeObject(dsHoaDon);
            writer.Write(jsonString);
            writer.Close();
            return true;
        }
        public static bool SuaHoaDonBan(HoaDon h)
        {
            List<HoaDon> dshdb = DocDanhSachHoaDonBanHang();
            for (int i = 0; i < dshdb.Count; i++)
            {
                if (dshdb[i].MaHoaDon == h.MaHoaDon)
                {
                    dshdb[i] = h;
                    LuuDanhSachHoaDonBanHang(dshdb);
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}
