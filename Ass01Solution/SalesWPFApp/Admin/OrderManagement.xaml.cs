using BussinessObject;
using DataAccess.Repository;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SalesWPFApp.Admin
{
    /// <summary>
    /// Interaction logic for OrderManagement.xaml
    /// </summary>
    public partial class OrderManagement : Page
    {
        public OrderManagement()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Load_Order();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            new AddEditOrder(null).ShowDialog();
            Load_Order();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgOrder.SelectedItem is not Order order) MessageBox.Show("Pls select order");
            else
            {
                new AddEditOrder(order).ShowDialog();
                Load_Order();
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            var order = dgOrder.SelectedItem as Order;
            if(order == null)
            {
                MessageBox.Show("Please choose a order to be deleted");
                return;
            }
            var result = MessageBox.Show("Do you want to delete this order?","Confirmation",MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    new OrderRepository().DeleteOrder(order.OrderId);
                }
                catch (Exception)
                {
                    MessageBox.Show("Deleted Fail");
                }
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Load_Order()
        {
            dgOrder.ItemsSource = new OrderRepository().GetOrders().ToList();
        }

        private void btnDetail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var order = dgOrder.SelectedItem as Order;
                if (order == null) MessageBox.Show("Please selected one order to see detail");
                else
                {
                    var orderId = order.OrderId;
                    var orderDetail = new OrderDetailRepository().GetOrderDetails(orderId).ToList();
                    Window dialog = new()
                    {
                        Title = "Order Details",
                        WindowStartupLocation = WindowStartupLocation.CenterScreen,
                        ResizeMode = ResizeMode.NoResize,
                        SizeToContent = SizeToContent.WidthAndHeight
                    };
                    DataGrid dataGrid = new()
                    {
                        AutoGenerateColumns = false,
                        ItemsSource = orderDetail
                    };
                    var propertiesToInclude = new List<string> { "OrderId", "ProductId", "UnitPrice", "Quantity", "Discount" };

                    foreach (var prop in propertiesToInclude)
                    {
                        dataGrid.Columns.Add(new DataGridTextColumn
                        {
                            Header = prop,
                            Binding = new Binding(prop)
                        });
                    }
                    dialog.Content = dataGrid;
                    dialog.ShowDialog();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Show order detail failed");
            }
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            if (StartDate.SelectedDate == null || EndDate.SelectedDate == null)
            {
                MessageBox.Show("Please choose start date and end date before click show report!");
                return;
            }
            var startDate = StartDate.SelectedDate.Value;

            var endDate = EndDate.SelectedDate.Value;

            var sales = new OrderRepository().GetSales<SalesDetail>(startDate, endDate);

            Window dialog = new()
            {
                Title = "Sales Details",
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                ResizeMode = ResizeMode.NoResize,  // Allow resizing
                SizeToContent = SizeToContent.WidthAndHeight // Set size to auto
            };
            DataGrid dataGrid = new()
            {
                AutoGenerateColumns = true,
                ItemsSource = sales  // Set the list as the data source
            };
            dialog.Content = dataGrid;
            dialog.ShowDialog();
        }
    }
}
