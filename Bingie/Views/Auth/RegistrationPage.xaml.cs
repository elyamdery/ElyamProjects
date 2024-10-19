// Views/Auth/RegistrationPage.xaml.cs
using Bingie.Models;
using Bingie.Services;
using Microsoft.Maui.Controls;
using System;

namespace Bingie.Views.Auth
{
    public partial class RegistrationPage : ContentPage
    {
        private readonly AuthService _authService;

        public RegistrationPage(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            try
            {
                // Get the entered username and password
                var username = UsernameEntry.Text;
                var password = PasswordEntry.Text;

                // Validate inputs before attempting to register
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    await DisplayAlert("Error", "Username and password cannot be empty.", "OK");
                    return; // Exit early if validation fails
                }

                // Attempt to register the user
                var user = await _authService.RegisterUser(username, password);

                if (user != null)
                {
                    // Handle successful registration (e.g., navigate back to LoginPage)
                    await DisplayAlert("Success", "Registration successful!", "OK");
                    await Navigation.PopAsync(); // Navigate back to the login page or previous page
                }
                else
                {
                    // Handle registration failure (e.g., user already exists)
                    await DisplayAlert("Error", "User already exists or registration failed.", "OK");
                }
            }
            catch (Exception ex)
            {
                // Catch any exceptions that occur during registration
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
    }
}
