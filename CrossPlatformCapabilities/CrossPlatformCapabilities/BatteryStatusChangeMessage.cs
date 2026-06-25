using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossPlatformCapabilities
{
    public class BatteryStatusChangeMessage : ValueChangedMessage<bool>
    {
        public BatteryStatusChangeMessage(bool value) : base(value)
        {
        }
    }
}
