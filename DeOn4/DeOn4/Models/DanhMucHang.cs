using System;
using System.Collections.Generic;

namespace DeOn4.Models
{
    public partial class DanhMucHang
    {
        public DanhMucHang()
        {
            Hangs = new HashSet<Hang>();
        }

        public string MaDm { get; set; } = null!;
        public string? TenDm { get; set; }

        public virtual ICollection<Hang> Hangs { get; set; }
    }
}
