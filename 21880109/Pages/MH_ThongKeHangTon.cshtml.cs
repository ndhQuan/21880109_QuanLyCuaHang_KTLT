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
    public class MH_ThongKeHangTonModel : PageModel
    {
        public int TongTonKho { get; set; }
        public List<LoaiHang> dslh { get; set; }
        public List<MatHang> dsHangTonTheoLoai { get; set; }
        public int[] soLuongNhap { get; set; }
        public int[] soLuongBan { get; set; }
        public int[] soLuongTonKho { get; set; }
        [BindProperty]
        public string LoaiHang { get; set; }
        public void OnGet()
        {
            TongTonKho = 0;
            dslh = LuuTruLoaiHang.DocDanhSachLoaiHang();
            dsHangTonTheoLoai = XuLyMatHang.TimKiemHangTonTheoLoai(string.Empty);
            soLuongNhap = new int[dsHangTonTheoLoai.Count];   //Tạo mảng chứa số lượng nhập của từng mặt hàng
            soLuongBan = new int[dsHangTonTheoLoai.Count];   //Tạo mảng chứa số lượng bán của từng mặt hàng
            soLuongTonKho = new int[dsHangTonTheoLoai.Count];    //Tạo mảng chứa số lượng tồn của từng mặt hàng

            for (int i = 0; i < dsHangTonTheoLoai.Count; i++)
            {
                soLuongNhap[i] = XuLyMatHang.TongSoLuongNhap(dsHangTonTheoLoai[i].MaMH);
                soLuongBan[i] = XuLyMatHang.TongSoLuongBan(dsHangTonTheoLoai[i].MaMH);
                soLuongTonKho[i] = soLuongNhap[i] - soLuongBan[i];
                TongTonKho += soLuongTonKho[i];
            }

        }
        public void OnPost()
        {
            TongTonKho = 0;
            dslh = LuuTruLoaiHang.DocDanhSachLoaiHang();
            dsHangTonTheoLoai = XuLyMatHang.TimKiemHangTonTheoLoai(LoaiHang);
            soLuongNhap = new int[dsHangTonTheoLoai.Count];   //Tạo mảng chứa số lượng nhập của từng mặt hàng
            soLuongBan = new int[dsHangTonTheoLoai.Count];   //Tạo mảng chứa số lượng bán của từng mặt hàng
            soLuongTonKho = new int[dsHangTonTheoLoai.Count];    //Tạo mảng chứa số lượng tồn của từng mặt hàng

            for (int i = 0; i < dsHangTonTheoLoai.Count; i++)
            {
                soLuongNhap[i] = XuLyMatHang.TongSoLuongNhap(dsHangTonTheoLoai[i].MaMH);
                soLuongBan[i] = XuLyMatHang.TongSoLuongBan(dsHangTonTheoLoai[i].MaMH);
                soLuongTonKho[i] = soLuongNhap[i] - soLuongBan[i];
                TongTonKho += soLuongTonKho[i];
            }
        }
    }
}
