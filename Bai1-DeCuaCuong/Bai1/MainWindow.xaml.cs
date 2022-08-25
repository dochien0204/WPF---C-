using Bai1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Bai1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public QLBanHangContext db = new QLBanHangContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        public void hienThi()
        {
            var query = from sp in db.Sps
                        orderby sp.Dongia
                        select new
                        {
                            sp.Masp,
                            sp.Tensp,
                            sp.Maloai,
                            sp.Soluong,
                            sp.Dongia,
                            thanhTien = sp.Soluong * sp.Dongia
                        };
            dg_list.ItemsSource = query.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienThi();

            //Hiển thị combobox
            hienThiCb();
        }

        public void hienThiCb()
        {
            var query = from lsp in db.Lsps
                        select lsp;
            cb_lsp.ItemsSource = query.ToList();
            cb_lsp.DisplayMemberPath = "Tenloai";
            cb_lsp.SelectedValuePath = "Maloai";
            cb_lsp.SelectedIndex = 0;
        }

        private void dg_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_list.SelectedItem != null)
            {
                try
                {
                    Type type = dg_list.SelectedItem.GetType();
                    PropertyInfo[] p = type.GetProperties();
                    tb_maSp.Text = p[0].GetValue(dg_list.SelectedValue).ToString();
                    tb_maSp.IsReadOnly = true;
                    tb_tenSp.Text = p[1].GetValue(dg_list.SelectedValue).ToString();
                    cb_lsp.SelectedValue = p[2].GetValue(dg_list.SelectedValue).ToString();
                    tb_soLuong.Text = p[3].GetValue(dg_list.SelectedValue).ToString();
                    tb_donGia.Text = p[4].GetValue(dg_list.SelectedValue).ToString();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi chọn hàng " + ex.Message, "Thông báo");
                }

            }
        }

        private void Them_Click(object sender, RoutedEventArgs e)
        {
            var query = db.Sps.SingleOrDefault(t => t.Masp.Equals(tb_maSp.Text));
            if (query != null)
                MessageBox.Show("Mã sản phẩm đã tồn tại", "Thông báo");
            else
            {
                Sp sp = new Sp();
                sp.Masp = tb_maSp.Text;
                sp.Tensp = tb_tenSp.Text;
                Lsp lsp = (Lsp)cb_lsp.SelectedItem;
                sp.Soluong = int.Parse(tb_soLuong.Text);
                sp.Dongia = double.Parse(tb_donGia.Text);
                sp.Maloai = lsp.Maloai;
                db.Sps.Add(sp);
                db.SaveChanges();
                MessageBox.Show("Thêm sản phẩm mới thành công", "Thông báo");
                hienThi();
            }


        }

        private void BtnSua_Click(object sender, RoutedEventArgs e)
        {
            var query = db.Sps.SingleOrDefault(sp => sp.Masp.Equals(tb_maSp.Text));
            if(query != null)
            {
                tb_maSp.IsReadOnly = false;
                query.Tensp = tb_tenSp.Text;
                Lsp lsp = (Lsp)cb_lsp.SelectedItem;
                query.Maloai = lsp.Maloai;
                query.Dongia = double.Parse(tb_donGia.Text);
                query.Soluong = int.Parse(tb_soLuong.Text);
                db.SaveChanges();
                MessageBox.Show("Sửa thành công", "Thông báo");
                hienThi();
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm cần sửa", "Thông báo");
            }
        }

        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            var sp = db.Sps.SingleOrDefault(t => t.Masp.Equals(tb_maSp.Text));
            if(sp != null)
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này ? ", "Thông báo", MessageBoxButton.YesNo);
                if(result == MessageBoxResult.Yes)
                {
                    db.Sps.Remove(sp);
                    db.SaveChanges();
                    hienThi();
                }
                else
                {
                    MessageBox.Show("Bạn đã chọn hủy xóa");
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm để xóa");
            }
        }

        private void BtnTim_Click(object sender, RoutedEventArgs e)
        {
            Lsp lsp = (Lsp)cb_lsp.SelectedItem;
            var query = from sp in db.Sps
                        where sp.Maloai == lsp.Maloai
                        orderby sp.Dongia
                        select new
                        {
                            sp.Masp,
                            sp.Tensp,
                            sp.Maloai,
                            sp.Soluong,
                            sp.Dongia,
                            thanhTien = sp.Soluong * sp.Dongia
                        };
            dg_list.ItemsSource = query.ToList();
        }

        private void Btn_ThongKe(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.Show();
        }
    }
}
