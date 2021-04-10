using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Timers;

namespace Quiz
{
    class HeadClass
    {
        FileReadOrStream file;
        AllPlayers allPlayers;
        Player player;
        QuizHead quizHead;
        Best_Player best_Player;
        Process p;
        Timer timer;
        // bool boolean;
        public HeadClass()
        {
            file = new FileReadOrStream("Email_Pas.xml");
            allPlayers = new AllPlayers();
            player = new Player();
            quizHead = new QuizHead();
            allPlayers = file.ReadFile();
            best_Player = new Best_Player();
            timer = new Timer();
            timer.Interval = 10000;
            //boolean = false;
        }
        private void Foo(object sender, ElapsedEventArgs e)
        {
            p.Kill();
            timer.Stop();
        }
        private void Start_timer()
        {
            timer.Start();
            p = Process.Start(@"C:\Users\linec\source\repos\Quiz\Quiz\bin\Debug\BestPl.txt");
            timer.Elapsed += Foo;
        }

        public void menu()
        {
            List<string> srt = new List<string>();    //локальні змінні треба тут і зараз
            List<string> answer = new List<string>();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\tChoose Reg -->1\n\t\t\tLog -->2 ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            file.ReadStream("Quiz.txt", srt);
            file.ReadStream("Quiz_answer.txt", answer);

            Console.ForegroundColor = ConsoleColor.Blue;

            if (a == 1)
            {
                Register.Reg_new_User(player, allPlayers);
                Console.Clear();
                file.Writeplayer(allPlayers);
                Console.WriteLine("Choose\n 1 - Start quiz\n2 - Show best Players all time\n3 - Exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        quizHead.AnswersToQuestions("Quiz_answer.txt", srt, answer,ref player);
                        best_Player.Best_player_All_Time(allPlayers);
                        Start_timer();
                        break;
                    case "2":
                        best_Player.Best_player_All_Time(allPlayers);
                        Start_timer();
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
                Console.WriteLine("Choose\n 1 - Start quiz\n2 - Show best Players all time\n3 - Change password\n4 - Exit");
                
                switch (Console.ReadLine())
                {
                    case "1":
                        quizHead.AnswersToQuestions("Quiz_answer.txt", srt, answer,ref r);
                        best_Player.Best_player_All_Time(allPlayers);
                        Start_timer();
                        break;
                    case "2":
                        best_Player.Best_player_All_Time(allPlayers);
                        Start_timer();
                        break;
                    case "3":
                        Register.ChacheLogPassword(r);
                        break;
                    case "4":
                        break;
                }
                file.Writeplayer(allPlayers);
            }
        }
    }
}
