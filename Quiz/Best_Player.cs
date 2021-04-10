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
        public void Best_player_All_Time(AllPlayers players) //не докінця робочий може капризувати і не працювати ))
        {
            players.Players.Sort();
            fileReadOrStream.WriteStream(players);
        }
    }
}
