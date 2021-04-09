using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    class QuizHead
    {

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
       
        public void AnswersToQuestions(string path, List<string> srt, List<string> answer, Player players)
        {
            string a = "";
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(1251);

            for (int i = 0; i < srt.Count; i++)
            {
                Console.WriteLine(srt[i]);
                a = Console.ReadLine();
                if (a == answer[i])
                    players.Points++;

            }
           
        }
    }
}
