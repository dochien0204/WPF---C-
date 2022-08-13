using System;
using System.Collections.Generic;

namespace DemoEFCore.Models
{
    public partial class Sp
    {
        public string Masp { get; set; } = null!;
        public string? Tensp { get; set; }
        public string? Maloai { get; set; }
        public int? Soluong { get; set; }
        public double? Dongia { get; set; }

        public virtual Lsp? MaloaiNavigation { get; set; }
    }
}
