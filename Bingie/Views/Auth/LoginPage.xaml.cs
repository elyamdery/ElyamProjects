// Views/Auth/LoginPage.xaml.cs
using Bingie.Models;
using Bingie.Services;
using Microsoft.Maui.Controls;

namespace Bingie.Views.Auth
{
    public partial class LoginPage : ContentPage
    {
        private readonly AuthService _authService;

        public LoginPage(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            var username = UsernameEntry.Text;
            var password = PasswordEntry.Text;

            var user = await _authService.LoginUser(username, password);

            if (user != null)
            {
                // Handle successful login (e.g., navigate to the main page)
                await DisplayAlert("Success", "Login successful!", "OK");
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                // Handle failed login
                await DisplayAlert("Error", "Invalid username or password.", "OK");
            }
        }

        private void OnRegisterClicked(object sender, EventArgs e)
        {
            // Navigate to the RegistrationPage
            Navigation.PushAsync(new RegistrationPage(_authService));
        }
    }
}
