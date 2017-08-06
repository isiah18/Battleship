using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Responses;
using System.Media;
using System.Threading;

namespace BattleShip.UI
{
    public class ResponseDisplayer
    {
        public ShotStatus DisplayResponse(FireShotResponse response)
        {
            ShotStatus status = new ShotStatus();
            switch (response.ShotStatus)
            {
                case ShotStatus.Invalid:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That shot is off the board! Press ENTER again.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ReadLine();
                    status = ShotStatus.Invalid;
                    break;
                case ShotStatus.Duplicate:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You already attacked that spot. Press ENTER to pick another coordinate.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ReadLine();
                    status = ShotStatus.Duplicate;
                    break;
                case ShotStatus.Miss:
                    MissSound();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sorry, you missed. Better luck next time. Press ENTER to continue.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ReadLine();
                    status = ShotStatus.Miss;
                    break;
                case ShotStatus.Hit:
                    HitSound();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Congratulations! You hit your opponents boat!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadLine();
                    status = ShotStatus.Hit;
                    break;
                case ShotStatus.HitAndSunk:
                    HitSound();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Hit and Sunk opponent's {0}. Good job!", response.ShipImpacted);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Thread.Sleep(2000);
                    if (response.ShipImpacted == "Carrier")
                    {
                        AircraftCarrier();
                    }
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadLine();
                    status = ShotStatus.HitAndSunk;
                    break;
                case ShotStatus.Victory:
                    WinnerSound();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("YOU WIN !!!!!!! Congratulations, you sunk all ships!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Press ENTER to continue.");
                    Console.ReadLine();
                    status = ShotStatus.Victory;
                    break;
                default:
                    break;
            }
            return status;
        }

        public void HitSound()
        {
            var myPlayer = new System.Media.SoundPlayer();
            myPlayer.SoundLocation = @"..\..\SoundEffects\Hit_Explosion.wav";
            myPlayer.Play();
        }

        public void MissSound()
        {
            var myPlayer = new System.Media.SoundPlayer();
            myPlayer.SoundLocation = @"..\..\SoundEffects\Wave_Crashing.wav";
            myPlayer.Play();
        }

        public void WinnerSound()
        {
            var myPlayer = new System.Media.SoundPlayer();
            myPlayer.SoundLocation = @"..\..\SoundEffects\Winner.wav";
            myPlayer.Play();
        }

        public void AircraftCarrier()
        {
            var myPlayer = new System.Media.SoundPlayer();
            myPlayer.SoundLocation = @"..\..\SoundEffects\Aircraft_Carrier.wav";
            myPlayer.Play();
        }
    }
}
