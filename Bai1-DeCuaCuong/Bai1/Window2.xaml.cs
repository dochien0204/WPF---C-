using Bai1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bai1
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        QLBanHangContext db = new QLBanHangContext();
        public Window2()
        {
            InitializeComponent();
        }

        private void Windows2_Loaded(object sender, RoutedEventArgs e)
        {
            var query = from sp in db.Sps
                        join lsp in db.Lsps
                        on sp.Maloai equals lsp.Maloai
                        where lsp.Maloai == "01"
                        select new
                        {
                            sp.Masp,
                            sp.Tensp,
                            sp.Maloai,
                            sp.Soluong,
                            sp.Dongia,
                            thanhTien = sp.Soluong * sp.Dongia
                        };
            dg_list2.ItemsSource = query.ToList();
        }
    }
}
