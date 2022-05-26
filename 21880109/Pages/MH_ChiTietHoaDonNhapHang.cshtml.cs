using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using _21880109.Entities;
using _21880109.DAL;

namespace _21880109.Pages
{
    
    public class MH_ChiTietHoaDonNhapHangModel : PageModel
    {
        public List<HoaDon> dshdn;
        public HoaDon HoaDonNhap;
        public string Chuoi;
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        public void OnGet()
        {
            dshdn = LuuTruHoaDon.DocDanhSachHoaDonNhapHang();
            foreach (HoaDon h in dshdn)
            {
                if (h.MaHoaDon == Id)
                {
                    HoaDonNhap = h;
                }
            }

        }
        public void OnPost()
        {
        }
    }
}
