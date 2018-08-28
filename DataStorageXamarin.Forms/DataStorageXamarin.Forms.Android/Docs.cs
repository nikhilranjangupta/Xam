using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace DataStorageXamarin.Forms.Droid
{
    class Docs
    {
        /// <summary>
        /// IOS
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        //public static string GetLocalFilePath(string filename)
        //{
        //    string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        //    string libFolder = System.IO.Path.Combine(docFolder, "..", "Library");

        //    if (!System.IO.Directory.Exists(libFolder))
        //    {
        //        System.IO.Directory.CreateDirectory(libFolder);
        //    }

        //    return System.IO.Path.Combine(libFolder, filename);
        //}



            
/////Windows
//        public static string GetLocalFilePath(string filename)
//        {
//            string path = global::Windows.Storage.ApplicationData.Current.LocalFolder.Path;
//            return System.IO.Path.Combine(path, filename);
//        }
    }
}