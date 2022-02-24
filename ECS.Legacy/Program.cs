using System;

namespace ECS.Legacy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing ECS.Legacy");



            // Make an ECS with a threshold of 23
            var control = new ECS1(23,new Heater(),new TempSensor());

            control.IsWindowOpen();

            for (int i = 1; i <= 15000; i++)
            {
                Console.WriteLine($"Running regulation number {i}");

                control.Regulate();

                if (Console.KeyAvailable)
                {
                    char C = Console.ReadKey().KeyChar;
                    switch (C)
                    {
                        case 'a':
                        case 'A':
                            control.SetThreshold(10);
                            break;
                        case 'b':
                        case 'B':
                            control.SetThreshold(20);
                            break;
                        case 'c':
                        case 'C':
                            control.SetThreshold(30);
                            break;
                        case 'd':
                        case 'D':
                            control.SetThreshold(40);
                            break;
                    }
                }
            }


        }
    }
}
