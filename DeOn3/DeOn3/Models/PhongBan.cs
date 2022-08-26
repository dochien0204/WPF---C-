using System;
using System.Collections.Generic;

namespace DeOn3.Models
{
    public partial class PhongBan
    {
        public PhongBan()
        {
            Nhanviens = new HashSet<Nhanvien>();
        }

        public string MaPhong { get; set; } = null!;
        public string? TenPhong { get; set; }

        public virtual ICollection<Nhanvien> Nhanviens { get; set; }
    }
}
