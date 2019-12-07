using System;

namespace CollectHdDataLib
{

    public class ConnectionStatusChangedEventArgs
    {
        public readonly bool Connected;

        public ConnectionStatusChangedEventArgs(bool state)
        {
            Connected = state;
        }
    }

    public class MessageReceivedEventArgs
    {
        public readonly byte[] Data;
        public MessageReceivedEventArgs(byte[] data)
        {
            Data = data;
        }
    }
}

