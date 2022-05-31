using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _21880109.Entities;
using _21880109.DAL;

namespace _21880109.Services
{
    public class XuLyMatHang
    {
        public static bool ThemMatHang(MatHang m)
        {
            if(string.IsNullOrWhiteSpace(m.MaMH)||
                string.IsNullOrWhiteSpace(m.TenMH) ||
                string.IsNullOrWhiteSpace(m.CtySX) ||
                string.IsNullOrWhiteSpace(m.HanDung) ||
                string.IsNullOrWhiteSpace(m.NgaySX) ||
                string.IsNullOrWhiteSpace(m.LoaiHang) ||
                m.Gia <= 0)
            {
                return false;
            }
            return LuuTruMatHang.LuuMatHang(m);
        }
        public static List<MatHang> TimKiemMatHang(string tukhoa, string theloai)
        {
            if(tukhoa == null)
            {
                tukhoa = string.Empty;
            }
            List<MatHang> dsMH = LuuTruMatHang.DocDanhSachMatHang();
            List<MatHang> kq = new List<MatHang>();

            foreach (MatHang m in dsMH)
            {
                if (theloai == "TenMatHang" && m.TenMH.Contains(tukhoa))
                {
                    kq.Add(m);
                }
                else if(theloai == "MaMatHang" && m.MaMH.Contains(tukhoa))
                {
                    kq.Add(m);
                }
                else if (theloai == "LoaiHang" && m.LoaiHang.Contains(tukhoa))
                {
                    kq.Add(m);
                }
                else if (theloai == "CtySX" && m.CtySX.Contains(tukhoa))
                {
                    kq.Add(m);
                }
                else if (m.TenMH.Contains(tukhoa))
                {
                    kq.Add(m);
                }
            }
            return kq;
        }
        public static MatHang? DocMatHang(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            List<MatHang> dssp = LuuTruMatHang.DocDanhSachMatHang();
            foreach (MatHang sp in dssp)
            {
                if (sp.MaMH == id)
                {
                    return sp;
                }
            }
            return null;
        }
        public static bool SuaMatHang(string id, string ten, string handung, string ctysx, string ngaysx, string loaihang, int gia)
        {
            if (string.IsNullOrWhiteSpace(ten) ||
                string.IsNullOrWhiteSpace(id) ||
                string.IsNullOrWhiteSpace(handung) ||
                string.IsNullOrWhiteSpace(ctysx) ||
                string.IsNullOrWhiteSpace(ngaysx) ||
                string.IsNullOrWhiteSpace(loaihang) ||
                gia <= 0)
            {
                return false;
            }

            MatHang? sp = DocMatHang(id);
            if (sp != null)
            {
                MatHang spmoi;
                spmoi.MaMH = id;
                spmoi.TenMH = ten;
                spmoi.HanDung = handung;
                spmoi.CtySX = ctysx;
                spmoi.NgaySX = ngaysx;
                spmoi.LoaiHang = loaihang;
                spmoi.Gia = gia;
                LuuTruMatHang.SuaMatHang(spmoi);
            }
            return false;
        }
        public static bool XoaMatHang(string Id)
        {
            if (string.IsNullOrWhiteSpace(Id))
            {
                return false;
            }
            return LuuTruMatHang.XoaMatHang(Id);
        }
        public static int TongSoLuongNhap(string maMatHang)
        {
            int tongSoLuongNhap = 0;
            List<HoaDon> dshdNhap = LuuTruHoaDon.DocDanhSachHoaDonNhapHang();
            foreach(HoaDon h in dshdNhap)
            {
                foreach(ChiTietHoaDon ct in h.ChiTiet)
                {
                    if(ct.MaMatHang == maMatHang)
                    {
                        tongSoLuongNhap += ct.SoLuong;
                    }
                }
            }
            return tongSoLuongNhap;
        }
        public static int TongSoLuongBan(string maMatHang)
        {
            int tongSoLuongBan = 0;
            List<HoaDon> dshdBan = LuuTruHoaDon.DocDanhSachHoaDonBanHang();
            foreach (HoaDon h in dshdBan)
            {
                foreach (ChiTietHoaDon ct in h.ChiTiet)
                {
                    if (ct.MaMatHang == maMatHang)
                    {
                        tongSoLuongBan += ct.SoLuong;
                    }
                }
            }
            return tongSoLuongBan;
        }
        public static DateTime convertToDateTime(string time)
        {
            string[] m = time.Split("-",StringSplitOptions.RemoveEmptyEntries);
            int year = int.Parse(m[0]);
            int month = int.Parse(m[1]);
            int day = int.Parse(m[2]);
            DateTime t = new DateTime(year,month,day);
            return t;
        }
        public static List<MatHang> ThongKeHetHan()
        {
            List<MatHang> dsmh = LuuTruMatHang.DocDanhSachMatHang();
            List<MatHang> danhSachHetHan = new List<MatHang>();
            for(int i=0; i < dsmh.Count; i++)
            {
                DateTime NgayHetHan = convertToDateTime(dsmh[i].HanDung);
                int compare = DateTime.Compare(DateTime.Now, NgayHetHan);
                if(compare >= 0)
                {
                    danhSachHetHan.Add(dsmh[i]);
                }
            }
            return danhSachHetHan;
        }
        public static List<string> HoaDonChuaMatHang(string Id)
        {
            List<HoaDon> dshdNhap = LuuTruHoaDon.DocDanhSachHoaDonNhapHang();
            List<HoaDon> dshdBan = LuuTruHoaDon.DocDanhSachHoaDonBanHang();
            List<string> MaHoaDon = new List<string>();
            

            for (int i = 0; i< dshdNhap.Count; i++)
            {
                foreach(ChiTietHoaDon ct in dshdNhap[i].ChiTiet)
                {
                    if (ct.MaMatHang == Id)
                    {
                        MaHoaDon.Add(dshdNhap[i].MaHoaDon);
                    }
                }
                
            }
            for (int i = 0; i < dshdBan.Count; i++)
            {
                foreach (ChiTietHoaDon ct in dshdBan[i].ChiTiet)
                {
                    if (ct.MaMatHang == Id)
                    {
                        MaHoaDon.Add(dshdBan[i].MaHoaDon);
                    }
                }
            }
            return MaHoaDon;
        }
        public static List<MatHang> TimKiemHangTonTheoLoai(string LoaiHang)
        {
            if (LoaiHang == null) LoaiHang = string.Empty;
            List<MatHang> dsmh = LuuTruMatHang.DocDanhSachMatHang();
            List<MatHang> dsTonTheoLoai = new List<MatHang>();
            foreach(MatHang mh in dsmh)
            {
                if (mh.LoaiHang.Contains(LoaiHang))
                {
                    dsTonTheoLoai.Add(mh);
                }
            }
            return dsTonTheoLoai;
        }
    }
}
