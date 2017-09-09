using System;

namespace DJMClient.Interfaces
{
    interface IClient
    {
        #region Methods
        void Connect();
        void Send();
        void Receive();
        void Close();

        #endregion
    }
}
