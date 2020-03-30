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
                    Thread.Sleep(5000);
                    Console.Clear();
                    revPhase = false;
                }
            }

            while (gameStart == true)
            {
                Runway(revSpeed);
            }

            Console.ReadLine();
        }



        static int CountDown()
        {
            int clock = 500;
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

        static int Runway (int revSpeed)
        {
            Thread.Sleep(2000);
            Console.WriteLine(revSpeed + " Si SNJOR");
            Thread.Sleep(2000);
            return revSpeed;

        }

        static int GasPedal(int speed)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo info = Console.ReadKey(true);

                if (info.Key == ConsoleKey.LeftArrow || speed > 1300)
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
            return speed;

        }

    }

}
