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
    public class MH_DanhSachMatHangModel : PageModel
    {
        public string Chuoi;
        public List<MatHang> dsMatHang;
        [BindProperty]
        public string tukhoa { get; set; }
        [BindProperty]
        public string DanhMucTimKiem { get; set; }
        public void OnGet()
        {
            Chuoi = string.Empty;
            dsMatHang = XuLyMatHang.TimKiemMatHang(string.Empty, string.Empty);
        }
        public void OnPost()
        {
            dsMatHang = XuLyMatHang.TimKiemMatHang(tukhoa, DanhMucTimKiem);

        }
    }
}
