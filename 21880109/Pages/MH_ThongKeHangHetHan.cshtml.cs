using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using _21880109.Entities;
using _21880109.Services;

namespace _21880109.Pages
{
    public class MH_ThongKeHangHetHanModel : PageModel
    {
        public List<MatHang> dsmhHetHan { get; set; }
        public int[] soLuongTonKho { get; set; }
        public void OnGet()
        {
            dsmhHetHan = XuLyMatHang.ThongKeHetHan();
            int[] soLuongNhap = new int[dsmhHetHan.Count];
            int[] soLuongBan = new int[dsmhHetHan.Count];
            soLuongTonKho = new int[dsmhHetHan.Count];
            for (int i = 0; i < dsmhHetHan.Count; i++)
            {
                soLuongNhap[i] = XuLyMatHang.TongSoLuongNhap(dsmhHetHan[i].MaMH);
                soLuongBan[i] = XuLyMatHang.TongSoLuongBan(dsmhHetHan[i].MaMH);
                soLuongTonKho[i] = soLuongNhap[i] - soLuongBan[i];
            }

        }
    }
}
