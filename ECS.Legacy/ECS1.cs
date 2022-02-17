using System;

namespace ECS.Legacy
{
    public class ECS1
    {
        private readonly IHeater Heater;
        private readonly ITempSensor TempSensor;
        private int _threshold;

        public ECS1(int thr, IHeater heater, ITempSensor tempSensor)
        {
            SetThreshold(thr);
            Heater = heater;
            TempSensor = tempSensor;
        }

        public void Regulate()
        {
            var t = TempSensor.GetTemp();
            Console.WriteLine($"Temperatur measured was {t}");
            if (t < _threshold)
                Heater.TurnOn();
            else
                Heater.TurnOff();

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
