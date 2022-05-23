using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Utilities.Helpers
{
    public static class Helper
    {
        public static string GetFilePath(string root, string folder,string fileName)
        {
            return Path.Combine(root, folder, fileName);
        }

        public static void DeleteFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
