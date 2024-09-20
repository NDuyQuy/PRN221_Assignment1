using BussinessObject;
using DataAccess.Repository;
using System.Windows;

namespace SalesWPFApp.Admin
{
    /// <summary>
    /// Interaction logic for AddEditOrder.xaml
    /// </summary>
    public partial class AddEditOrder : Window
    {
        public bool IsAdd {  get; set; }
        public Order Order { get; set; }
        public AddEditOrder(Order? order)
        {
            InitializeComponent();
            if(order != null )
            {
                IsAdd = false;
                Order = order;
                lbTitle.Content = "Update Order";
            }
            else
            {
                IsAdd = true;
                Order = new();
                lbTitle.Content = "Add Order";
            }
            DataContext = Order;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(IsAdd)
            {
                try
                {
                    new OrderRepository().AddOrder(Order);
                    MessageBox.Show("Add Success");
                }
                catch (Exception)
                {
                    MessageBox.Show("Add Fail");
                }
            }
            else
            {
                try
                {
                    new OrderRepository().UpdateOrder(Order);
                    MessageBox.Show("Update Success");
                }
                catch (Exception)
                {
                    MessageBox.Show("Update Fail");
                }
            }
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) => Close();
    }
}
