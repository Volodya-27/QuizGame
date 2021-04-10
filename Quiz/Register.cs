using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    static class Register   // реєструємо нового користувача або заходимо у програму під уже створеним ніком
    {
        static public void Reg_new_User(Player player, AllPlayers allPlayers)
        {
            Console.WriteLine("\t\t\tEnter login example --> user(1-9)@gmail.com");
            player.Login = Console.ReadLine();
           
            if (Check_player.Check(player, allPlayers))
                allPlayers.Add(player);
            else
            {
                Console.WriteLine("You registr");
                Register.Log_User(player, allPlayers);
                
                return;
            }
            
            Console.WriteLine("\t\t\tenter Paswword example --> 123456(Q)werty");
            player.Password = Console.ReadLine();
            Console.WriteLine("\t\t\tenter Data birthday example --> 1999 07 25");
            player.dataBirthday = DateTime.Parse(Console.ReadLine());

            Check_password_Email.CheckEmail(player.Login);
            Check_password_Email.CheckPassword(player.Password);
        }
        static public Player Log_User(Player player, AllPlayers allPlayers )
        {
            Console.WriteLine("Enter login");
            player.Login = Console.ReadLine();
            Console.WriteLine("enter Paswword");
            player.Password = Console.ReadLine();
            var t = Check_player.Check_log(player, allPlayers);
            if (t == null)
            {
                Console.WriteLine("You no Sing");
                Register.Reg_new_User(player, allPlayers);
            }
            return t;
        }
        static public void  ChacheLogPassword(Player pl)
        {
            Console.WriteLine("Enter login example --> user(1-9)@gmail.com");
            pl.Login = Console.ReadLine();
            Console.WriteLine("enter Paswword example --> 123456(Q)werty");
            pl.Password = Console.ReadLine();

        }


    }
}
