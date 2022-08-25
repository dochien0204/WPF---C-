using DeOn2.Models;
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

namespace DeOn2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        QuanLySanPhamDBContext db = new QuanLySanPhamDBContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void hienThi()
        {
            var query = from sp in db.SanPhams
                        join nh in db.NhomHangs
                        on sp.MaNhomHang equals nh.MaNhomHang
                        orderby sp.SoLuongBan descending
                        select new
                        {
                            sp.MaSp,
                            sp.TenSanPham,
                            sp.DonGia,
                            sp.SoLuongBan,
                            nh.TenNhomHang,
                            TienBan = sp.tienBan()
                        };
            dg_listSp.ItemsSource = query.ToList();
                        
        }

        private void hienThiCb()
        {
            var query = from nh in db.NhomHangs
                        select nh;
            cbHang.ItemsSource = query.ToList();
            cbHang.DisplayMemberPath = "TenNhomHang";
            cbHang.SelectedValuePath = "MaNhomHang";
            cbHang.SelectedIndex = 0;
        }    
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienThi();
            hienThiCb();
        }

        private void checkData()
        {
            try
            {
            if (tbMaSp.Text.CompareTo("") == 0)
                throw new Exception("Mã sản phẩm không được để trống");
            int maSp;
            if (!int.TryParse(tbMaSp.Text, out maSp))
                throw new Exception("Mã sản phẩm phải là kiểu số nguyên");
            if (tbTenSp.Text.CompareTo("") == 0)
                    throw new Exception("Tên sản phẩm không được để trống");
            if (tbDonGia.Text.CompareTo("") == 0)
                    throw new Exception("Đơn giá không được để trống");
            if (tbSoLuongBan.Text.CompareTo("") == 0)
                    throw new Exception("Số lượng bán không được để trống");
            double donGia;
            if(!double.TryParse(tbDonGia.Text, out donGia))
            {
                    throw new Exception("Đơn giá phải là kiểu số thực");
            }
            if (cbHang.SelectedIndex < 0)
                    throw new Exception("Bạn chưa chọn nhóm hàng");
            int soLuong;
            if (int.Parse(tbSoLuongBan.Text) < 1)
                throw new Exception("Số lượng bán phải >=1 và là kiể số nguyên");

            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbMaSp.Text.CompareTo("") == 0)
                    throw new Exception("Mã sản phẩm không được để trống");
                int maSp;
                if (!int.TryParse(tbMaSp.Text, out maSp))
                    throw new Exception("Mã sản phẩm phải là kiểu số nguyên");
                if (tbTenSp.Text.CompareTo("") == 0)
                    throw new Exception("Tên sản phẩm không được để trống");
                if (tbDonGia.Text.CompareTo("") == 0)
                    throw new Exception("Đơn giá không được để trống");
                if (tbSoLuongBan.Text.CompareTo("") == 0)
                    throw new Exception("Số lượng bán không được để trống");
                double donGia;
                if (!double.TryParse(tbDonGia.Text, out donGia))
                {
                    throw new Exception("Đơn giá phải là kiểu số thực");
                }
                if (cbHang.SelectedIndex < 0)
                    throw new Exception("Bạn chưa chọn nhóm hàng");
                if (int.Parse(tbSoLuongBan.Text) < 1)
                    throw new Exception("Số lượng bán phải >=1 và là kiể số nguyên");
                var query = db.SanPhams.SingleOrDefault(sp => sp.MaSp.Equals(int.Parse(tbMaSp.Text)));
                if (query != null)
                    MessageBox.Show("Mã sản phẩm đã tồn tại");
                else
                {
                    SanPham sp = new SanPham();
                    sp.MaSp = int.Parse(tbMaSp.Text);
                    sp.TenSanPham = tbTenSp.Text;
                    sp.DonGia = double.Parse(tbDonGia.Text);
                    sp.SoLuongBan = int.Parse(tbSoLuongBan.Text);
                    NhomHang nhomHang = (NhomHang)cbHang.SelectedItem;
                    sp.MaNhomHang = nhomHang.MaNhomHang;
                    db.SanPhams.Add(sp);
                    db.SaveChanges();
                    MessageBox.Show("Thêm sản phẩm thành công");
                    hienThi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void dg_listSp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Type t = dg_listSp.SelectedItem.GetType();
            PropertyInfo[] p = t.GetProperties();
            tbMaSp.Text = p[0].GetValue(dg_listSp.SelectedValue).ToString();
            tbTenSp.Text = p[1].GetValue(dg_listSp.SelectedValue).ToString();
            tbDonGia.Text = p[2].GetValue(dg_listSp.SelectedValue).ToString();
            tbSoLuongBan.Text = p[3].GetValue(dg_listSp.SelectedValue).ToString();
            cbHang.Text = p[4].GetValue(dg_listSp.SelectedValue).ToString();
        }

        private void BtnTim_Click(object sender, RoutedEventArgs e)
        {
            Window2 window = new Window2();
            window.Show();

        }
    }
}
