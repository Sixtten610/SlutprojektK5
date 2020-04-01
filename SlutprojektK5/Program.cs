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
            // Går ned till tutorial metoden för att förklara för spelaren hur man gör
            Tutorial();

            // bool för att starta spelet efter att man har gasat motorn lite
            bool gameStart = false;
            // boll för stunden innan racet börjar
            bool revPhase = true;

            // RPM hastighet
            int revSpeed = 0;

            // loop för stunden innan racet
            while (revPhase == true)
            {
                // hämtar in från metoden countdown för att se om spelaren inte har sprängt sin motor genom att träda över
                // RPM gränsen på 1300
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
            // Om spelaren var inom rimliga gränser kommer whileloopen att starta spelet och racet börjar.
            //åter igen kollar metoden Runway om spelaren går över 1300.
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
            // Tid under början av racet
            int clock = 250;
            // RPM hastigheten spelaren har
            int speed = 0;

            // loop som körs till tiden har tagit slut.
            while (clock > 0)
            {
                clock -= 1;
                // anropar metod för gaspedalen
                speed = Accelerator(speed);
                if (speed > 3000)
                {
                    return speed;
                }
                //saktar ned konsolen 10ms
                Thread.Sleep(10);

            }
            return speed;

        }


        //Metod för huvuddelev utav spelet
        static int Runway(int revSpeed)
        {

            int currentSpeed = revSpeed;
            //tid för denna period av spelet
            int clock = 1000;
            //Vilken växel man har
            int gear = 0;

            while (clock > 1)
            {
                //Metod för att skriva ut det som man ser på skärmen
                UserInterface(revSpeed, gear, clock);

                //Anropar metod för gaspedal för att åter igen se till så att spelaren inte spränger sin motor
                revSpeed = Accelerator(revSpeed);
                if (revSpeed > 18000)
                {
                    return 20000;
                }
                // om spelaren växlar upp så ++ på gear
                if (revSpeed >= 4500 && gear < 6)
                {
                    gear++;
                    revSpeed = 500;
                }

                //drar av 1 på tiden
                clock--;
                //stannar konsolen i 10ms
                Thread.Sleep(10);
            }
            
            return 0;
        }



        static int Accelerator(int speed)
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



        static void UserInterface(int speed, int gear, int clock)
        {

            Console.Clear();

            int uiBar = speed / 50;

            Console.WriteLine("Time:" + clock + " | RPM: " + speed + " | Gear [" + gear + "]");
            
            Console.Write("SPEED-O-METER: [");
            for (int i = 0; i < uiBar; i++)
            {
                if (uiBar < 20)
                {
                    Console.Write("#");
                }
                else
                {
                    Console.Write("$");
                }
            }
            Console.WriteLine("]");

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
