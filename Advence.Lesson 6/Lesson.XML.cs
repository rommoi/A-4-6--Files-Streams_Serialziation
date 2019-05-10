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
        public static void XMLReaderExample()
        {
            using (XmlReader reader = XmlReader.Create("XMLFile.xml"))
            {
                Song song = null;
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        if (reader.Name == "Song")
                            song = new Song();

                        if (reader.Name == "Title")
                        {
                            reader.Read();
                            song.Title = reader.Value;
                        }
                    }
                }
            }
        }

        public static void XMLDocumentExample()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("XMLFile.xml");

            XmlElement arraysOfSong = xDoc.DocumentElement;
            foreach (XmlNode songNode in arraysOfSong)
            {
                var song = new Song();
                foreach (XmlNode property in songNode.ChildNodes)
                {
                    if (property.Name == "Title")
                        song.Title = property.InnerText;
                    //...
                }
            }
        }
    }
}
