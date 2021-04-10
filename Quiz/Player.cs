using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Quiz
{
    
    public class Player: IComparable<Player>   // паблік для XML
    {
       
        public string Password { get; set; }
       
        public string Login { get; set; }
      
        public DateTime dataBirthday { get; set; }
        public int Points { get; set; }
        public Player()
        {
            Password = "";
            Login = "";
           // dataBirthday = DateTime.Now;
            Points = 0;
        }
        public Player(string log, string pas, DateTime data)
        {
            Login = log;
            Password = pas;
            dataBirthday = data;
        }

        public int CompareTo(Player other)
        {
            if (this.Points < other.Points)
            {
                return 1;
            }
            if (this.Points > other.Points)
            {        
                return -1;
            }
            else
                return 0;

          
        }
        public override string ToString()
        {
            return String.Format(this.Login, this.Points);
        }
    }
}
