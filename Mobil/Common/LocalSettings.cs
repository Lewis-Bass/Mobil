using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WindowsData;

namespace Common
{
    public class LocalSettings
    {
        #region Properties

        private UserSettings AllSettings = new UserSettings();

        #endregion

        #region Property Wrappers

        /// <summary>
        /// Integer representing the theme that has been chosen by the user
        /// </summary>
        public int ActiveTheme
        {
            get { return AllSettings.ActiveTheme; }
            set
            {
                if (AllSettings.ActiveTheme != value)
                {
                    AllSettings.ActiveTheme = value;
                    WriteFile();
                }
            }
        }

        /// <summary>
        /// maximum number of connections to show on the left navigator
        /// </summary>
        public int MaxConnections
        {
            get { return AllSettings.MaxConnections; }
            set {
                if (AllSettings.MaxConnections != value)
                {
                    AllSettings.MaxConnections = value;
                    WriteFile();
                }
            }
        }

        /// <summary>
        /// maximum number of files viewed to show on the left navigator
        /// </summary>
        public int MaxFilesViewed
        {
            get { return AllSettings.MaxFilesViewed; }
            set {
                if (AllSettings.MaxFilesViewed != value)
                {
                    AllSettings.MaxFilesViewed = value;
                    WriteFile();
                }
            }
        }


        /// <summary>
        /// maximum number of ?????
        /// </summary>
        public string MaxConnectionsData
        {
            get { return AllSettings.MaxConnectionsData; }
            set {
                if (AllSettings.MaxConnectionsData != value)
                {
                    AllSettings.MaxConnectionsData = value;
                    WriteFile();
                }
            }
        }

        /// <summary>
        /// Maximum number of checked out files to view
        /// </summary>
        public int MaxFilesCheckedOutViewed
        {
            get { return AllSettings.MaxFilesCheckedOutViewed; }
            set {
                if (AllSettings.MaxFilesCheckedOutViewed != value)
                {
                    AllSettings.MaxFilesCheckedOutViewed = value;
                    WriteFile();
                }
            }
        }

        /// <summary>
        /// stores the option selected by the user on check in screen
        /// </summary>
        public bool CheckOutShowOnlyMyFiles
        {
            get { return AllSettings.CheckOutShowOnlyMyFiles; }
            set {
                if (AllSettings.CheckOutShowOnlyMyFiles != value)
                {
                    AllSettings.CheckOutShowOnlyMyFiles = value;
                    WriteFile();
                }
            }
        }

        /// <summary>
        /// shows the option selected by the user on the check in screen
        /// </summary>
        public bool CheckOutRemoveFileAtCheckin
        {
            get { return AllSettings.CheckOutRemoveFileAtCheckin; }
            set {
                if (AllSettings.CheckOutRemoveFileAtCheckin != value)
                {
                    AllSettings.CheckOutRemoveFileAtCheckin = value;
                    WriteFile();
                }
            }
        }

        /// <summary>
        /// Which language was selected by the user
        /// </summary>
        public string Language
        {
            get { return AllSettings.Language; }
            set {
                if (AllSettings.Language != value)
                {
                    AllSettings.Language = value;
                    WriteFile();
                }
            }
        }

        /// <summary>
        /// list of available connections info
        /// </summary>
        public string LastConnectionsData
        {
            get { return AllSettings.LastConnectionsData; }
            set {
                if (AllSettings.LastConnectionsData != value)
                {
                    AllSettings.LastConnectionsData = value;
                    WriteFile();
                }
            }
        }

        #endregion

        #region Constructor

        public LocalSettings()
        {
            ReadFile();
        }

        #endregion

        #region File Handlers


        /// <summary>
        /// read the configuration from the local storage
        /// </summary>
        private void ReadFile()
        {
            if (File.Exists(GlobalValues.UserSettingsStorageLocation))
            {
                XmlSerializer serializer = new XmlSerializer(AllSettings.GetType());
                TextReader textReader = new StreamReader(GlobalValues.UserSettingsStorageLocation);
                AllSettings = (UserSettings)serializer.Deserialize(textReader);
                textReader.Close();
            }
        }

        /// <summary>
        /// write the configuration to the local storage
        /// </summary>
        private void WriteFile()
        {

            if (File.Exists(GlobalValues.UserSettingsStorageLocation))
            {
                File.Delete(GlobalValues.UserSettingsStorageLocation);
            }

            XmlSerializer serializer = new XmlSerializer(AllSettings.GetType());
            TextWriter textWriter = new StreamWriter(GlobalValues.UserSettingsStorageLocation);
            serializer.Serialize(textWriter, AllSettings);
            textWriter.Close();

        }

        #endregion
    }
}
