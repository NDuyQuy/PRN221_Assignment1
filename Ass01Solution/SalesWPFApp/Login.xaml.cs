using System.IO;
using System.Windows;
using Microsoft.Extensions.Configuration;
using DataAccess.Repository;
using SalesWPFApp.UserWindow;
using SalesWPFApp.Admin;
namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Password;

            if(isAdmin(email,password))
            {
                MainWindow adminWindow = new MainWindow();
                adminWindow.Show();
                Close();
            }
            else
            {
                try
                {
                    var memRep = new MemberRepository().Login(email, password);
                    if (memRep == null) MessageBox.Show("Email or Password Invalid. Please try again");
                    else
                    {
                        Window userWindow = new User(memRep);
                        userWindow.Show();
                        Close();
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private bool isAdmin(string email, string password)
        {
            using StreamReader r = new StreamReader("appsettings.json");
            string json = r.ReadToEnd();
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();
            string? adminEmail = configuration["admin:email"];
            string? adminPass = configuration["admin:password"];
            if (email == adminEmail && password == adminPass) return true;
            return false;
        }


    }
}
