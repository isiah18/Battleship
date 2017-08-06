using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class ConvertCoordinates
    {
        public int ConvertLetterToCoord(string letter)
        {
            Dictionary<string, int> LetterToNumber = new Dictionary<string, int>()
            {
                { "A", 1},
                { "B", 2},
                { "C", 3},
                { "D", 4},
                { "E", 5},
                { "F", 6},
                { "G", 7},
                { "H", 8},
                { "I", 9},
                { "J", 10}
            };
            return LetterToNumber[letter];
        }
    }
}
