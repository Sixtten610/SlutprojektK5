using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace SlutprojektK5
{
    class Program
    {
        static void Main(string[] args)
        {
            Tutorial();

            bool gameStart = false;
            bool revPhase = true;

            int revSpeed = 0;

            while (revPhase == true)
            {
                revSpeed = CountDown();
                if (revSpeed < 1100)
                {
                    gameStart = true;
                    revPhase = false;
                }
                if (revSpeed >= 3000)
                {
                    revPhase = false;
                }
            }

            while (gameStart == true)
            {
                int gameOn = Runway(revSpeed); 
                if (gameOn > 18000)
                {
                    gameStart = false;
                }
            }
            Console.ReadLine();
        }



        static int CountDown()
        {
            int clock = 250;
            int speed = 0;

            while (clock > 0)
            {
                clock -= 1;

                speed = GasPedal(speed);
                if (speed > 3000)
                {
                    return speed;
                }

                Thread.Sleep(10);

                Console.Clear();
                Console.WriteLine(speed + " Speed");
                Console.WriteLine(clock + " Clock");

            }
            return speed;

        }



        static int Runway(int revSpeed)
        {

            int currentSpeed = revSpeed;
            
            int clock = 1000;
            int gear = 0;

            while (clock > 1)
            {
                revSpeed = GasPedal(revSpeed);
                if (revSpeed > 18000)
                {
                    return 20000;
                }
                if (revSpeed >= 4500 && gear < 6)
                {
                    gear++;
                    revSpeed = 500;
                }

                clock--;
                Thread.Sleep(10);

                Console.Clear();

                Console.WriteLine(clock + " Clock");
                Console.WriteLine(gear + " Gear");
                Console.WriteLine(revSpeed + " Speed");

            }
            
            return 0;
        }



        static int GasPedal(int speed)
        {

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo info = Console.ReadKey(true);

                if (info.Key == ConsoleKey.LeftArrow)
                {
                    return 5000;
                }
                if (info.Key == ConsoleKey.Spacebar)
                {
                    if (speed < 1300)
                    {
                        speed = speed + 50;
                    }
                }
            }
            else
            {
                if (speed >= 10)
                {
                    speed -= 10;
                }
            }

            if (speed > 1330)
            {
                return 20000;
            }

            return speed;

        }



        static void Tutorial()
        {
            Console.WriteLine("Welcome to Drangster A2600!\n\n" +
            "This is a driving game where you strive to reach the highes score possible" + 
            "\n\nPress Enter to continue...");

            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("To increase speed press Space Bar to engage throttle.\nTo shift up a gear, press Left Arrowkey");
            Console.WriteLine("Readdy? Press Enter to continue...");
            Console.ReadLine();

            Countdown();
        }

        static void Countdown()
        {
            
            for (int i = 3; i > 0; i--)
            {
                Console.Clear();
                Console.WriteLine(i + "...");
                Thread.Sleep(1000);
            }
        }
    }

}
