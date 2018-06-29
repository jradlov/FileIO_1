using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Xamarin.Forms;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FileIO_1.Droid;
using Android;

[assembly: Dependency(typeof(FileService))]
namespace FileIO_1.Droid
{
    public class FileService : IFile_IO
    {
        public FileService() {}

        public void WriteTextFile(string fileName)
        {
            var permissions = new string[] { Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage };
            RequestPermissions(permissions, 77);

            //var path = Android.OS.Environment.DirectoryDownloads;
            //var path = Android.OS.Environment.ExternalStorageDirectory.Path;
            //var path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            var path = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).ToString();
            var filePath = System.IO.Path.Combine(path, fileName);

            if(!System.IO.File.Exists(filePath))
            {
                System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, true);
                writer.Write("ok, I'm writing some text to my text file...");
            }

        }

        private void RequestPermissions(string[] permissions, int v)
        {
            throw new NotImplementedException();
        }
    }
}