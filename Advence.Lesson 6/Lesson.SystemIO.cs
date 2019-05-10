using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Advence.Lesson_6
{
    public partial class Lesson
    {
        public static void SysteIOUsageExample()
        {
            var driveInfo = new DriveInfo("d");
            var dirInfo = new DirectoryInfo("d://temp");
            var fileInfo = new FileInfo("c://pagefile.sys");

            Directory.Delete("d://temp");
            File.Open("c://pagefile.sys", FileMode.Open);
        }       
    }
}
