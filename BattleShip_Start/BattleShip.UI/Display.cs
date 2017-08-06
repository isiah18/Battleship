using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Models;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class Display
    {
        
        public void displayBoardWithShips(Board b, Player p)
        {


            BoardDisplayer board = new BoardDisplayer();
            Ship[] shipArray = b.getShips();
            Console.WriteLine("\n    ╔═══╦═════╦═════╦═════╦═════╦═════╦═════╦═════╦═════╦═════╦═════╗");
            Console.WriteLine("    ║{0}║  A  ║  B  ║  C  ║  D  ║  E  ║  F  ║  G  ║  H  ║  I  ║  J  ║", p.playerNumber);
            Console.WriteLine("    ╠═══╬═════╬═════╬═════╬═════╬═════╬═════╬═════╬═════╬═════╬═════╣");

            foreach (Ship s in shipArray)
            {
                if (s == null)
                {
                    continue;
                }
                else
                {
                    foreach (Coordinate coords in s.BoardPositions)
                    {
                        board.boardArray[coords.YCoordinate - 1, coords.XCoordinate - 1] = "#";
                    }
                }
            }

            
            for (int i = 0; i < 10; i++)
            {
                Console.Write("    ║ {0, -2}", i +1);
                for (int j = 0; j < 10; j++)
                {
                    if (board.boardArray[i, j] == "#")
                    {
                        Console.Write("║  ");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("{0,1}  ", board.boardArray[i, j]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.Write("║  {0,1}  ", board.boardArray[i, j]);
                    }
                    
                }
                Console.Write("║");
                if (i != 9)
                {
                    Console.WriteLine("\n    ╠═══╬═════╬═════╬═════╬═════╬═════╬═════╬═════╬═════╬═════╬═════╣");
                }
                else
                {
                    Console.WriteLine("\n    ╚═══╩═════╩═════╩═════╩═════╩═════╩═════╩═════╩═════╩═════╩═════╝");
                }
            }
        }


        public void displayBoardWithShotHistory(Board b, Player p)
        {
            Console.Clear();
            BoardDisplayer board = new BoardDisplayer();
            Dictionary<Coordinate, ShotHistory> shots = b.ShotHistory;

            Console.WriteLine("\n    ╔═══╦═════╦═════╦═════╦═════╦═════╦═════╦═════╦═════╦═════╦═════╗");
            Console.WriteLine("    ║{0}║  A  ║  B  ║  C  ║  D  ║  E  ║  F  ║  G  ║  H  ║  I  ║  J  ║", p.playerNumber);
            Console.WriteLine("    ╠═══╬═════╬═════╬═════╬═════╬═════╬═════╬═════╬═════╬═════╬═════╣");

            foreach (KeyValuePair<Coordinate, ShotHistory> s in shots)
            {
                if (shots.Count == 0)
                {
                    continue;
                }
                else
                {
                    if (s.Value == ShotHistory.Hit)
                    {
                        board.boardArray[s.Key.YCoordinate - 1, s.Key.XCoordinate - 1] = "H";
                    }
                    if (s.Value == ShotHistory.Miss)
                    {
                        board.boardArray[s.Key.YCoordinate - 1, s.Key.XCoordinate - 1] = "M";
                    }
                }
            }

            
            for (int i = 0; i < 10; i++)
            {
                Console.Write("    ║ {0, -2}", i + 1);
                for (int j = 0; j < 10; j++)
                {
                    if (board.boardArray[i, j] == "H")
                    {
                        Console.Write("║  ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("{0,1}  ", board.boardArray[i, j]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if(board.boardArray[i, j] == "M")
                    {
                        Console.Write("║  ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("{0,1}  ", board.boardArray[i, j]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.Write("║  {0,1}  ", board.boardArray[i, j]);
                    }
                }
                Console.Write("║");
                if (i != 9)
                {
                    Console.WriteLine("\n    ╠═══╬═════╬═════╬═════╬═════╬═════╬═════╬═════╬═════╬═════╬═════╣");
                }
                else
                {
                    Console.WriteLine("\n    ╚═══╩═════╩═════╩═════╩═════╩═════╩═════╩═════╩═════╩═════╩═════╝");
                }
            }
        }
    }
}
