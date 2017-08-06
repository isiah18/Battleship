using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            GameSetup game = new GameSetup();
            game.Start(menu);
        }

        public void playAgain()
        {
            Menu menu = new Menu();
            GameSetup game = new GameSetup();
            game.Start(menu);
        }
    }
}
