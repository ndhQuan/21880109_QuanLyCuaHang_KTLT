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
    public class MH_DanhSachHoaDonNhapHangModel : PageModel
    {
        public List<HoaDon> dshdn;
        [BindProperty]
        public string TuKhoa { get; set; }
        [BindProperty]
        public string Target { get; set; }
        public void OnGet()
        {
            dshdn = XuLyHoaDon.TimKiemHoaDonNhapHang(string.Empty, "MaHoaDon");
        }
        public void OnPost()
        {
            dshdn = XuLyHoaDon.TimKiemHoaDonNhapHang(TuKhoa, Target);
        }
    }
}
