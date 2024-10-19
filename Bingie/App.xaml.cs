// App.xaml.cs
using Microsoft.Maui.Controls;
using Bingie.Views.Auth;
using Bingie.Services;

namespace Bingie
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage(new AuthService())); // Initialize with AuthService
        }
    }
}
