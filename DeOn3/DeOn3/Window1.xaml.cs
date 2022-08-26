using DeOn3.Models;
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

namespace DeOn3
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        QLNhanvienContext db = new QLNhanvienContext();
        public Window1()
        {
            InitializeComponent();
        }

        private void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            int? tongLuongHC = 0, tongLuongDT = 0,tongLuongTH = 0;
            int soLuongNVHC = 0, soLuongNVTH = 0, soLuongNVDT = 0;
            foreach(Nhanvien nv in db.Nhanviens)
            {
                if(nv.MaPhong.CompareTo("HC") == 0)
                {
                    tongLuongHC += nv.Luong;
                    soLuongNVHC++;
                }
                if (nv.MaPhong.CompareTo("DT") == 0)
                {
                    tongLuongDT += nv.Luong;
                    soLuongNVDT++;
                }
                if (nv.MaPhong.CompareTo("TH") == 0)
                {
                    tongLuongTH += nv.Luong;
                    soLuongNVTH++;
                }
            }

            var query = from nv in db.Nhanviens
                        join pb in db.PhongBans
                        on nv.MaPhong equals pb.MaPhong
                        where pb.MaPhong == "HC"
                        select new
                        {
                            pb.MaPhong,
                            pb.TenPhong,
                            SoLuong = soLuongNVHC,
                            TongLuong = tongLuongHC
                        };
            var query1 = from nv in db.Nhanviens
                        join pb in db.PhongBans
                        on nv.MaPhong equals pb.MaPhong
                        where pb.MaPhong == "TH"
                        select new
                        {
                            pb.MaPhong,
                            pb.TenPhong,
                            SoLuong = soLuongNVTH,
                            TongLuong = tongLuongTH
                        };
            var query2 = from nv in db.Nhanviens
                        join pb in db.PhongBans
                        on nv.MaPhong equals pb.MaPhong
                        where pb.MaPhong == "DT"
                        select new
                        {
                            pb.MaPhong,
                            pb.TenPhong,
                            SoLuong = soLuongNVDT,
                            TongLuong = tongLuongDT
                        };
            dgListNV.Items.Add(query.ToList());
            dgListNV.Items.Add(query1.ToList());
            dgListNV.Items.Add(query2.ToList());
                 
        }
    }
}
