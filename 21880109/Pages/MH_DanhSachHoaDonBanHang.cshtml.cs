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
    public class MH_DanhSachHoaDonBanHangModel : PageModel
    {
        public List<HoaDon> dshdb;
        [BindProperty]
        public string TuKhoa { get; set; }
        [BindProperty]
        public string Target { get; set; }
        public void OnGet()
        {
            dshdb = XuLyHoaDon.TimKiemHoaDonBanHang(string.Empty, "MaHoaDon");
        }
        public void OnPost()
        {
            dshdb = XuLyHoaDon.TimKiemHoaDonBanHang(TuKhoa, Target);
        }
    }
}
