using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsData
{
    public class UserSettings
    {
        /// <summary>
        /// Integer representing the theme that has been chosen by the user
        /// </summary>
        public int ActiveTheme { get; set; } = 0;

        /// <summary>
        /// maximum number of connections to show on the left navigator
        /// </summary>
        public int MaxConnections { get; set; } = 5;

        /// <summary>
        /// maximum number of files viewed to show on the left navigator
        /// </summary>
        public int MaxFilesViewed { get; set; } = 5;

        /// <summary>
        /// maximum number of ?????
        /// </summary>
        public string MaxConnectionsData { get; set; }

        /// <summary>
        /// Maximum number of checked out files to view
        /// </summary>
        public int MaxFilesCheckedOutViewed { get; set; } = 5;

        /// <summary>
        /// stores the option selected by the user on check in screen
        /// </summary>
        public bool CheckOutShowOnlyMyFiles { get; set; } = true;

        /// <summary>
        /// shows the option selected by the user on the check in screen
        /// </summary>
        public bool CheckOutRemoveFileAtCheckin { get; set; } = false;

        /// <summary>
        /// Which language was selected by the user
        /// </summary>
        public string Language { get; set; } = "English";

        /// <summary>
        /// list of available connections info
        /// </summary>
        public string LastConnectionsData { get; set; }

    }
}
