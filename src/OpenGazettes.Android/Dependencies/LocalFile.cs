using System;
using System.IO;
using Android.Content;
using OpenGazettes.Dependencies;
using Xamarin.Essentials;
using File = Java.IO.File;
using Uri = Android.Net.Uri;

namespace OpenGazettes.Droid.Dependencies
{
    public class LocalFile : ILocalFile
    {
        private Context mContext;

        public LocalFile(Context context)
        {
            mContext = context;
        }

        public void SavePictureToDisk(string name, byte[] data)
        {
            if (data != null)
            {
                var dir = mContext.FilesDir;
                var pictures = dir.AbsolutePath;
                //adding a time stamp time file name to allow saving more than one image... otherwise it overwrites the previous saved image of the same name

                string filePath = System.IO.Path.Combine(pictures, name);
                try
                {
                    System.IO.File.WriteAllBytes(filePath, data); //mediascan adds the saved image into the gallery
                    var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                    mediaScanIntent.SetData(Uri.FromFile(new File(filePath)));
                    Xamarin.Forms.Forms.Context.SendBroadcast(mediaScanIntent);
                }
                catch (System.Exception e)
                {
                    System.Console.WriteLine(e.ToString());
                }
            }
        }

        public void DeletePictureFromDisk(string filename)
        {
            try
            {
                var dir = mContext.FilesDir;
                var pictures = dir.AbsolutePath;
                string filePath = System.IO.Path.Combine(pictures, filename);
                new Java.IO.File(filePath).Delete();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public string GetFile(string filename)
        {
            var dir = mContext.FilesDir;
            var pictures = dir.AbsolutePath;
            string filePath = System.IO.Path.Combine(pictures, filename);

            return filePath;
        }

        public bool FileExists(string filename)
        {
            var dir = mContext.FilesDir;
            var pictures = dir.AbsolutePath;
            string filePath = System.IO.Path.Combine(pictures, filename);
            return System.IO.File.Exists(filePath);
        }

        public string SaveTempFile(string filename, byte[] bytes)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filePath = System.IO.Path.Combine(documentsPath, filename);
            System.IO.File.WriteAllBytes(filePath, bytes);

            return filePath;
        }
    }
}