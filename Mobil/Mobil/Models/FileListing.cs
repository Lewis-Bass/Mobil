using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Mobil.Models
{
    public class FileListing : INotifyPropertyChanged
    {
        string _documentName;
        public string DocumentName
        {
            get
            {
                return _documentName;
            }
            set {
                _documentName = value;
                OnPropertyChanged("DocumentName");
            }
        }

        string _pathName;
        public string PathName
        {
            get
            {
                return _pathName;
            }
            set
            {
                _pathName = value;
                OnPropertyChanged("PathName");
            }
        }
        //public string DocumentDate { get; set; }


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
