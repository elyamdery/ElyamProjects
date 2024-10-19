using Microsoft.Maui.Controls;
using System;

namespace Bingie.Views
{
    public partial class StatisticsPage : ContentPage
    {
        public StatisticsPage(int bingeCount)
        {
            InitializeComponent();

            // Set the binge count for the selected day
            BingeCountLabel.Text = $"Binge Count: {bingeCount}";

            // Start the page animation (fade in)
            StartPageAnimation();
        }

        private async void StartPageAnimation()
        {
            // Fade in animation
            this.Opacity = 0;
            await this.FadeTo(1, 500); // Fades in over 0.5 seconds
        }
    }
}
