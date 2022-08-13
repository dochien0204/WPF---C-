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
using System.Windows.Shapes;

namespace DemoEFCore
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            QLBanHangContext db = new QLBanHangContext();
            Lsp lsp = new Lsp();
            lsp.Maloai = tbMaLsp.Text;
            lsp.Tenloai = tbTenLsp.Text;
            db.Lsps.Add(lsp);
            db.SaveChanges();
            var query = from lspp in db.Lsps
                        select lspp;
            MainWindow mainWindow = new MainWindow();
            mainWindow.dgSource.ItemsSource = query.ToList();
            wd1.Close();
        }
    }
}
