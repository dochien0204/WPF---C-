using System;
using System.Collections.Generic;

namespace DemoEFCore.Models
{
    public partial class Lsp
    {
        public Lsp()
        {
            Sps = new HashSet<Sp>();
        }

        public string Maloai { get; set; } = null!;
        public string? Tenloai { get; set; }

        public virtual ICollection<Sp> Sps { get; set; }
    }
}
