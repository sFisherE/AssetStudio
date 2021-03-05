using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using AssetStudio;
//using Newtonsoft.Json;
//using TGASharpLib;

namespace AssetStudio
{
    internal static class Exporter
    {
        public static string FixFileName(string str)
        {
            if (str.Length >= 260) return Path.GetRandomFileName();
            return Path.GetInvalidFileNameChars().Aggregate(str, (current, c) => current.Replace(c, '_'));
        }
        public static bool TryExportFile(string dir, string fileName, string extension, out string fullPath)
        {
            //string basePath = string.Format("Assets/{0}/", ProjectInfo.dumpFolder);
            fileName = FixFileName(fileName);
            dir = ProjectInfo.dumpFolder + dir;
            fullPath = Path.Combine( dir, fileName + extension);
            if(!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            fullPath = Path.Combine(dir, fileName/* + item.UniqueID*/ + extension);
            //if (!File.Exists(fullPath))
            //{
            //    Directory.CreateDirectory(dir);
            //    return true;
            //}
            return true;
        }
    }
}
