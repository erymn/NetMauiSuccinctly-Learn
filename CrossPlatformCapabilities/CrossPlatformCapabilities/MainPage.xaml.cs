using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace CrossPlatformCapabilities
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();

            WeakReferenceMessenger.Default.Register<ConnectionChangeMessage>(
                this, async (sender, message) =>
                {
                    await ShowConnectionSnackbarAsync(message.Value);
                }
                );

            WeakReferenceMessenger.Default.Register<BatteryStatusChangeMessage>(
                this, (sender, message) =>
                {
                    ManageBatteryLevelChanged();
                }
                );
        }

        private void ManageBatteryLevelChanged()
        {
            FileHelper.WriteData("test data");
        }

        private async Task ShowConnectionSnackbarAsync(bool value)
        {
            var options = new SnackbarOptions
            {
                BackgroundColor = Colors.PaleVioletRed,
                TextColor = Colors.White,
                ActionButtonTextColor = Colors.White,
                CornerRadius = new CornerRadius(10),
                Font = Microsoft.Maui.Font.SystemFontOfSize(14)
            };

            string message;

            switch (value)
            {
                case true:
                    message = "Internet connection available";
                    break;
                case false:
                    message = "Internet connection not available";
                    break;
            }

            await this.DisplaySnackbar(message, visualOptions: options);
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

    }
}
