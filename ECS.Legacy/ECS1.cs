using System;

namespace ECS.Legacy
{
    public class ECS1
    {
        private readonly IHeater Heater;
        private readonly ITempSensor TempSensor;
        private int _threshold;
        private bool windowOpen = false;

        public ECS1(int thr, IHeater heater, ITempSensor tempSensor)
        {
            SetThreshold(thr);
            Heater = heater;
            TempSensor = tempSensor;
        }

        public void IsWindowOpen()
        {
            if (TempSensor.GetTemp() > _threshold)
            {
                windowOpen = true;
            }
            else
            {
                windowOpen = false;
            }
        }

        public void Regulate()
        {
            var t = TempSensor.GetTemp();
            Console.WriteLine($"Temperatur measured was {t}");
            if (t < _threshold)
                Heater.TurnOn();
            else
                Heater.TurnOff();

            if (Console.KeyAvailable)
            {
                char C = Console.ReadKey().KeyChar;
                switch (C)
                {
                    case 'a':
                    case 'A':
                        SetThreshold(10);
                        break;
                    case 'b':
                    case 'B':
                        SetThreshold(20);
                        break;
                    case 'c':
                    case 'C':
                        SetThreshold(30);
                        break;
                    case 'd':
                    case 'D':
                        SetThreshold(40);
                        break;
                }
            }

        }

        public void SetThreshold(int thr)
        {
            _threshold = thr;
        }

        public int GetThreshold()
        {
            return _threshold;
        }

        public int GetCurTemp()
        {
            return TempSensor.GetTemp();
        }

        public bool RunSelfTest()
        {
            return TempSensor.RunSelfTest() && Heater.RunSelfTest();
        }
    }
}
