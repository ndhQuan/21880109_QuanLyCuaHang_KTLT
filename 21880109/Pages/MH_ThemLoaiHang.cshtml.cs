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
    public class MH_ThemLoaiHangModel : PageModel
    {
        public string Chuoi;
        public LoaiHang lh;
        [BindProperty]
        public string MaLoaiHang { get; set; }
        [BindProperty]
        public string TenLoaiHang { get; set; }

        public void OnGet()
        {
            Chuoi = string.Empty;

        }
        public void OnPost()
        {
            lh.MaLoaiHang = MaLoaiHang;
            lh.TenLoaiHang = TenLoaiHang;
            bool b = XuLyLoaiHang.ThemLoaiHang(lh);
            Chuoi = $"Ket qua la {b}";
        }

    }
}
