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
using System.Media;

namespace BattleShip.UI
{
    public class GameSetup
    {
        Player[] playerArray = new Player[2];

        public void Start(Menu menu)
        {
            Board board1 = new Board();
            Board board2 = new Board();

            AlertOne();

            menu.beginGameMenu();
            playerArray = menu.getUserNames();
            Console.Clear();

            SetUpBoards(playerArray[0], board1);
            Console.Write("Press ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("ENTER");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" to finish board setup.");
            Console.ReadLine();
            Console.Clear();
            SetUpBoards(playerArray[1], board2);
            Console.Write("Press ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("ENTER");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" to finish board setup.");
            Console.ReadLine();
            Console.Clear();

            GeneralQuarters();

            Engine gameEngine = new Engine();
            gameEngine.Start(board1, board2, playerArray);
        }

        public void SetUpBoards(Player p, Board b)
        {
            ShipPlacement checkPlacement = new ShipPlacement();
            Display dispBoard = new Display();

            int[] arrayOfCoords = new int[2];

            ShipType ShipSelection = new ShipType();
            ShipDirection DirectionSelection = new ShipDirection();

            foreach (var ship in Enum.GetValues(typeof (ShipType)))
            {
                do
                {
                    Console.Clear();
                    dispBoard.displayBoardWithShips(b, p);
                    Console.WriteLine("Player {0}, where would you like to place {1}?", p.playerName, ship);
                    ShipSelection = ((ShipType)ship);
                    arrayOfCoords = setShipCoords();
                    DirectionSelection = selectDirection();
                    PlaceShipRequest request = new PlaceShipRequest()
                    {
                        Coordinate = new Coordinate(arrayOfCoords[0], arrayOfCoords[1]),
                        Direction = DirectionSelection,
                        ShipType = ShipSelection
                    };

                    checkPlacement = b.PlaceShip(request);
                    if (checkPlacement == ShipPlacement.NotEnoughSpace)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("There is not enough room to place your {0} in that direction. Press ENTER to try again.", ship);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.ReadLine();
                    }
                    if (checkPlacement == ShipPlacement.Overlap)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You cannot overlap ship positions. Choose another coordinate. Press ENTER to try again.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.ReadLine();
                    }
                } while (checkPlacement == ShipPlacement.NotEnoughSpace || checkPlacement == ShipPlacement.Overlap);
            }
            Console.Clear();
            dispBoard.displayBoardWithShips(b, p);
        }

        public int[] setShipCoords()
        {
           InputValidator validate = new InputValidator();
            int[] arrayCoord = new int[2];

            Console.WriteLine("Select and X and Y coordinate at which you want to place this ship: ");

            arrayCoord = validate.validateInput();

            return arrayCoord;
        }

        public ShipDirection selectDirection()
        {
            Console.WriteLine("The coordinate you entered is the location of the front of your ship, which direction do you want the rest of the ship to lie? ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("U = Up, D = Down, L = Left, R = Right ");
            Console.ForegroundColor = ConsoleColor.Gray;
            ShipDirection dirSelection = new ShipDirection();
            string dirInput;

            do
            {
                dirInput = Console.ReadLine();
                dirInput = dirInput.ToUpper();
                switch (dirInput)
                {
                    case "U":
                        dirSelection = ShipDirection.Up;
                        break;

                    case "D":
                        dirSelection = ShipDirection.Down;
                        break;

                    case "L":
                        dirSelection = ShipDirection.Left;
                        break;

                    case "R":
                        dirSelection = ShipDirection.Right;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Youe entered a direction that does not exist.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }
            } while (dirInput != "U" && dirInput != "D" && dirInput != "L" && dirInput != "R");
            
            return dirSelection;
        }

        public void GeneralQuarters()
        {
            var myPlayer = new System.Media.SoundPlayer();
            myPlayer.SoundLocation = @"..\..\SoundEffects\General_Quarters.wav";
            myPlayer.Play();
        }

        public void AlertOne()
        {
            var myPlayer = new System.Media.SoundPlayer();
            myPlayer.SoundLocation = @"..\..\SoundEffects\alert1.wav";
            myPlayer.Play();
        }
    }
}
