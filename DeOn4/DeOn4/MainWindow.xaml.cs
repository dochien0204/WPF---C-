using DeOn4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DeOn4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        QLBanHangContext db = new QLBanHangContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void hienThi()
        {
            var query = from hang in db.Hangs
                        orderby hang.TenHang descending
                        select new
                        {
                            hang.MaHang,
                            hang.TenHang,
                            hang.MaDm,
                            hang.DonGiaBan,
                            hang.SoLuongCon,
                            ThanhTien = hang.ThanhTien()
                        };
            dgListHang.ItemsSource = query.ToList();
        }

        private void hienThiCb()
        {
            var query = from dm in db.DanhMucHangs
                        select dm;
            cbDanhMuc.ItemsSource = query.ToList();
            cbDanhMuc.DisplayMemberPath = "TenDm";
            cbDanhMuc.SelectedValuePath = "MaDm";
            cbDanhMuc.SelectedIndex = 0;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienThi();
            hienThiCb();
        }

        private string checkData()
        {
            string str = "";
            if (tbMaHang.Text.CompareTo("") == 0)
                str += "Mã hàng không được để trống\n";
            if (tbTenHang.Text.CompareTo("") == 0)
                str += "Tên hàng không được để trống\n";
            if (tbDonGia.Text.CompareTo("") == 0)
                str += "Đơn giá bán không được để trống\n";
            else
            {
                if (!int.TryParse(tbDonGia.Text, out int donGia))
                    str += "Đơn giá phải là kiểu số nguyên\n";
                else if (donGia < 0)
                    str += "Đơn giá phải lớn hơn 0\n";
            }
            if (tbSoLuong.Text.CompareTo("") == 0)
                str += "Số lượng còn không được để trống\n";
            else
            {
                if (!int.TryParse(tbSoLuong.Text, out int soLuong))
                    str += "Số lượng phải là kiểu số nguyên\n";
                else if (soLuong < 0)
                    str += "Số lượng phải lớn hơn 0\n";
            }
            if (cbDanhMuc.SelectedIndex < 0)
                str += "Bạn chưa chọn danh mục hàng\n";
            return str;

        }
        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            if (checkData().CompareTo("") != 0)
                MessageBox.Show(checkData(), "Thông báo");
            else
            {
                var query = db.Hangs.SingleOrDefault(hang => hang.MaHang.Equals(tbMaHang.Text));
                if (query != null)
                    MessageBox.Show("Mã hàng đã tồn tại", "Thông báo");
                else
                {
                    Hang hang = new Hang();
                    hang.MaHang = tbMaHang.Text;
                    hang.TenHang = tbTenHang.Text;
                    DanhMucHang dm = (DanhMucHang)cbDanhMuc.SelectedItem;
                    hang.MaDm = dm.MaDm;
                    hang.DonGiaBan = int.Parse(tbDonGia.Text);
                    hang.SoLuongCon = int.Parse(tbSoLuong.Text);
                    db.Hangs.Add(hang);
                    db.SaveChanges();
                    MessageBox.Show("Thêm thành công", "Thông báo");
                    hienThi();  
                }
            }
        }

        private void dgListHang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
            Type t = dgListHang.SelectedItem.GetType();
            PropertyInfo[] p = t.GetProperties();
            tbMaHang.Text = p[0].GetValue(dgListHang.SelectedValue).ToString();
            tbMaHang.IsReadOnly = true;
            tbTenHang.Text = p[1].GetValue(dgListHang.SelectedValue).ToString();
            tbDonGia.Text = p[3].GetValue(dgListHang.SelectedValue).ToString();
            tbSoLuong.Text = p[4].GetValue(dgListHang.SelectedValue).ToString();
            cbDanhMuc.SelectedValue = p[2].GetValue(dgListHang.SelectedValue); 

            }
            catch(Exception ex)
            {
                _ = ex.Message;
            }
        }

        private void BtnSua_Click(object sender, RoutedEventArgs e)
        {
            var hangSua = db.Hangs.SingleOrDefault(hang => hang.MaHang.Equals(tbMaHang.Text));
            if(hangSua != null)
            {
                hangSua.TenHang = tbTenHang.Text;
                hangSua.DonGiaBan = int.Parse(tbDonGia.Text);
                hangSua.SoLuongCon = int.Parse(tbSoLuong.Text);
                DanhMucHang dm = (DanhMucHang)cbDanhMuc.SelectedItem;
                hangSua.MaDm = dm.MaDm;
                db.SaveChanges();
                MessageBox.Show("Sửa thành công", "Thông báo");
                hienThi();
            }   
            else
            {
                MessageBox.Show("Chưa có sản phẩm nào được chọn để sửa");
            }
        }

        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            var hangXoa = db.Hangs.SingleOrDefault(h => h.MaHang.Equals(tbMaHang.Text));
            if(hangXoa != null)
            {
                MessageBoxResult result = MessageBox.Show("Do you want to delete ?", "Warning", MessageBoxButton.YesNo);
                if(result == MessageBoxResult.Yes)
                {
                    db.Hangs.Remove(hangXoa);
                    db.SaveChanges();
                    hienThi();
                }
            }
            else
            {
                MessageBox.Show("Ban chua chon hang de xoa ", "Thong bao");
            }
        }

        private void BtnTim_Click(object sender, RoutedEventArgs e)
        {
            WindowSearch window = new WindowSearch();
            window.Show();
        }
    }
}
