using System;
using System.Xml.Serialization;

namespace Advence.Lesson_6
{
    //[Serializable]
    public class Song
    {
        public string Title;
        public int Duration;

       // [NonSerialized]
        [XmlIgnore]
        public string Lyrics;
    }
}
