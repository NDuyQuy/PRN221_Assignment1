using BussinessObject;
using DataAccess.Repository;
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
    /// Interaction logic for AddUpdateProduct.xaml
    /// </summary>
    public partial class AddUpdateProduct : Window
    {
        public bool IsAdd = false;//true => add || false => edit/update
        public Product Product { get; set; }
        public AddUpdateProduct(Product? product)
        {
            InitializeComponent();
            if (product == null)
            {
                Product = new Product();
                IsAdd = true;
                lbTitle.Content = "Add New Product";
            }
            else
            {
                Product = product;
                IsAdd = false;
                lbTitle.Content = "Update Product";
            }
            this.DataContext = Product;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(IsAdd)
            {
                try
                {
                    Product.CategoryId = cbCategory.SelectedIndex++;
                    new ProductRepository().AddProduct(Product);
                    MessageBox.Show("Product Added Successfully\n" + Product.ToString());
                }
                catch (System.Exception)
                {
                    MessageBox.Show("Product Added Fail");
                }
            }
            else
            {
                try
                {
                    Product.CategoryId = cbCategory.SelectedIndex++;
                    new ProductRepository().UpdateProduct(Product);
                    MessageBox.Show("Product Updated Successfully\n" + Product.ToString());
                }
                catch (System.Exception)
                {
                    MessageBox.Show("Product Updated Fail");
                }
            }
            new ProductManagement().Load_Product();
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded_Category();
            if(IsAdd) spId.Visibility = Visibility.Collapsed;
            else spId.Visibility = Visibility.Visible;
        }
        private void Loaded_Category()
        {
            var categories = new CategoryRepository().GetCategories().ToList();
            List<string> categoriesName = new List<string>();
            foreach (var category in categories)
                categoriesName.Add(category.CategoryName);
            cbCategory.ItemsSource = categoriesName;
        }
       
    }
}
