using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Advence.Lesson_6
{
    public partial class Practice
    {
        /// <summary>
        /// AL6-P1/7-DirInfo. Вывести на консоль следующую информацию о каталоге “c://Program Files”:
        /// Имя
        /// Дата создания
        /// </summary>
        public static void AL6_P1_7_DirInfo()
        {
            //var dn = new DriveInfo("c://Program Files");
            //DateTime fi = Directory.GetCreationTime("c://Program Files");

            //Console.WriteLine($"Name: {dn.Name}, {fi}");
            Console.WriteLine($"{new DriveInfo("c://Program Files").Name}, {Directory.GetCreationTime("c://Program Files")}, {Directory.GetCreationTimeUtc("c://Program Files")}");
        }


        /// <summary>
        /// AL6-P2/7-FileInfo. Получить список файлов каталога и для каждого вывести значение:
        /// Имя
        /// Дата создания
        /// Размер 
        /// </summary>
        public static void AL6_P2_7_FileInfo()
        {
            
            foreach (var item in new DirectoryInfo("c://totalcmd").GetFiles())
            {
                Console.WriteLine($"{item.FullName, -25} _ {item.CreationTime, -25} _ {item.Length, -10} bytes");
            }

        }

        /// <summary>
        /// AL6-P3/7-CreateDir. Создать пустую директорию “c://Program Files Copy”.
        /// </summary>
        public static void AL6_P3_7_CreateDir()
        {
            var cr = Directory.CreateDirectory(@"c://Copy__AAAAA");
        }


        /// <summary>
        /// AL6-P4/7-CopyFile. Скопировать первый файл из Program Files в новую папку.
        /// </summary>
        public static void AL6_P4_7_CopyFile()
        {
            AL6_P3_7_CreateDir();

            var di = new DirectoryInfo("c://totalcmd").GetFiles()[0];
            Console.WriteLine(di.FullName);
            di.CopyTo(System.IO.Path.Combine(@"c://Copy__AAAAA", di.Name), true);
            
            
        }

        /// <summary>
        /// AL6-P5/7-FileChat. Написать программу имитирующую чат. 
        /// Пускай в ней будут по очереди запрашивается реплики для User 1 и User 2 (используйте цикл из 5-10 итераций).  Сохраняйте данные реплики с ником пользователя и датой в файл на диске.
        /// </summary>
        private static void AL6_P5_7_FileChat()
        {
            Console.WriteLine("Enter first Name1:");
            string name1 = Console.ReadLine();
            Console.WriteLine("Enter first Name2:");
            string name2 = Console.ReadLine();

            using(StreamWriter sr = new StreamWriter(@"cha.txt"))
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Enter {name1} phrase");
                    sr.Write(Console.ReadLine());
                    sr.WriteLine();
                    Console.WriteLine($"Enter {name2} phrase");
                    sr.Write(Console.ReadLine());
                    sr.WriteLine();

                    sr.Flush();
                }
            }
        }

        /// <summary>
        /// AL6-P6/7-ConsoleSrlz. (Демонстрация). 
        /// Сериализовать обьект класса Song в XML.Вывести на консоль.
        /// Десериализовать XML из строковой переменной в объект.
        /// </summary>
        public static void AL6_P6_7_ConsoleSrlzn()
        {
            Song song = new Song()
            {
                Title = "Title 1",
                Duration = 247,
                Lyrics = "Lyrics 1"
            };

            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSer = new XmlSerializer(typeof(Song));


            using(StringWriter sw = new StringWriter(sb))
            {
                xmlSer.Serialize(sw, song);        //Serialization
                Console.WriteLine(sw.ToString());

                
            }
            Console.WriteLine();
            using(StringReader sr = new StringReader(sb.ToString())) //using stringBuilder as storage
            {
                Song deserSong = (Song)xmlSer.Deserialize(sr); //deserialization
                Console.WriteLine(deserSong.ToString());       //using overrided method to out object props to Console

            }
           
        }

        /// <summary>
        /// AL6-P7/7-FileSrlz.
        /// Отредактировать предыдущий пример для поддержки сериализации и десериализации в файл.
        /// </summary>
        public static void AL6_P7_7_FileSrlz()
        {
            Song song = new Song()
            {
                Title = "Title 1",
                Duration = 247,
                Lyrics = "Lyrics 1"
            };

            XmlSerializer xmlSer = new XmlSerializer(typeof(Song));

            using(FileStream fs = new FileStream("serializedSong.ss", FileMode.OpenOrCreate))
            {
                xmlSer.Serialize(fs, song);
                Console.WriteLine(song.ToString());
                Console.WriteLine("Object serialized..");
            }
            using(FileStream fs = new FileStream("serializedSong.ss", FileMode.Open))
            {
                Song deserSong = (Song)xmlSer.Deserialize(fs);
                Console.WriteLine("Object deserialized..");
                Console.WriteLine(deserSong.ToString());
            }

        }

    }
}
