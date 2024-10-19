using System;
using Microsoft.Maui.Controls;

namespace Bingie.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            StartClock();
        }

        private void StartClock()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                CurrentTimeLabel.Text = DateTime.UtcNow.AddHours(3).ToString("HH:mm:ss"); // Adjust to Israel Time (UTC+3)
                return true;
            });
        }

        private void OnBingeButtonClicked(object sender, EventArgs e)
        {
            var dot = new BoxView
            {
                Color = Colors.Red,
                WidthRequest = 15, // Make the dot bigger
                HeightRequest = 15, // Make the dot bigger
                Margin = new Thickness(2, 0, 2, 0)
            };

            // Create a new horizontal row every 10 dots
            if (DotsContainer.Children.Count == 0 || (DotsContainer.Children[DotsContainer.Children.Count - 1] as StackLayout).Children.Count >= 10)
            {
                DotsContainer.Children.Add(new StackLayout 
                {
                    Orientation = StackOrientation.Horizontal,
                    Margin = new Thickness(0, 5)
                });
            }

            var currentRow = DotsContainer.Children[DotsContainer.Children.Count - 1] as StackLayout;
            currentRow.Children.Add(dot);
        }
    }
}
