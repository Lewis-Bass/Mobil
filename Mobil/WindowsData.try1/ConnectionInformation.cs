
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WindowsData
{
    public class ConnectionInformation : INotifyPropertyChanged
    {
        string _IPAddress;
        /// <summary>
        /// IP address of the connection
        /// </summary>
        public string IPAddress
        {
            get
            {
                return _IPAddress;
            }
            set
            {
                if (_IPAddress != value)
                {
                    _IPAddress = value;
                    OnPropertyChanged("IPAddress");
                }
            }
        }

        //////int _Port;
        ///////// <summary>
        ///////// Port to use on the connection
        ///////// </summary>
        //////public int Port
        //////{
        //////    get
        //////    {
        //////        return _Port;
        //////    }
        //////    set
        //////    {
        //////        if (_Port != value)
        //////        {
        //////            _Port = value;
        //////            OnPropertyChanged("Port");
        //////        }
        //////    }
        //////}

        string _ConnectionName;
        /// <summary>
        /// User name of the connection
        /// </summary>
        public string ConnectionName
        {
            get
            {
                return _ConnectionName;
            }
            set
            {
                if (_ConnectionName != value)
                {
                    _ConnectionName = value;
                    OnPropertyChanged("ConnectionName");
                }
            }
        }

        string _AccessKeyName;
        /// <summary>
        /// Key Name - name of the key associated with the ark
        /// </summary>
        public string AccessKeyName
        {
            get
            {
                return _AccessKeyName;
            }
            set
            {
                if (_AccessKeyName != value)
                {
                    _AccessKeyName = value;
                    OnPropertyChanged("LoginName");
                }
            }
        }

        string _Password;
        /// <summary>
        /// User Password 
        /// </summary>
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                if (_Password != value)
                {
                    _Password = value;
                    OnPropertyChanged("PasswordName");
                }
            }
        }

        bool _IsCurrentConnection = false;
        /// <summary>
        /// GUI ONLY PROPERTY - IS THIS CONNECTION THE CURRENT ONE?
        /// </summary>
        public bool IsCurrentConnection
        {
            get
            {
                return _IsCurrentConnection;
            }
            set
            {
                if (_IsCurrentConnection != value)
                {
                    _IsCurrentConnection = value;
                    OnPropertyChanged("IsCurrentConnection");
                }
            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
