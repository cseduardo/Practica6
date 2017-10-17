using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Practica6;


using Foundation;
using UIKit;
using Xamarin.Forms;
using Practica6.iOS;
using SQLitePCL;
using System.IO;
[assembly:Dependency(typeof(ISQLite_iOS))]
namespace Practica6.iOS
{
    public class ISQLite_iOS : ISQLite
    {
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, filename);
        }
    }
}