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
    public class MH_XoaLoaiHangModel : PageModel
    {
        public string Chuoi;
        public LoaiHang LoaiHang;
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        public void OnGet()
        {
            LoaiHang? lh = XuLyLoaiHang.DocLoaiHang(Id);
            LoaiHang = lh.Value;
        }
        public void OnPost()
        {
            bool kq = XuLyLoaiHang.XoaLoaiHang(Id);
            Chuoi = $"Ket qua la {kq}";
            Response.Redirect("/MH_DanhSachLoaiHang");
        }
    }
}
