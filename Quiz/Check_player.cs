
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    static class Check_player
    {
        static List<string> keyValuePairs;
        static Check_player()
        {
            keyValuePairs = new List<string>();
        }
        public static void AddDictionary(AllPlayers allPlayers)
        {    
            for (int i = 0; i < allPlayers.Players.Count; i++)
            {
                keyValuePairs.Add(allPlayers.Players[i].Login);
            }
        }
        public static bool Check(Player player, AllPlayers allPlayers)
        {
            AddDictionary(allPlayers);
            foreach (var item in keyValuePairs)
            {
                if (player.Login == item)
                    return false;
            }
            return true;
        }
        public static Player Check_log(Player player, AllPlayers allPlayers)
        {
            foreach (var item in allPlayers.Players)
            {
                if (item.Password == player.Password && item.Login == player.Login)
                {
                    Console.WriteLine("You log");
                    return item;
                }
            }          
            return null;
        }

        

    }
}
