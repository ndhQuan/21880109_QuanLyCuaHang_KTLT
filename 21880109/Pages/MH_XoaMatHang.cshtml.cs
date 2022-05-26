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
    public class MH_XoaMatHangModel : PageModel
    {
        public string Chuoi;
        public MatHang MatHang;
        public List<string> HoaDonChuaMatHang { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public void OnGet()
        {
            MatHang? mh = XuLyMatHang.DocMatHang(Id);
            MatHang = mh.Value;
            HoaDonChuaMatHang = XuLyMatHang.HoaDonChuaMatHang(Id);
        }
        public void OnPost()
        {
            bool kq = XuLyMatHang.XoaMatHang(Id);
            Chuoi = $"Ket qua la {kq}";
            HoaDonChuaMatHang = XuLyMatHang.HoaDonChuaMatHang(string.Empty);

            Response.Redirect("/MH_DanhSachMatHang");
        }
    }
}
