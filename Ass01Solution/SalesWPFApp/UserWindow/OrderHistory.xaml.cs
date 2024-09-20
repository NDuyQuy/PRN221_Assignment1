using System.Windows;
using DataAccess.Repository;
namespace SalesWPFApp.UserWindow
{
    /// <summary>
    /// Interaction logic for OrderHistory.xaml
    /// </summary>
    public partial class OrderHistory : Window
    {
        private readonly int _memberId;
        public OrderHistory(int memberId)
        {
            InitializeComponent();
            _memberId = memberId;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgOrder.ItemsSource = new OrderRepository().GetOrders(_memberId).ToList();
        }
    }
}
