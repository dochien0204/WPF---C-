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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bai1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (name.Text.CompareTo("") == 0)
                    throw new Exception("Tên không được để trống");
                if (cbType.SelectedIndex < 0)
                    throw new Exception("Loại nv ko được để trống");
                if (dp.Text.CompareTo("") == 0)
                    throw new Exception("Ngày sinh không được để trống");
                else if (getAge() < 19 || getAge() > 60)
                    throw new Exception("Tuổi của bạn phải >= 19 và <=60");
                if (tbMoney.Text.CompareTo("") == 0)
                    throw new Exception("Số tiền bán không được để trống");
                double a;
                if(!double.TryParse(tbMoney.Text, out a))
                {
                    throw new Exception("Số tiền bán phải là số thực");
                }
                ListBoxItem item = new ListBoxItem();
                item.Content = name.Text + " - " + cbType.Text + " - " + dp.Text + " - " + "Tiền bán hàng : " + tbMoney.Text + " - " + "Hoa hồng : " + hoaHong(double.Parse(tbMoney.Text)).ToString() + "\n"; 
                lbInfo.Items.Add(item);

            }
            catch(Exception ex)
            {
            MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {

            Window window = new Window();
            window.Height = 400;
            window.Width = 400;
                if (lbInfo.SelectedItems.Count == 0)
                    throw new Exception("Không có mục list box nào dc chọn");
                string str = "";
                foreach (ListBoxItem item in lbInfo.SelectedItems)
                    str+= item.Content;
                window.Content = str    ;
            window.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public int getAge()
        {
            int age;
            DateTime now = DateTime.Now;
            DateTime date = Convert.ToDateTime(dp.SelectedDate);
            age = now.Year - date.Year;
            if (now.Month < date.Month || (now.Month == date.Month && now.Day < date.Day))
                age--;
            return age;
        }

        public double hoaHong(double tienBan)
        {

            if (tienBan < 1000)
                return 0;
            else if (tienBan >= 1000 && tienBan <= 5000)
                return 0.05 * tienBan;
            return 0.1 * tienBan;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lbInfo.SelectedItems.Count == 0)
                    throw new Exception("Chưa có nhân viên nào được chọn");
                name.Text = "";
                tbMoney.Text = "";
                cbType.SelectedIndex = -1;
                dp.SelectedDate = DateTime.Now;
                name.Focus();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
        }
    }
}
