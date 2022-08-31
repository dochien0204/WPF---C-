using System;
using System.Collections.Generic;
using System.Globalization;

namespace DeOn4.Models
{
    public partial class Hang
    {
        public string MaHang { get; set; } = null!;
        public string? TenHang { get; set; }
        public int? DonGiaBan { get; set; }
        public int? SoLuongCon { get; set; }
        public string? MaDm { get; set; }

        public virtual DanhMucHang? MaDmNavigation { get; set; }

        public string ThanhTien()
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            int? thanhTien = DonGiaBan * SoLuongCon;
            string str = int.Parse(thanhTien.ToString()).ToString("#,###", cul.NumberFormat);
            return str;
        }    
    }
}
