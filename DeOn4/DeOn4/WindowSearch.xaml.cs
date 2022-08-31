using DeOn4.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace DeOn4
{
    /// <summary>
    /// Interaction logic for WindowSearch.xaml
    /// </summary>
    public partial class WindowSearch : Window
    {
        QLBanHangContext db = new QLBanHangContext();
        public WindowSearch()
        {
            InitializeComponent();
        }
        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var hangs = from hang in db.Hangs
                        join d in db.DanhMucHangs
                        on hang.MaDm equals d.MaDm
                        select new
                        {
                            d.MaDm,
                            d.TenDm,
                            hang.MaHang,
                            tong = hang.DonGiaBan * hang.SoLuongCon
                        };
            var query = hangs.GroupBy(h => new { h.MaDm, h.TenDm })
                .Select(dm => new
                {
                    dm.Key.MaDm,
                    dm.Key.TenDm,
                    TongTien = int.Parse(dm.Sum(dm => dm.tong).ToString()).ToString("#,###", cul.NumberFormat)
                    /*                    TongTien = dm.Count()*/
                });
            dgListHang.ItemsSource = query.ToList();
           
        }
    }
}
