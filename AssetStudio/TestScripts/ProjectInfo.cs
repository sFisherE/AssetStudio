using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ProjectInfo
{
    public static string projectName = "tmp";
    //public static string fileName = "";

    public static bool  dumpRes=true;

    public static string dumpFolder
    {
        get
        {
            //if (!string.IsNullOrEmpty(fileName))
            //{
            //    return string.Format("Assets/{0}/{1}/", ProjectInfo.projectName, fileName);
            //}
            return string.Format("Assets/{0}/", ProjectInfo.projectName);
        }
    }
}
