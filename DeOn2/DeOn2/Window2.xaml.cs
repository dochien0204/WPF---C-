using DeOn2.Models;
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

namespace DeOn2
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        QuanLySanPhamDBContext db = new QuanLySanPhamDBContext();
        public Window2()
        {
            InitializeComponent();
        }

        private void Window2_Loaded(object sender, RoutedEventArgs e)
        {
 
            
        }
    }
}
