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
    public class MH_SuaMatHangModel : PageModel
    {
        public string Chuoi;
        public MatHang mh;
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
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
            MatHang? sp = XuLyMatHang.DocMatHang(Id);
            mh = sp.Value;
        }
        public void OnPost()
        {
            bool kq = XuLyMatHang.SuaMatHang(Id, TenMatHang, HanDung, CtySX, NgaySX, LoaiHang, Gia);
            Chuoi = $"Ket qua la {kq}";
            Response.Redirect("/MH_DanhSachMatHang");
        }
    }
}
