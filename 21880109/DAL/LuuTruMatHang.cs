using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using _21880109.Entities;
using Newtonsoft.Json;

namespace _21880109.DAL
{
    public class LuuTruMatHang
    {
        public static bool LuuMatHang(MatHang m)
        {
            List<MatHang> danhSachMatHang = DocDanhSachMatHang();
            foreach(MatHang mh in danhSachMatHang)
            {
                if(mh.MaMH == m.MaMH)
                {
                    return false;
                }
            }
            danhSachMatHang.Add(m);
            LuuDanhSachMatHang(danhSachMatHang);
            return true;
        }
        public static List<MatHang> DocDanhSachMatHang()
        {
            string myDir = Environment.CurrentDirectory;
            StreamReader reader = new StreamReader($"{myDir}\\DS_MatHang.json");
            string jsonString = reader.ReadToEnd();
            reader.Close();

            List<MatHang> danhSachMatHang = JsonConvert.DeserializeObject<List<MatHang>>(jsonString);
            return danhSachMatHang;
        }
        public static bool LuuDanhSachMatHang(List<MatHang> dsMatHang)
        {
            string myDir = Environment.CurrentDirectory;
            StreamWriter writer = new StreamWriter($"{myDir}\\DS_MatHang.json");

            string jsonString = JsonConvert.SerializeObject(dsMatHang);
            writer.Write(jsonString);
            writer.Close();
            return true;
        }
        public static bool SuaMatHang(MatHang sp)
        {
            List<MatHang> dssp = LuuTruMatHang.DocDanhSachMatHang();
            for (int i = 0; i < dssp.Count; i++)
            {
                if (dssp[i].MaMH == sp.MaMH)
                {
                    dssp[i] = sp;
                    LuuTruMatHang.LuuDanhSachMatHang(dssp);
                    return true;
                }

            }
            return false;
        }
        public static bool XoaMatHang(string Id)
        {
            List<MatHang> dsmh = DocDanhSachMatHang();
            for(int i =0; i < dsmh.Count; i++)
            {
                if(dsmh[i].MaMH == Id)
                {
                    dsmh.RemoveAt(i);
                    LuuDanhSachMatHang(dsmh);
                    return true;
                }
            }
            return false;
        }
    }
}
