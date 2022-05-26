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
    public class MH_ThemMatHangModel : PageModel
    {
        public string Chuoi;
        public MatHang m;
        [BindProperty]
        public string MaMatHang { get; set; }
        [BindProperty]
        public string TenMatHang { get; set; }
        [BindProperty]
        public string HanDung { get; set; }
        [BindProperty]
        public string CtySX { get; set; }
        [BindProperty]
        public string NgaySX { get; set; }
        [BindProperty]
        public string LoaiHang { get; set; }
        [BindProperty]
        public int Gia { get; set; }


        public void OnGet()
        {
            Chuoi = string.Empty;
        }
        public void OnPost()
        {
            m.MaMH = MaMatHang;
            m.TenMH = TenMatHang;
            m.HanDung = HanDung;
            m.CtySX = CtySX;
            m.NgaySX = NgaySX;
            m.LoaiHang = LoaiHang;
            m.Gia = Gia;
            bool b = XuLyMatHang.ThemMatHang(m);
            Chuoi = $"Ket qua la {b}";
        }
    }
}
