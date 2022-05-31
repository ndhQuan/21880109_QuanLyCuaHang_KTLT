using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _21880109.Entities;
using _21880109.DAL;

namespace _21880109.Services
{
    public class XuLyLoaiHang
    {
        public static bool ThemLoaiHang(LoaiHang lh)
        {
            if (string.IsNullOrWhiteSpace(lh.MaLoaiHang) ||
                string.IsNullOrWhiteSpace(lh.TenLoaiHang)
                )
            {
                return false;
            }
            return LuuTruLoaiHang.LuuLoaiHang(lh);
        }
        public static List<LoaiHang> TimKiemLoaiHang(string tukhoa, string theloai)
        {
            if (tukhoa == null)
            {
                tukhoa = string.Empty;
            }
            List<LoaiHang> dsLoaiHang = LuuTruLoaiHang.DocDanhSachLoaiHang();
            List<LoaiHang> kq = new List<LoaiHang>();

            foreach (LoaiHang m in dsLoaiHang)
            {
                if (theloai == "MaLoaiHang" && m.MaLoaiHang.Contains(tukhoa))
                {
                    kq.Add(m);
                }
                else if (theloai == "TenLoaiHang" && m.TenLoaiHang.Contains(tukhoa))
                {
                    kq.Add(m);
                }
                else if (m.TenLoaiHang.Contains(tukhoa))
                {
                    kq.Add(m);
                }

            }
            return kq;
        }
        public static LoaiHang? DocLoaiHang(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            List<LoaiHang> dslh = LuuTruLoaiHang.DocDanhSachLoaiHang();
            foreach (LoaiHang lh in dslh)
            {
                if (lh.MaLoaiHang == id)
                {
                    return lh;
                }
            }
            return null;
        }
        public static bool SuaLoaiHang(string id, string ten)
        {
            if (string.IsNullOrWhiteSpace(ten) ||
                string.IsNullOrWhiteSpace(id) 
                )
            {
                return false;
            }

            LoaiHang? lh = DocLoaiHang(id);
            if (lh != null)
            {
                LoaiHang lhmoi;
                lhmoi.MaLoaiHang = id;
                lhmoi.TenLoaiHang = ten;
                LuuTruLoaiHang.SuaLoaiHang(lhmoi);
            }
            return false;
        }
        public static bool XoaLoaiHang(string Id)
        {
            if (string.IsNullOrWhiteSpace(Id))
            {
                return false;
            }
            return LuuTruLoaiHang.XoaLoaiHang(Id);
        }

    }
}
