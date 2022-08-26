using DeOn3.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace DeOn3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
        QLNhanvienContext db = new QLNhanvienContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        //hiển thị DataGrid
        private void hienThi()
        {
            var query = from nv in db.Nhanviens
                        orderby nv.Luong
                        select new
                        {
                            nv.MaPhong,
                            nv.MaNv,
                            nv.Hoten,
                            Luong = int.Parse(((int)nv.Luong).ToString()).ToString("#,###", cul.NumberFormat),
                            Thuong = int.Parse(((int)nv.Thuong).ToString()).ToString("#,###", cul.NumberFormat),
                            TongTien = nv.tongTien()
                        };
            dgListNV.ItemsSource = query.ToList();

        }

        //hiển thị ComboBox
        private void hienThiCb()
        {
            var query = from phong in db.PhongBans
                        select phong;
            cbPhong.ItemsSource = query.ToList();
            cbPhong.DisplayMemberPath = "TenPhong";
            cbPhong.SelectedValuePath = "MaPhong";
            cbPhong.SelectedIndex = -1;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienThi();
            hienThiCb();
        }

        //kiểm tra ngoại lệ
        private string checkData()
        {
            string str = "";
            try
            {
                if (tbMaNV.Text.CompareTo("") == 0)
                    str += "Mã nhân viên không được để trống\n";

                if (tbHoTen.Text.CompareTo("") == 0)
                    str += "Họ tên không được để trống\n";
                if (tbLuong.Text.CompareTo("") == 0)
                    str += "Lương không được để trống\n";
                else
                {

                    if (!int.TryParse(tbLuong.Text, out int luong))
                        str += "Lương nhập phải là kiểu số nguyên\n";
                    else
                    {
                        if (luong < 3000 || luong > 9000)
                            str += "Lương chỉ được trong khoảng 3000-9000";
                    }
                    
                }
                if (tbThuong.Text.CompareTo("") == 0)
                    str += "Thưởng không được để trống\n";
                else
                {
                    if (!int.TryParse(tbThuong.Text, out int thuong))
                        str += "Thưởng phải là kiểu số nguyên\n";
                    else
                    {
                        if (thuong < 100 || thuong > 900)
                            str += "Thưởng chỉ được trong khoảng 100-900";
                    }
                }
                if (cbPhong.SelectedIndex < 0)
                    str += "Bạn chưa chọn phòng !";
            }
            catch(Exception ex)
            {
                _ = ex.Message;
            }
            return str;
        }

        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            if(checkData().CompareTo("") == 0)
            {
                var query = db.Nhanviens.SingleOrDefault(nv => nv.MaNv.Equals(tbMaNV.Text));
                if (query != null)
                    MessageBox.Show("Mã nhân viên đã tồn tại\n", "Thông báo");
                else
                {
                Nhanvien nv = new Nhanvien();
                nv.MaNv = tbMaNV.Text;
                nv.Hoten = tbHoTen.Text;
                nv.Luong = int.Parse(tbLuong.Text);
                nv.Thuong = int.Parse(tbThuong.Text);
                PhongBan pb = (PhongBan)cbPhong.SelectedItem;
                nv.MaPhong = pb.MaPhong;
                db.Nhanviens.Add(nv);
                db.SaveChanges();
                MessageBox.Show("Thêm nhân viên thành công", "Thông báo");
                hienThi();
                }
            }
            else
            {
                MessageBox.Show(checkData(), "Thông báo");
            }
            

        }

        private void BtnSua_Click(object sender, RoutedEventArgs e)
        {
            var nvSua = db.Nhanviens.SingleOrDefault(t => t.MaNv.Equals(tbMaNV.Text));
            if (nvSua != null)
            {
                if (checkData().CompareTo("") == 0)
                {
                    nvSua.Hoten = tbHoTen.Text;
                    nvSua.Luong = int.Parse(tbLuong.Text);
                    nvSua.Thuong = int.Parse(tbThuong.Text);
                    PhongBan pb = (PhongBan)cbPhong.SelectedItem;
                    nvSua.MaPhong = pb.MaPhong;
                    db.SaveChanges();
                    MessageBox.Show("Sửa thành công", "Thông báo");
                    hienThi();
                }
                else
                {
                    MessageBox.Show(checkData(), "Thông báo");
                }
            }
            else
                MessageBox.Show("Chưa chọn nhân viên để sửa ", "Thông báo");

        }

        private void dgListNV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Type t = dgListNV.SelectedItem.GetType();
                PropertyInfo[] p = t.GetProperties();
                tbMaNV.Text = p[1].GetValue(dgListNV.SelectedValue).ToString();
                tbMaNV.IsReadOnly = true;
                tbHoTen.Text = p[2].GetValue(dgListNV.SelectedValue).ToString();
                tbLuong.Text = p[3].GetValue(dgListNV.SelectedValue).ToString();
                tbThuong.Text = p[4].GetValue(dgListNV.SelectedValue).ToString();
                cbPhong.SelectedValue = p[0].GetValue(dgListNV.SelectedValue).ToString();

            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }
           
        }

        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            var query = db.Nhanviens.SingleOrDefault(t => t.MaNv.Equals(tbMaNV.Text));
            if (query != null)
            {
                MessageBoxResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này ?", "Thông báo", MessageBoxButton.YesNo);
                if (rs == MessageBoxResult.Yes)
                {
                    db.Nhanviens.Remove(query);
                    db.SaveChanges();
                    hienThi();
                }
            }
            else
                MessageBox.Show("Chưa chọn nhân viên để xóa");
        }

        private void BtnTim_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();
            window.Show();
        }
    }
}
