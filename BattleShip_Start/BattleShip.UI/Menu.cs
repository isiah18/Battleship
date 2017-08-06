using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Models;


namespace BattleShip.UI
{
    public class Menu
    {
        Player player1 = new Player();
        Player player2 = new Player();

        public void beginGameMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@"
              ____    _  _____ _____ _     _____ ____  _   _ ___ ____  
             | __ )  / \|_   _|_   _| |   | ____/ ___|| | | |_ _|  _ \ 
             |  _ \ / _ \ | |   | | | |   |  _| \___ \| |_| || || |_) |
             | |_) / ___ \| |   | | | |___| |___ ___) |  _  || ||  __/ 
             |____/_/   \_\_|   |_| |_____|_____|____/|_| |_|___|_|    
                                                           ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\n\n\t\t\t\t Press ENTER to start game!");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadLine();
        }

        public Player[] getUserNames()
        {
            Player[] playerArr = new[] { player1, player2 };

            string playerName1;
            string playerName2;
            do
            {
                Console.Write("Player 1, enter your name : ");
                playerName1 = Console.ReadLine();
                if (playerName1.Length == 0)
                {
                    Console.WriteLine("Please enter your name.");
                }
                    
            } while (playerName1.Length == 0);

            do
            {
                Console.Write("Player 2, enter your name : ");
                playerName2 = Console.ReadLine();
                if (playerName2.Length == 0)
                {
                    Console.WriteLine("Please enter your name.");
                }
            } while (playerName2.Length == 0);
            

            setUserNames(playerName1, playerName2);

            return playerArr;
        }

        public void setUserNames(string p1, string p2)
        {
            player1.playerName = p1;
            player1.playerNumber = "P-1";
            player2.playerName = p2;
            player2.playerNumber = "P-2";
        }
    }
}
