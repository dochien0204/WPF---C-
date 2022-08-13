using DemoEFCore.Models;
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

namespace DemoEFCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static QLBanHangContext db = new QLBanHangContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Test()
        {
            Lsp lsp = new Lsp();
            Sp sp = new Sp();
            QLBanHangContext db = new QLBanHangContext();
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Taoj theer hieenj lowps Context
            
            //truy van sd linq
            var query = from lsp in db.Lsps
                        select lsp;
            //hien thi du lieu len listbox
            dgSource.ItemsSource = query.ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Window1 window1 = new Window1();
            window1.Show();
            var query = from lsp in db.Lsps
                        select lsp;
            dgSource.ItemsSource = query.ToList();
        }
    }
}
