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

        public static void WriteToFileWithStreamWriter()
        {
            FileInfo file = new FileInfo(@"d:\File.txt");
            FileStream fs = file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);

            byte[] word = Encoding.Default.GetBytes("Hello World");
            fs.Write(word, 0, word.Length);

            fs.Close();
        }

        public static void ReadFromFileWithStreamWriter()
        {
            FileInfo file = new FileInfo(@"d:\File.txt");
            FileStream fs = file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);

            byte[] word = new byte[fs.Length];
            fs.Read(word, 0, (int)fs.Length);

            Console.Write(Encoding.Default.GetChars(word));

            fs.Close();
        }       

    }
}
