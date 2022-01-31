using Mobil.Interfaces;
using Mobil.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel;

namespace Mobil.ViewModels
{
    public class AddFileViewModel : BaseViewModel //, INotifyPropertyChanged
    {

        //public DateTime FileCheck { get; set; }

        public ObservableCollection<FileListing> FilesToUpload { get; set; } = new ObservableCollection<FileListing>();
        //public ICommand LoadAddFileCommand { get; protected set; }
        //public ICommand AddFilesCommand { get; protected set; }

        public AddFileViewModel()
        {
            //LoadAddFileCommand = new Command(() => ExecuteLoadAddFileCommand());
            //AddFilesCommand = new Command(async () => await ExecuteAddFilesCommand());
        }

        public void OnAppearing()
        {
            IsBusy = true;
            //ExecuteLoadAddFileCommand();
            IsBusy = false;
        }

        /// <summary>
        /// loads all of the search criteria into the screen
        /// </summary>
        /// <returns></returns>
        public async Task ExecuteLoadAddFileCommand()
        {
            IsBusy = true;

            try
            {

                FilesToUpload.Clear();

                //FilesToUpload.Add(
                //                new Models.FileListing
                //                {
                //                    DocumentName = "DOC1",
                //                    PathName = "/Doc1",
                //                });
                //FilesToUpload.Add(
                //                new Models.FileListing
                //                {
                //                    DocumentName = "DOC2",
                //                    PathName = "DOC2/Doc2",
                //                });

                ////Files.Clear();

                ////// load the date
                ////SystemSettings.ReadSettings();

                ////FileCheck = SystemSettings.GlobalSettings.LastFileCheck;

                //////var dir = Environment.GetExternalStoragePublicDirectory(Environment.DirectoryPictures);

                //IFileSystemAccess service = DependencyService.Get<IFileSystemAccess>();
                //FileListing(service.PicturePath());

                //FileListing("/"); PermissionException denied exception thrown


                //////FileListing(service.DocumentsPath());
                //////FileListing(service.VideoPath());

                //////FileListing(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
                //////FileListing(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
                //////FileListing(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos));
                //////FileListing(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));

                ////// load the document files
                ///



                //FileSystem.AppDataDirectory




            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        //private void FileListing(string path)
        //{
        //    System.Diagnostics.Debug.WriteLine(path);
        //    if (Directory.Exists(path))
        //    {
        //        foreach (string file in Directory.GetFiles(path, "*.*", SearchOption.AllDirectories))
        //        {
        //            var parts = file.Split(new char[] { '\\', '/' }, StringSplitOptions.RemoveEmptyEntries);
        //            var name = parts[(parts.Length - 1)];
        //            Files.Add(new FileListing { PathName = file, DocumentName = name });
        //        }
        //    }
        //}




        //        private void ProcessNewFiles(IEnumerable<FileResult> result)
        //        {
        //            FilesToUpload.Add(
        //                                new Models.FileListing
        //                                {
        //                                    DocumentName = "DOC1",
        //                                    PathName = "/Doc1",
        //                                });
        //            FilesToUpload.Add(
        //                            new Models.FileListing
        //                            {
        //                                DocumentName = "DOC2",
        //                                PathName = "DOC2/Doc2",
        //                            });
        //            //foreach (var f in result)
        //            //{
        //            //    if (!FilesToUpload.Any(r => r.DocumentName == f.FileName))
        //            //    {
        //            //        FilesToUpload.Add(
        //            //            new Models.FileListing
        //            //            {
        //            //                DocumentName = f.FileName,
        //            //                PathName = f.FullPath,
        //            //            });
        //            //    }
        //            //}
        //            //OnPropertyChanged("FilesToUpload");
        //        }

        //#region INotifyPropertyChanged

        //public event PropertyChangedEventHandler PropertyChanged;

        //        protected void OnPropertyChanged(string propertyName)
        //        {
        //            if (PropertyChanged != null)
        //            {
        //                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //            }
        //        }

        //        #endregion

    }
}
