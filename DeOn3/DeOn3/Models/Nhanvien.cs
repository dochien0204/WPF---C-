using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace DeOn3.Models
{
    public partial class Nhanvien
    {
        public string MaNv { get; set; } = null!;
        public string? Hoten { get; set; }
        public int? Luong { get; set; }
        public int? Thuong { get; set; }
        public string? MaPhong { get; set; }

        public virtual PhongBan? MaPhongNavigation { get; set; }

        public string tongTien()
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            int a = ((int)(Luong + Thuong));
            string b = int.Parse(a.ToString()).ToString("#,###", cul.NumberFormat);
            return b;

        }    
    }
}
