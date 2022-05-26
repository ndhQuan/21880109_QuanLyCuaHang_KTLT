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
    public class MH_DanhSachLoaiHangModel : PageModel
    {
        public List<LoaiHang> dsLoaiHang;
        [BindProperty]
        public string TuKhoa { get; set; }
        [BindProperty]
        public string DanhMucTimKiem { get; set; }
        public void OnGet()
        {
            dsLoaiHang = XuLyLoaiHang.TimKiemLoaiHang(string.Empty, string.Empty);
        }
        public void OnPost()
        {
            dsLoaiHang = XuLyLoaiHang.TimKiemLoaiHang(TuKhoa, DanhMucTimKiem);
        }
    }
}
