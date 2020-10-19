using System;

namespace CarAlarmSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            CarAlarmSystem TestCAS = new CarAlarmSystem(false, true, false, false, true);
            Console.WriteLine("Car is locked by default.");
            TestCAS.open();
            TestCAS.unlock();
            TestCAS.open();
        }
    }
}
