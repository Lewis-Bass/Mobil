using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Mobil.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;


[assembly: Dependency(typeof(Mobil.Droid.DependencyServices.FileSystemAccess))]
namespace Mobil.Droid.DependencyServices
{
    public class FileSystemAccess : IFileSystemAccess
    {
        public string DocumentsPath()
        {
            return System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        }


        //public string PicturePath() => Android.App.Application.Context
        //   .GetExternalFilesDir(null).AbsolutePath;

        //public string PicturePath() => Context.GetExternalFilesDir(Android.OS.Environment.DirectoryPictures).Path; 

        //public string PicturePath() => Android.App.Application.Context
        //    .GetExternalFilesDir(Android.OS.Environment.DirectoryPictures).AbsolutePath;

        public string PicturePath()
        {
            string musicDirectoryPath =
Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures).ToString();

            return musicDirectoryPath;

            
            //    var xxx = Android.Content.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryPictures);
            //    //var xxx = Android.Content.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryPictures);
            //    return System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures);            
            //    //return System.Environment.GetFolderPath(System.Environment.System);

        }

        public string VideoPath()
        {
            return System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyVideos);
        }
    }
}