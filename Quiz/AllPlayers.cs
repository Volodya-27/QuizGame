using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    [DataContract]
    class AllPlayers
    {
        [DataMember]
        public List<Player> Players { get; set; }
        public AllPlayers()
        {
            Players = new List<Player>();
        }
        public void Add(Player player )
        {
            Players.Add(player);
        }
        //public void sort_point()
        //{
        //    Players.Sort();
           
        //}

        
    }
}
