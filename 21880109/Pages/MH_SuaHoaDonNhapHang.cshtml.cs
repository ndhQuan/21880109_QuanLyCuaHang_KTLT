using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using _21880109.Entities;
using _21880109.Services;
using _21880109.DAL;

namespace _21880109.Pages
{
    public class MH_SuaHoaDonNhapHangModel : PageModel
    {
        public string Chuoi;
        public HoaDon HoaDonNhap;
        [BindProperty(SupportsGet =true)]
        public string Id { get; set; }
        [BindProperty]
        public string NgayTao { get; set; }

        [BindProperty]
        public string MaMatHang1 { get; set; }
        [BindProperty]
        public int SoLuong1 { get; set; }
        [BindProperty]
        public int DonGia1 { get; set; }

        [BindProperty]
        public string MaMatHang2 { get; set; }
        [BindProperty]
        public int SoLuong2 { get; set; }
        [BindProperty]
        public int DonGia2 { get; set; }

        [BindProperty]
        public string MaMatHang3 { get; set; }
        [BindProperty]
        public int SoLuong3 { get; set; }
        [BindProperty]
        public int DonGia3 { get; set; }

        [BindProperty]
        public string MaMatHang4 { get; set; }
        [BindProperty]
        public int SoLuong4 { get; set; }
        [BindProperty]
        public int DonGia4 { get; set; }

        [BindProperty]
        public string MaMatHang5 { get; set; }
        [BindProperty]
        public int SoLuong5 { get; set; }
        [BindProperty]
        public int DonGia5 { get; set; }

        public void OnGet()
        {
            Chuoi = string.Empty;
            HoaDon? h = XuLyHoaDon.DocHoaDonNhap(Id);
            if (h != null)
            {
                HoaDonNhap = h.Value;
            }
        }
        public void OnPost()
        {
            string[] MaMatHang = { MaMatHang1, MaMatHang2, MaMatHang3, MaMatHang4, MaMatHang5 };
            int[] SoLuong = { SoLuong1, SoLuong2, SoLuong3, SoLuong4, SoLuong5 };
            int[] DonGia = { DonGia1, DonGia2, DonGia3, DonGia4, DonGia5 };
            ChiTietHoaDon[] a = new ChiTietHoaDon[5];
            for (int i = 0; i < 5; i++)
            {
                a[i].MaMatHang = MaMatHang[i];
                a[i].TenMatHang = XuLyHoaDon.ThemTenMatHang(a[i].MaMatHang);
                a[i].SoLuong = SoLuong[i];
                a[i].DonGia = DonGia[i];
            }
            HoaDonNhap.MaHoaDon = Id;
            HoaDonNhap.NgayTaoHoaDon = NgayTao;
            HoaDonNhap.ChiTiet = a.ToList();
            bool kq = XuLyHoaDon.SuaHoaDonNhapHang(HoaDonNhap);
            Chuoi = $"Ket qua la {kq}";
        }
    }
}
