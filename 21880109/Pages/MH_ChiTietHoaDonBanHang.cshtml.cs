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
    public class MH_ChiTietHoaDonBanHangModel : PageModel
    {
        public List<HoaDon> dshdb;
        public HoaDon HoaDonBan;
        public string Chuoi;
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public void OnGet()
        {
            dshdb = LuuTruHoaDon.DocDanhSachHoaDonBanHang();
            foreach(HoaDon h in dshdb)
            {
                if(h.MaHoaDon == Id)
                {
                    HoaDonBan = h;
                }
            }
        }
    }
}
