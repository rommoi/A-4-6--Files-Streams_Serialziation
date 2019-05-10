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
       public static void SericalizationExample()
        {
            var arr = new Song[]
            {
                new Song() {
                    Title = "Title 1",
                    Duration = 247,
                    Lyrics = "Lyrics 1"
                },
                new Song() {
                    Title = "Title 2",
                    Duration = 456,
                    Lyrics = "Lyrics 2"
                }
            };

            XmlSerializer xmlSerializer = new XmlSerializer(arr.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, arr);
                var result = textWriter.ToString();
            }
        }

    }
}
