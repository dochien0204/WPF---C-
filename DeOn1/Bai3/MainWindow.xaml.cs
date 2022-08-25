using Bai3.Models;
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

namespace Bai3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        QuanLyBenhNhanDBBContext db = new QuanLyBenhNhanDBBContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        public void hienThi()
        {
            var query = from bn in db.BenhNhans
                        orderby bn.SoNgayNamVien
                        select new
                        {
                            bn.MaBn,
                            bn.HoTen,
                            bn.MaKhoa,
                            bn.DiaChi,
                            bn.SoNgayNamVien,
                            VienPhi =string.Format("{0:0.###}",bn.SoNgayNamVien * 200000)
                        };
            dg_listBN.ItemsSource = query.ToList();

        }

        public void hienThiCb()
        {
            var khoa = from k in db.Khoas
                       select k;
            cb_khoa.ItemsSource = khoa.ToList();
            cb_khoa.DisplayMemberPath = "TenKhoa";
            cb_khoa.SelectedValuePath = "MaKhoa";
            cb_khoa.SelectedIndex = 0;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienThi();
            hienThiCb();
        }

        private void dg_listBN_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dg_listBN.SelectedItem != null)
            {
                try
                {
                    Type t = dg_listBN.SelectedItem.GetType();
                    PropertyInfo[] p = t.GetProperties();
                    tb_maBn.Text = p[0].GetValue(dg_listBN.SelectedValue).ToString();
                    tb_hoTen.Text = p[1].GetValue(dg_listBN.SelectedValue).ToString();
                    tb_diaCh.Text = p[3].GetValue(dg_listBN.SelectedValue).ToString();
                    tb_soNgay.Text = p[4].GetValue(dg_listBN.SelectedValue).ToString();
                    cb_khoa.SelectedValue = p[2].GetValue(dg_listBN.SelectedValue).ToString();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Có lỗi khi chọn " + ex.Message, "Thông báo");
                }
            }    
        }

        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tb_maBn.Text.CompareTo("") == 0)
                    throw new Exception("Mã bệnh nhân không được để trống");
                int maBn;
                if (!int.TryParse(tb_maBn.Text, out maBn)){
                    throw new Exception("Mã bn phải là kiểu số nguyên");
                }
                if (tb_hoTen.Text.CompareTo("") == 0)
                    throw new Exception("Họ tên không được để trống");
                if (tb_diaCh.Text.CompareTo("") == 0)
                    throw new Exception("Địa chỉ không được để trống");
                if (tb_soNgay.Text.CompareTo("") == 0)
                    throw new Exception("Số ngày nhập viện không được để trống");
                int soNgay;
                if (!int.TryParse(tb_soNgay.Text, out soNgay))
                    throw new Exception("Số ngày phải là kiểu số nguyên");
                if (soNgay < 1)
                    throw new Exception("Số ngày nhập viện phải >= 1");
                if (cb_khoa.SelectedIndex < 0)
                    throw new Exception("Bạn chưa chọn khoa");
                //kiểm tra mã bn xem tồn tại chưa
                var benhNhan = db.BenhNhans.SingleOrDefault(b => b.MaBn.Equals(int.Parse(tb_maBn.Text)));
                if (benhNhan != null)
                    MessageBox.Show("Mã bệnh nhân đã tồn tại");
                else
                {
                    BenhNhan bn = new BenhNhan();
                    bn.MaBn = int.Parse(tb_maBn.Text);
                    bn.HoTen = tb_hoTen.Text;
                    bn.DiaChi = tb_diaCh.Text;
                    bn.SoNgayNamVien = int.Parse(tb_soNgay.Text);
                    Khoa khoa = (Khoa)cb_khoa.SelectedItem;
                    bn.MaKhoa = khoa.MaKhoa;
                    db.BenhNhans.Add(bn);
                    db.SaveChanges();
                    MessageBox.Show("Thêm bênh nhân thành công !");
                    hienThi();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnTim_Click(object sender, RoutedEventArgs e)
        {
            var query = from bn in db.BenhNhans
                        join khoa in db.Khoas
                        on bn.MaKhoa equals khoa.MaKhoa
                        where bn.MaKhoa == 1
                        select new
                        {
                            bn.MaBn,
                            bn.HoTen,
                            bn.MaKhoa,
                            bn.DiaChi,
                            bn.SoNgayNamVien,
                            VienPhi = string.Format("{0:0.###}", bn.SoNgayNamVien * 200000)
                        };
            dg_listBN.ItemsSource = query.ToList();
        }
    }
}
