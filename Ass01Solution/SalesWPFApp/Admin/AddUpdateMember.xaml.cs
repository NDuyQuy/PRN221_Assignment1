using System.Windows;
using BussinessObject;
using DataAccess.Repository;
namespace SalesWPFApp.Admin
{
    /// <summary>
    /// Interaction logic for AddUpdateMember.xaml
    /// </summary>
    public partial class AddUpdateMember : Window
    {
        public Member Member { get; set; }
        public bool IsAddMember { get; set; }
        public AddUpdateMember(Member? member)
        {
            InitializeComponent();
            if (member == null)
            {
                Member = new Member();
                IsAddMember = true;
                lbTitle.Content = "Add New Member";
            }
            else
            {
                Member = member;
                lbTitle.Content = "Update Member";
                IsAddMember = false;
            }
            this.DataContext = Member;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(IsAddMember) spId.Visibility = Visibility.Collapsed;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(IsAddMember)
            {
                try
                {
                    Member.Password = "123456";
                    new MemberRepository().AddMember(Member);
                    MessageBox.Show("Member Added Succesfully");
                }
                catch (Exception)
                {
                    MessageBox.Show("Member Added Fail");
                }
            }
            else
            {
                try
                {
                    new MemberRepository().UpdateMember(Member);
                    MessageBox.Show("Member Updated Succesfully");
                }
                catch (Exception)
                {
                    MessageBox.Show("Member Updated Fail");
                }
            }
            new MemberManagement().Load_Member();
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) => Close();
    }
}
