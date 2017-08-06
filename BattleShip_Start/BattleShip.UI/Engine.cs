using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Models;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{
    public class Engine
    {
        private int TurnCounter = 1;
        private Player player1;
        private Player player2;

        public void Start(Board b1, Board b2, Player[] playerArray)
        {
            int[] shot = new int[2];
            FireShotResponse response = new FireShotResponse();
            ResponseDisplayer ResponseWriter = new ResponseDisplayer();
            setPlayers(playerArray);

            do
            {
                ShotStatus responseType = new ShotStatus();
                if (TurnCounter%2 == 0)
                {
                    do
                    {
                        showShotHistory(player2, b1);
                        shot = getUserShot(player2);
                        response = firePlayerShot(shot, b1);
                        Console.Clear();
                        showShotHistory(player2, b1);
                        responseType = ResponseWriter.DisplayResponse(response);
                        
                    } while (responseType == ShotStatus.Invalid || responseType == ShotStatus.Duplicate);
                    TurnCounter++;
                }
                else
                {
                    do
                    {
                        showShotHistory(player1, b2);
                        shot = getUserShot(player1);
                        response = firePlayerShot(shot, b2);
                        Console.Clear();
                        showShotHistory(player1, b2);
                        responseType = ResponseWriter.DisplayResponse(response);
                    } while (responseType == ShotStatus.Invalid || responseType == ShotStatus.Duplicate);
                    TurnCounter++;
                }
            } while (response.ShotStatus != ShotStatus.Victory);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Game Over. Would you like to play again? (y/n)");
            Console.ForegroundColor = ConsoleColor.Gray;
            string playagain = Console.ReadLine();
            if (playagain == "y")
            {
                Console.Clear();
                Program p = new Program();
                p.playAgain();
            }
            else
            {
                Console.WriteLine("Thanks for playing. Bye.");
                Thread.Sleep(3000);
            }
        }

        public int[] getUserShot(Player p)
        {
            InputValidator validate = new InputValidator();
            int[] arrayCoord = new int[2];

            Console.WriteLine("Player {0} where would you like to attack?", p.playerName);
            arrayCoord = validate.validateInput();
            return arrayCoord;
        }

        public FireShotResponse firePlayerShot(int[] shotFired, Board b)
        {
            Coordinate shotCoord = new Coordinate(shotFired[0], shotFired[1]);
            FireShotResponse response = new FireShotResponse();
            response = b.FireShot(shotCoord);
            return response;
        }

        public void showShotHistory(Player p, Board b)
        {
            Display dispBoard = new Display();
            dispBoard.displayBoardWithShotHistory(b, p);
        }

        public void setPlayers(Player[] playerArray)
        {
            player1 = playerArray[0];
            player2 = playerArray[1];
        }
    }
}
