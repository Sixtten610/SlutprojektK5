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
            bool countDown = true;


            while (countDown == true)
            {
                CountDown();
                if (CountDown() < 5000)
                {
                    gameStart = true;
                    countDown = false;
                }
                else if (CountDown() == 9999)
                {
                    Console.WriteLine("YOU LOST");
                    Thread.Sleep(10000);
                    Console.Clear();
                }
            }

            Console.WriteLine("Hej");

            while (gameStart == true)
            {
                //GasPedal();
            }

            Console.ReadLine();
        }

        static int CountDown()
        {
            int clock = 900;
            int speed = 0;

            while (clock > 0)
            {
                
                Console.WriteLine(speed);
                Console.WriteLine(clock);
                clock -= 1;

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo info = Console.ReadKey(true);
                    if (info.Key == ConsoleKey.LeftArrow)
                    {
                        return 9999;
                    }
                    else if (info.Key == ConsoleKey.Spacebar)
                    {
                        if (speed < 1000)
                        {
                            speed = speed + 50;
                        }
                    }
                }
                else
                {
                    {
                        if (speed > 0)
                        {
                            speed -= 5;
                        }
                    }
                }
                Thread.Sleep(1000);
            }
            return speed;
        }
    }
}
