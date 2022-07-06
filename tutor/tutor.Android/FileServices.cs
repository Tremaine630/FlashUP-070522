using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using tutor.Droid;
using tutor.services.File;

[assembly: Xamarin.Forms.Dependency(typeof(FileServices))]
namespace tutor.Droid
{
    public class FileServices:IFileService
    {
        public string GetRootPath()
        {
            return Application.Context.GetExternalFilesDir(null).ToString();
        }
        public void CreateFile(string[] text, string name)
        {
            var filename = name;
            var destination = Path.Combine(GetRootPath(), filename);
            File.WriteAllLines(destination, text);
        }
    }
}