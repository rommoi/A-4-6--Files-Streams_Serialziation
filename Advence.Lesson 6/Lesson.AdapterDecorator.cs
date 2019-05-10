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
        public static void WriteToFileWithStreamWriter_Adapter()
        {
            FileInfo file = new FileInfo(@"d:\File.txt");
            FileStream fs = file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);

            StreamWriter sw = new StreamWriter(fs, Encoding.Default);
            sw.Write("Hello World");
            sw.Close();




            StreamWriter sw2 = new StreamWriter(@"d:\File.txt");
            sw2.Write("Hello World");
            sw2.Close();
        }

        public static void BufferedStream_Decorator()
        {
            FileInfo file = new FileInfo(@"d:\File.txt");

            using (FileStream fileStream = file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (BufferedStream bs = new BufferedStream(fileStream, 10000))
                {
                    for (int i = 1; i < 100; i++)
                    {
                        var data = Encoding.Default.GetBytes($"{i}). Hello World\n");
                        bs.Write(data, 0, data.Length);
                    }
                }
            }

        }
        
    }
}
