using Android.Hardware;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace CrossPlatformCapabilities
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
            Battery.EnergySaverStatusChanged += Battery_EnergySaverStatusChanged;
        }

        private void Battery_EnergySaverStatusChanged(object? sender, EnergySaverStatusChangedEventArgs e)
        {
            //Remove the chargeLevel check if your APP implement background services
            WeakReferenceMessenger.Default.Send(new BatteryStatusChangeMessage(e.EnergySaverStatus == EnergySaverStatus.On &&
                Battery.ChargeLevel <= 0.2));
        }

        protected override void OnStart()
        {
            base.OnStart();
            WeakReferenceMessenger.Default.Send(new ConnectionChangeMessage(
               Connectivity.NetworkAccess == NetworkAccess.Internet
               ));
        }
        private void Connectivity_ConnectivityChanged(object? sender, ConnectivityChangedEventArgs e)
        {
            WeakReferenceMessenger.Default.Send(new ConnectionChangeMessage(
                e.NetworkAccess == NetworkAccess.Internet
                ));
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}