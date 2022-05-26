using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using _21880109.Entities;
using Newtonsoft.Json;

namespace _21880109.DAL
{
    public class LuuTruLoaiHang
    {
        public static bool LuuLoaiHang(LoaiHang lh)
        {
            List<LoaiHang> danhSachLoaiHang = DocDanhSachLoaiHang();
            danhSachLoaiHang.Add(lh);
            LuuDanhSachLoaiHang(danhSachLoaiHang);
            return true;
        }
        public static List<LoaiHang> DocDanhSachLoaiHang()
        {
            string myDir = Environment.CurrentDirectory;
            StreamReader reader = new StreamReader($"{myDir}\\DS_LoaiHang.json");
            string jsonString = reader.ReadToEnd();
            reader.Close();

            List<LoaiHang> danhSachLoaiHang = JsonConvert.DeserializeObject<List<LoaiHang>>(jsonString);
            return danhSachLoaiHang;
        }
        public static bool LuuDanhSachLoaiHang(List<LoaiHang> dsLoaiHang)
        {
            string myDir = Environment.CurrentDirectory;
            StreamWriter writer = new StreamWriter($"{myDir}\\DS_LoaiHang.json");

            string jsonString = JsonConvert.SerializeObject(dsLoaiHang);
            writer.Write(jsonString);
            writer.Close();
            return true;
        }
        public static bool SuaLoaiHang(LoaiHang sp)
        {
            List<LoaiHang> dssp = LuuTruLoaiHang.DocDanhSachLoaiHang();
            for (int i = 0; i < dssp.Count; i++)
            {
                if (dssp[i].MaLoaiHang == sp.MaLoaiHang)
                {
                    dssp[i] = sp;
                    LuuTruLoaiHang.LuuDanhSachLoaiHang(dssp);
                    return true;
                }

            }
            return false;
        }
        public static bool XoaLoaiHang(string Id)
        {
            List<LoaiHang> dsmh = DocDanhSachLoaiHang();
            for (int i = 0; i < dsmh.Count; i++)
            {
                if (dsmh[i].MaLoaiHang == Id)
                {
                    dsmh.RemoveAt(i);
                    LuuDanhSachLoaiHang(dsmh);
                    return true;
                }
            }
            return false;

        }
    }
}
