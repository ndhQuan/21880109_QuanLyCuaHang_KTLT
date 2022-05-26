using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _21880109.Entities;
using _21880109.DAL;

namespace _21880109.Services
{
    public class XuLyHoaDon
    {
        public static string ThemTenMatHang(string MaMatHang)
        {
            List<MatHang> dsmh = LuuTruMatHang.DocDanhSachMatHang();
            foreach(MatHang h in dsmh)
            {
                if(h.MaMH == MaMatHang)
                {
                    return h.TenMH;
                }
            }
            return " ";
        }
        public static bool TaoHoaDonNhapHang(HoaDon h)
        {
            List<HoaDon> dshdn = LuuTruHoaDon.DocDanhSachHoaDonNhapHang();
            foreach(HoaDon a in dshdn)
            {
                if (h.MaHoaDon == a.MaHoaDon)
                    return false;
            }
            if (string.IsNullOrWhiteSpace(h.MaHoaDon) ||
               string.IsNullOrWhiteSpace(h.NgayTaoHoaDon)
               )
            {
                return false;
            }
            LuuTruHoaDon.LuuHoaDonNhapHang(h);
            return true;
        }
        public static bool SuaHoaDonNhapHang(HoaDon h)
        {
            List<HoaDon> dshdn = LuuTruHoaDon.DocDanhSachHoaDonNhapHang();
            foreach(HoaDon a in dshdn)
            {
                if(a.MaHoaDon == h.MaHoaDon)
                {
                    for(int i=0; i < a.ChiTiet.Count; i++)
                    {
                        a.ChiTiet[i] = h.ChiTiet[i];
                    }
                    LuuTruHoaDon.SuaHoaDonNhap(a);
                }
            }
            return false;
        }
        public static List<HoaDon> TimKiemHoaDonNhapHang(string tuKhoa, string target)
        {
            if (tuKhoa == null) 
            { 
                tuKhoa = string.Empty;
            }

            List<HoaDon> dshdn = LuuTruHoaDon.DocDanhSachHoaDonNhapHang();
            List<HoaDon> kq = new List<HoaDon>();
            foreach(HoaDon h in dshdn)
            {
                if (target == "MaHoaDon" && h.MaHoaDon.Contains(tuKhoa))
                {
                    kq.Add(h);
                }
                if (target == "NgayTao" && h.NgayTaoHoaDon.Contains(tuKhoa))
                {
                    kq.Add(h);
                }
            }
            return kq;
        }
        public static bool TaoHoaDonBanHang(HoaDon h)
        {
            if (string.IsNullOrWhiteSpace(h.MaHoaDon) ||
               string.IsNullOrWhiteSpace(h.NgayTaoHoaDon)
               )
            {
                return false;
            }
            LuuTruHoaDon.LuuHoaDonBanHang(h);
            return true;
        }
        public static List<HoaDon> TimKiemHoaDonBanHang(string tuKhoa, string target)
        {
            if (tuKhoa == null)
            {
                tuKhoa = string.Empty;
            }

            List<HoaDon> dshdn = LuuTruHoaDon.DocDanhSachHoaDonBanHang();
            List<HoaDon> kq = new List<HoaDon>();
            foreach (HoaDon h in dshdn)
            {
                if (target == "MaHoaDon" && h.MaHoaDon.Contains(tuKhoa))
                {
                    kq.Add(h);
                }
                if (target == "NgayTao" && h.NgayTaoHoaDon.Contains(tuKhoa))
                {
                    kq.Add(h);
                }
            }
            return kq;
        }
        public static bool XoaHoaDonNhap(string Id)
        {
            if (string.IsNullOrEmpty(Id)) return false;
            List<HoaDon> dshdn = LuuTruHoaDon.DocDanhSachHoaDonNhapHang();
            for(int i = 0; i < dshdn.Count; i++)
            {
                if(dshdn[i].MaHoaDon == Id)
                {
                    dshdn.RemoveAt(i);
                    LuuTruHoaDon.LuuDanhSachHoaDonNhapHang(dshdn);
                    return true;
                }
            }
            return false;
        }
        public static HoaDon? DocHoaDonNhap(string Id)
        {
            if (string.IsNullOrEmpty(Id)) return null;

            List<HoaDon> dshdn = LuuTruHoaDon.DocDanhSachHoaDonNhapHang();
            foreach (HoaDon h in dshdn)
            {
                if (h.MaHoaDon == Id)
                {
                    return h;
                }
            }
            return null;
        }
        public static int ThemDonGiaMatHang(string MaMatHang)
        {
            List<MatHang> dsmh = LuuTruMatHang.DocDanhSachMatHang();
            for(int i = 0; i < dsmh.Count; i++)
            {
                if(MaMatHang == dsmh[i].MaMH)
                {
                    return dsmh[i].Gia;
                }
            }
            return 0;
        }
        public static bool XoaHoaDonBan(string Id)
        {
            if (string.IsNullOrEmpty(Id)) return false;
            List<HoaDon> dshdb = LuuTruHoaDon.DocDanhSachHoaDonBanHang();
            for (int i = 0; i < dshdb.Count; i++)
            {
                if (dshdb[i].MaHoaDon == Id)
                {
                    dshdb.RemoveAt(i);
                    LuuTruHoaDon.LuuDanhSachHoaDonBanHang(dshdb);
                    return true;
                }
            }
            return false;
        }
        public static HoaDon? DocHoaDonBan(string Id)
        {
            if (string.IsNullOrEmpty(Id)) return null;

            List<HoaDon> dshdb = LuuTruHoaDon.DocDanhSachHoaDonBanHang();
            foreach (HoaDon h in dshdb)
            {
                if (h.MaHoaDon == Id)
                {
                    return h;
                }
            }
            return null;
        }
        public static bool SuaHoaDonBanHang(HoaDon h)
        {
            List<HoaDon> dshdb = LuuTruHoaDon.DocDanhSachHoaDonBanHang();
            foreach (HoaDon a in dshdb)
            {
                if (a.MaHoaDon == h.MaHoaDon)
                {
                    for (int i = 0; i < a.ChiTiet.Count; i++)
                    {
                        a.ChiTiet[i] = h.ChiTiet[i];
                    }
                    return LuuTruHoaDon.SuaHoaDonBan(a);
                }
            }
            return false;
        }

    }
}
