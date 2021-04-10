using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Quiz
{
    class FileReadOrStream    
    {
        XmlTextWriter serializer;
        private readonly string path;
        public FileReadOrStream(string path)
        {
            this.path = path;
        }
        public void Writeplayer(AllPlayers players)
        {
            using (serializer = new XmlTextWriter(path, Encoding.UTF8))
            {
                serializer.Formatting = Formatting.Indented;
                XmlDictionaryWriter writer = XmlDictionaryWriter.CreateDictionaryWriter(serializer);
                DataContractSerializer ser = new DataContractSerializer(typeof(AllPlayers));
                ser.WriteObject(writer, players);
                //writer.Close();
            }
        }
        public AllPlayers ReadFile()
        {
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            if (fs.Length < 50)
            {
                fs.Close();
                Writeplayer(new AllPlayers());
            }
            else
                fs.Close();
            

            AllPlayers allpls = null;
            using (fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, Encoding.UTF8, new XmlDictionaryReaderQuotas(), null);
                DataContractSerializer ser = new DataContractSerializer(typeof(AllPlayers));
                allpls = (AllPlayers)ser.ReadObject(reader);
            }

            return allpls;
        }

        public void ReadStream(string path, List<string> srt)
        {
            using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader read = new StreamReader(file, Encoding.UTF8))
                {
                    while (read.Peek() > 0)
                        srt.Add(read.ReadLine());
                }
            }
        }
        public void WriteStream(string text, string a)
        {
            using (FileStream file = new FileStream(path, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(file, Encoding.Default))
                {
                    writer.WriteLine(text +"\t" + a);
                }
                //writer.Close(); //закрити потік!!!
            }
        }

    }
}
