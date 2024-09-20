using BussinessObject;
using System.Windows;
using System.Windows.Controls;
using DataAccess.Repository;
namespace SalesWPFApp.Admin
{
    /// <summary>
    /// Interaction logic for ProductManagement.xaml
    /// </summary>
    public partial class ProductManagement : Page
    {
        public ProductManagement()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Load_Category();
            Load_Product();
        }
        private void Load_Category()
        {
            var categories = new CategoryRepository().GetCategories().ToList();
            List<string> categoriesName = new List<string>();
            foreach (var category in categories)
                categoriesName.Add(category.CategoryName);
            cbCategory.ItemsSource = categoriesName;
        }

        public void Load_Product()
        {
            dgProduct.ItemsSource = new ProductRepository().GetProducts().ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddUpdateProduct window = new AddUpdateProduct(null);
            window.Show();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var product = dgProduct.SelectedItem as Product;
            if (product != null)
            {
                AddUpdateProduct window = new AddUpdateProduct(product);
                window.Show();
            }
            else MessageBox.Show("Please select the product to be edit");
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            int deletedProductId = int.Parse(txtId.Text);
            try
            {
                new ProductRepository().DeleteProduct(id:deletedProductId);
                Load_Product();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var type = cbType.Text;
            Product? product = null;
            List<Product> products = null;
            string result = "Product Availble\n";
            switch (type)
            {
                case "id":
                    try
                    {
                        product = new ProductRepository().GetProduct(int.Parse(txtSearch.Text));
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Invalid id number");
                        return;
                    }
                    break;
                case "name":
                    product = new ProductRepository().GetProduct(txtSearch.Text);
                    break;
                case "price":
                    products = new ProductRepository().GetProductsByPrice(txtSearch.Text).ToList();
                    if (products.Count == 0)
                    {
                        MessageBox.Show("No Product Available");
                        return ;
                    }
                    foreach (var prod in products)
                        result += prod.ProductName+"\n";
                    MessageBox.Show(result);
                    return;
                case "units in stock":
                    try
                    {
                        products = new ProductRepository()
                            .GetProductsByQuantity(int.Parse(txtSearch.Text)).ToList();
                        if(products.Count == 0)
                        {
                            MessageBox.Show("No Product Available");
                            return ;
                        }
                        foreach(var prod in  products)
                            result += prod.ToString() + "\n";
                        MessageBox.Show(result);
                        return;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Invalid quantity number");
                        return;
                    }
                default:
                    MessageBox.Show("Please choose search type first!");
                    return;
            }
            if (product != null) MessageBox.Show(product?.ToString());
            else MessageBox.Show("Product doesnt exist!");
        }
    }
}
