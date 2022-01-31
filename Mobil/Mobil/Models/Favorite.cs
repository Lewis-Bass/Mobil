using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Mobil.Models
{
    [Serializable]
    public class Favorite : INotifyPropertyChanged
    {
        /// <summary>
        /// Ark ID for the favorite search
        /// </summary>
        public string FavoriteID { get; set; }

        /// <summary>
        /// Name to display to the user
        /// </summary>
        public string FavoriteName { get; set; }

        /// <summary>
        /// The name of the connection that can process the favorite
        /// </summary>
        public string ConnectionName { get; set; }


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
