using System;
using System.Threading;

namespace CAS
{
    public class CarAlarmSystem : ICarAlarmSystem
    {
        public bool opened = false;
        public bool closed = true;
        public bool locked = true;
        public bool unlocked = false;
        public bool flash = false;
        public bool sound = false;
        public bool armed = false;

        public void lockcar()
        {
            this.armed = true;
            this.locked = true;
        }
        public void unlock()
        {
            Console.WriteLine("Unlocking");
            this.armed = false;
            this.flash = false;
            this.sound = false;
            this.locked = false;
        }
        public void close()
        {
            this.opened = false;
        }
        public void open()
        {
            if (this.armed == true)
            {
                this.sound = true;
                Console.Out.WriteLine("**!!!**");
                tick();
                tick();
                tick();

                this.flash = true;

                for (int i = 0; i < 30; i++)
                {
                    Console.Out.WriteLine("**Flashing!!!**");
                    tick();
                }

                this.opened = true;
            }
            else
            {
                Console.Out.WriteLine("No alarm.");
                this.opened = true;
            }
        }
        public void tick()
        {
            Thread.Sleep(1000);
        }
    }
}
