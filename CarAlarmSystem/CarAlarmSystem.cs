using System;
using System.Threading;

namespace CAS
{
    public class CarAlarmSystem : ICarAlarmSystem
    {
        public bool opened;
        public bool closed;
        public bool locked;
        public bool unlocked;
        public bool flash;
        public bool sound;
        public bool armed;

        public CarAlarmSystem(bool opened, bool closed, bool locked, bool unlocked, bool flash, bool sound, bool armed)
        {
            this.opened = opened;
            this.closed = closed;
            this.locked = locked;
            this.unlocked = unlocked;
            this.flash = flash;
            this.sound = sound;
            this.armed = armed;
        }

        public void lockcar()
        {
            this.locked = true;
            this.unlocked = false;
            if (this.closed)
            {
                this.armed = true;
            }
        }
        public void unlock()
        {
            this.armed = false;
            this.flash = false;
            this.sound = false;
            this.locked = false;
        }
        public void close()
        {
            this.opened = false;
            this.closed = true;
            if (this.locked)
            {
                this.armed = true;
            }
        }
        public void open()
        {
            this.opened = true;
            if (this.armed)
            {
                this.armed = false;
                this.flash = true;
                this.sound = true;

                if (this.unlocked)
                {
                    unlock();
                }
                else
                {
                    for (int i = 0; i < 30; i++)
                    {
                        if (i == 3)
                        {
                            this.sound = false;
                        }
                        tick();
                    }
                }

                this.flash = false;
                if (this.unlocked)
                {
                    unlock();
                }
                else if (this.closed)
                {
                    this.armed = true;
                    close();
                }
                unlock();
            }
        }
        public void tick()
        {
            Thread.Sleep(1000);
        }
    }
}
