using System;

namespace ECS.Legacy
{
    internal class TempSensor : ITempSensor
    {
        private Random gen = new Random();

        public int GetTemp()
        {
           return gen.Next(0,10);
           //return 15;
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}