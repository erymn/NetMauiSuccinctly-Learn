using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossPlatformCapabilities
{
    public class ConnectionChangeMessage : ValueChangedMessage<bool>
    {
        public ConnectionChangeMessage(bool value) : base(value)
        {
        }
    }
}
