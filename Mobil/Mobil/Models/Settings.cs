using System;
using System.Collections.Generic;
using System.Text;

namespace Mobil.Models
{
    [Serializable]    
    public class Settings
    {
        #region properties

        /// <summary>
        /// List of connections that the user has setup
        /// </summary>
        public List<ConnectionInformation> AllConnnections { get; set; } = new List<ConnectionInformation>();

        public List<Favorite> Favorites { get; set; } = new List<Favorite>();

        /// <summary>
        /// The last time a file check was made for uploading of pictures...
        /// </summary>
        public DateTime LastFileCheck { get; set; } = new DateTime(1990,1,1);

        #endregion



    }
}
