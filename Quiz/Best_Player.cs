using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    class Best_Player 
    {
       
        FileReadOrStream fileReadOrStream;

        public Best_Player()
        {
            fileReadOrStream = new FileReadOrStream("BestPl.txt");
        }
        public void Best_player_All_Time(AllPlayers players) //не докінця робочий))
        {
            
            players.Players.Sort();
           
            foreach (var item in players.Players)
            {
                fileReadOrStream.WriteStream(item.Login, Convert.ToString(item.Points));
            }
        }
    }
}
