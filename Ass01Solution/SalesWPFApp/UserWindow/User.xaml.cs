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

namespace SalesWPFApp.UserWindow
{
    /// <summary>
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class User : Window
    {
        public bool IsEdit { get; set; }
        public Member Mem { get; set; }
        public User(Member member)
        {
            InitializeComponent();
            DataContext = this;
            Mem = member;
            IsEdit = false;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            IsEdit = !IsEdit;
            SetReadOnlyMode();
            SetButtonVisibility();
        }

        private void btnViewOrderHistory_Click(object sender, RoutedEventArgs e)
        {
            OrderHistory orderHistoryWindow = new OrderHistory(Mem.MemberId);
            orderHistoryWindow.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetReadOnlyMode();
            SetMemberValue();
        }

        private void SetReadOnlyMode()
        {
            txtEmail.IsReadOnly = !IsEdit;
            txtCompanyName.IsReadOnly = !IsEdit;
            txtCity.IsReadOnly = !IsEdit;
            txtCountry.IsReadOnly = !IsEdit;
        }

        private void SetMemberValue()
        {
            txtEmail.Text = Mem.Email;
            txtCompanyName.Text = Mem.CompanyName;
            txtCity.Text = Mem.City;
            txtCountry.Text = Mem.Country;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Mem.Email = txtEmail.Text;
                Mem.City = txtCity.Text;
                Mem.CompanyName = txtCompanyName.Text;
                Mem.Country = txtCountry.Text;
                new MemberRepository().UpdateMember(Mem);
                SetMemberValue();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            IsEdit = !IsEdit;
            SetButtonVisibility() ;
            SetReadOnlyMode();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            IsEdit = !IsEdit;
            SetReadOnlyMode();
            SetButtonVisibility();
        }
        private void SetButtonVisibility()
        {
            if (IsEdit)
            {
                btnEdit.Visibility = Visibility.Hidden; // Hide Edit button
                btnSave.Visibility = Visibility.Visible;   // Show Save button
                btnCancel.Visibility = Visibility.Visible; // Show Cancel button
            }
            else
            {
                btnEdit.Visibility = Visibility.Visible;   // Show Edit button
                btnSave.Visibility = Visibility.Collapsed; // Hide Save button
                btnCancel.Visibility = Visibility.Collapsed; // Hide Cancel button
            }
        }

    }
}
