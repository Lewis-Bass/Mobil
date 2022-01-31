using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Mobil.Models
{
    public static class SystemSettings
    {
        #region properties and constants

        public static Settings GlobalSettings { get; set; } = new Settings();

        private static string FileName = "SaphSettings.xml";

        #endregion

        #region read 

        /// <summary>
        /// Read the settings file into the xml structure
        /// </summary>
        /// <returns></returns>
        public static bool ReadSettings()
        {
            string fileName = LocalFileName();
            //File.Delete(fileName);
            if (File.Exists(fileName))
            {
                var text = File.ReadAllText(fileName);
                XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                TextReader textReader = new StreamReader(fileName);
                GlobalSettings = (Settings)serializer.Deserialize(textReader);
                textReader.Close();
            }
            return true;
        }

        #endregion

        #region write

        /// <summary>
        /// write the xml file
        /// </summary>
        /// <returns></returns>
        public static bool WriteSettings()
        {
            string fileName = LocalFileName();

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            XmlSerializer serializer = new XmlSerializer(GlobalSettings.GetType());
            TextWriter textWriter = new StreamWriter(fileName);
            serializer.Serialize(textWriter, GlobalSettings);
            textWriter.Close();

            return true;
        }

        #endregion

        #region Delete Connection

        public static void DeleteConnectionSetting(string connectionName)
        {
            ReadSettings();
            var del = GlobalSettings.AllConnnections.FirstOrDefault(r => r.ConnectionName == connectionName);
            if (del != null)
            {
                GlobalSettings.AllConnnections.Remove(del);
                WriteSettings();
            }
        }

        #endregion

        #region Add Favorite

        public static void AddFavorites(Binder[] binders)
        {
            ReadSettings();
            var connName = (App.CurrentConnectionInformation != null) ? App.CurrentConnectionInformation.ConnectionName : string.Empty;
            foreach (var b in binders)
            {
                if (!GlobalSettings.Favorites.Any(r => r.FavoriteID == b.BinderID))
                {
                    GlobalSettings.Favorites.Add(new Favorite { ConnectionName = connName, FavoriteID = b.BinderID, FavoriteName = b.BinderName });
                }
            }
            WriteSettings();
        }
        #endregion

        #region Delete Favorite

        public static void DeleteFavorite(Favorite item)
        {
            ReadSettings();
            var remove = GlobalSettings.Favorites.FirstOrDefault(r => r.FavoriteName == item.FavoriteName && r.ConnectionName == item.ConnectionName);
            if (remove != null)
            {
                GlobalSettings.Favorites.Remove(remove);
                WriteSettings();
            }
           
        }

        #endregion

        #region Common

        /// <summary>
        /// Get the full path to the local file
        /// </summary>
        /// <returns></returns>
        private static string LocalFileName()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, FileName);

            return filePath;
        }

        #endregion
    }
}
