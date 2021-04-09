using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    class HeadClass
    {
        FileReadOrStream file;
        AllPlayers allPlayers;
        Player player;
        QuizHead quizHead;
        public HeadClass()
        {
            file = new FileReadOrStream("Email_Pas.xml");
            allPlayers = new AllPlayers();
            player = new Player();
            quizHead = new QuizHead();
            allPlayers = file.ReadFile();
        }

        public void menu()
        {
            List<string> srt = new List<string>();    //локальні змінні треба тут і зараз
            List<string> answer= new List<string>();
            Console.WriteLine("Choose Reg -->1\nLog -->2 ");
            int a = Convert.ToInt32(Console.ReadLine());

           
            quizHead.ReadStream("Quiz.txt", srt);
            quizHead.ReadStream("Quiz_answer.txt", answer);

           
            if (a == 1)
            {
                Register.Reg_new_User(player, allPlayers);
                Console.Clear();
                Console.WriteLine("Choose\n 1 - Start quiz\n2 - Exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        quizHead.AnswersToQuestions("Quiz_answer.txt", srt, answer, player);
                        break;
                    default:
                        break;
                }
                file.Writeplayer(allPlayers);
            }
            if (a == 2)
            {
                var r = Register.Log_User(player, allPlayers);
                file.Writeplayer(allPlayers);

                Console.Clear();
                quizHead.AnswersToQuestions("Quiz_answer.txt", srt, answer, r);
                file.Writeplayer(allPlayers);
            } 
        
        }
    }
}
