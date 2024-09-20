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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SalesWPFApp.Admin
{
    /// <summary>
    /// Interaction logic for MemberManagement.xaml
    /// </summary>
    public partial class MemberManagement : Page
    {
        public MemberManagement()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var type = cbType.Text;
            Member? member = null;
            switch(type)
            {
                case "id":
                    try
                    {
                        member = new MemberRepository().GetMember(int.Parse(txtSearch.Text));
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("Invalid id number");
                        return;
                    }                    
                    break;
                case "email":
                    new MemberRepository().GetMember(txtSearch.Text);
                    break;
                default:
                    MessageBox.Show("Please choose search type first!");
                    return;
            }
            if (member != null) MessageBox.Show(member?.ToString());
            else MessageBox.Show("Member doesnt exist!");
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
           new AddUpdateMember(null).Show();
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedMember = dgMember.SelectedItem as Member;
            if (selectedMember == null) MessageBox.Show("Please selected a member first!");
            else new AddUpdateMember(selectedMember).Show();
        }
        private void btnDel_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                int memID = int.Parse(txtId.Text);
                new MemberRepository().DeleteMember(memID);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Load_Member();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Load_Member();
        }

        public void Load_Member()
        {
            dgMember.ItemsSource = new MemberRepository().GetMembers().ToList();   
        }
    }
}
