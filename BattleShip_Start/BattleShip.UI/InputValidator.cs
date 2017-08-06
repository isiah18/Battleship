using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class InputValidator
    {
        public int[] validateInput()
        {
            int integerXCoord;
            int integerYCoord = new int();
            string xcoord;
            string ycoord = "";
            bool isValidX = false;
            bool isValidY;
            string input;
            int[] arrayCoord = new int[2];
            ConvertCoordinates letterToNumber = new ConvertCoordinates();

            do
            {
                Console.Write("Enter your two-digit coordinates (Example: B5): ");
                input = Console.ReadLine();
                
                if (input.Length == 2)
                {
                    ycoord = input[1].ToString();
                }
                else if (input.Length == 3)
                {
                    ycoord = input.Substring(1, 2);

                }
                else
                {
                    isValidX = false;
                    isValidY = false;
                    xcoord = "";
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You did not enter a valid X or Y coordinate. Try Again.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    continue;
                }

                xcoord = input[0].ToString().ToUpper();

                if (xcoord == "A" || xcoord == "B" || xcoord == "C" || xcoord == "D" || xcoord == "E" ||
                    xcoord == "F" || xcoord == "G" || xcoord == "H" || xcoord == "I" || xcoord == "J")
                {
                    isValidX = true;
                }
                else
                {
                    isValidX = false;
                }

                isValidY = int.TryParse(ycoord, out integerYCoord);

                if (integerYCoord < 1 || integerYCoord > 10)
                {
                    isValidY = false;
                }

                if (isValidX == false || isValidY == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You did not enter a valid X or Y coordinate. Try Again.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }while (isValidX == false || isValidY == false) ;

            integerXCoord = letterToNumber.ConvertLetterToCoord(xcoord);
            arrayCoord[0] = integerXCoord;
            arrayCoord[1] = integerYCoord;

            return arrayCoord;
        }
    }
}
