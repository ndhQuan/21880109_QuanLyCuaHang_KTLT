using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _21880109.Entities
{
    public struct HoaDon
    {
        public string MaHoaDon;
        public string NgayTaoHoaDon;
        public List<ChiTietHoaDon> ChiTiet;   //Chi tiết hóa đơn
    }
}
