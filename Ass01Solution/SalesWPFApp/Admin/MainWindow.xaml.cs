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

namespace SalesWPFApp.Admin
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            frMain.Content = new MemberManagement();
        }

        private void mnProduct_Click(object sender, RoutedEventArgs e)
        {
            frMain.Content = new ProductManagement();
        }

        private void mnMember_Click(object sender, RoutedEventArgs e)
        {
            frMain.Content = new MemberManagement();
        }

        private void mnOrder_Click(object sender, RoutedEventArgs e)
        {
            frMain.Content = new OrderManagement();
        }
    }
}
