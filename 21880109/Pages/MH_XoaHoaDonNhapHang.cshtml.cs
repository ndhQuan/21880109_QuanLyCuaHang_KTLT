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
    public class MH_XoaHoaDonNhapHangModel : PageModel
    {
        public string Chuoi;
        [BindProperty(SupportsGet =true)]
        public string Id { get; set; }
        public void OnGet()
        {

        }
        public void OnPost()
        {
            bool kq = XuLyHoaDon.XoaHoaDonNhap(Id);
            Chuoi = $"Ket qua la {kq}";
        }
    }
}
