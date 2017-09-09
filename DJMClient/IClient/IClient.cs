using System;

namespace IClient
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
